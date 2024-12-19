using System.Reflection;
using SchoolDiarySystem.Api;
using SchoolDiarySystem.Api.Services;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;
using SchoolDiarySystem.Tests;

var builder = WebApplication.CreateBuilder(args);


//создание образа SchoolFixture

var SchoolFixture = new SchoolFixture();

//регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//регистрация репозиториев
builder.Services.AddSingleton<IRepository<Student>>(new IStudentRepository(SchoolFixture.Repository.Students));
builder.Services.AddSingleton<IRepository<SchoolClass>>(new ISchoolClassRepository(SchoolFixture.Repository.Classes));
builder.Services.AddSingleton<IRepository<Subject>>(new ISubjectRepository(SchoolFixture.Repository.Subjects));
builder.Services.AddSingleton<IRepository<Grade>>(new IGradeRepository(SchoolFixture.Repository.Grades));

//регистрация сервисов и интерфейсов
builder.Services.AddScoped<IService<StudentGetDto, StudentPostDto>, StudentService>();
builder.Services.AddScoped<IService<SchoolClassGetDto, SchoolClassPostDto>, SchoolClassService>();
builder.Services.AddScoped<IService<GradeGetDto, GradePostDto>, GradeService>();
builder.Services.AddScoped<IService<SubjectGetDto, SubjectPostDto>, SubjectService>();

//регистрация AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
