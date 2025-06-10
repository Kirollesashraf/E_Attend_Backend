using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Entities.OptionModels;
using E_Attend.Service._Attendance;
using E_Attend.Service._Course;
using Microsoft.Extensions.Options;
using Supabase;
using SupabaseOptions = E_Attend.Entities.OptionModels.SupabaseOptions;

namespace E_Attend.Service._Supabase;

public class DailySupabaseSyncService : BackgroundService
{
    private readonly ILogger<DailySupabaseSyncService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public DailySupabaseSyncService(
        ILogger<DailySupabaseSyncService> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ReadFromSupabase();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while syncing from Supabase");
            }

            // Wait 24 hours before running again
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }

    private async Task ReadFromSupabase()
    {
        using var scope = _scopeFactory.CreateScope();

        
        var options = scope.ServiceProvider.GetRequiredService<IOptions<SupabaseOptions>>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var attendanceService = scope.ServiceProvider.GetRequiredService<IAttendanceService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        
        var supabaseOptions = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        var supabase = new Supabase.Client(options.Value.Url, options.Value.Key, supabaseOptions);
        await supabase.InitializeAsync();

        var scheduled = await supabase.Rpc<List<ScheduledAttendanceDto>>("ScheduledAttendance", null);
        
        foreach (var attendance in scheduled)
        {
            var course = await courseService.GetCourseByTitleAsync(attendance.CourseName);
            var a = new Attendance()
            {
                StudentId = attendance.StudentId,
                Status = "SCHEDULED_"+attendance.Status,
                CourseId = course.Data?.Id,
                TimeSlot = attendance.TimeSlot,
                Date = attendance.AttendanceDate.ToUniversalTime()
            };
            await attendanceService.AddAttendanceAsync(a);
        }
        
        var unscheduled = await supabase.Rpc<List<ScheduledAttendanceDto>>("UnscheduledAttendance", null);
        foreach (var attendance in unscheduled)
        {
            var course = await courseService.GetCourseByTitleAsync(attendance.CourseName);
            var a = new Attendance()
            {
                StudentId = attendance.StudentId,
                Status = "UNSCHEDULED_" + attendance.Status,
                CourseId = course.Data?.Id,
                TimeSlot = attendance.TimeSlot,
                Date = attendance.AttendanceDate.ToUniversalTime()
            };
            await attendanceService.AddAttendanceAsync(a);
        }

        _logger.LogInformation("Supabase data sync complete.");
    }
}