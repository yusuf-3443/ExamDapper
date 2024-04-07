
using Infrastructure.DataContext;
using Infrastructure.Services;
using Infrastructure.Services.AttendanceService;
using Infrastructure.Services.ClassroomService;
using Infrastructure.Services.ClassroomStudentService;
using Infrastructure.Services.CourseService;
using Infrastructure.Services.ExamResultService;
using Infrastructure.Services.ExamSerrvice;
using Infrastructure.Services.ExamTypeService;
using Infrastructure.Services.GradeService;
using Infrastructure.Services.ParentService;
using Infrastructure.Services.StudentService;
using Infrastructure.Services.TeacherService;

var builder=WebApplication.CreateBuilder();

builder.Services.AddScoped<IAttendanceService,AttendanceService>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<IClassroomStudentService, ClassroomStudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IExamResultService, ExamResultService>();
builder.Services.AddScoped<IExamTypeService, ExamTypeService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IQueryService, QueryServices>();
builder.Services.AddScoped<DapperContext>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app=builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();