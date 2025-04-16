using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.ConfigurationModels;

namespace E_Attend.Service
{
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

            var supabaseOptions = new Supabase.SupabaseOptions {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(options.Value.Url, options.Value.Key, supabaseOptions);
            await supabase.InitializeAsync();

            var lst = await supabase.Rpc<List<Entities.Models.Attendance>>("AttendanceTableUsingJoin", null);

            if (lst != null)
            {
                foreach (var ele in lst)
                {
                    if (await unitOfWork.AttendanceRepository.GetFirstOrDefaultAsync(
                            a => a.Status == ele.Status &&
                                 a.Timestamp == ele.Timestamp &&
                                 a.CourseID == ele.CourseID &&
                                 a.StudentID == ele.StudentID) == null)
                    {
                        await unitOfWork.AttendanceRepository.AddAsync(ele);
                    }

                }

                await unitOfWork.CompleteAsync();
            }

            _logger.LogInformation("Supabase data sync complete.");
        }
    }
}
