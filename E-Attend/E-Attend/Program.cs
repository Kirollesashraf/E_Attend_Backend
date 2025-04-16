using E_Attend.Data_Access.context;
using E_Attend.Data_Access.RepositoryImplementation;
using E_Attend.Entities.Repositories;
using E_Attend.Service.Assignment;
using E_Attend.Service.Assignment.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using E_Attend.Entities.ConfigurationModels;
using E_Attend.Service;
using E_Attend.Service.Course;
using E_Attend.Service.Enrollment;
using E_Attend.Service.Instructor;
using E_Attend.Service.Sheet;
using E_Attend.Service.Student;
using E_Attend.Service.Submission;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SupabaseOptions>(builder.Configuration.GetSection("Supabase"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddHostedService<DailySupabaseSyncService>();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ISheetService, SheetService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapScalarApiReference();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();