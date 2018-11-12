using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static PlatziMVC.Utils.Utils;

namespace PlatziMVC.Models
{
  public class SchoolContext : DbContext
  {
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Course> Courses { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var school = new School()
      {
        Name = "Sheas Cool!",
        FundationYear = 2018,
        Id = Guid.NewGuid().ToString(),
        Address = "Cll 1 # 1a - 2",
        Country = "USA",
        City = "N.Y",
        SchoolType = SchoolTypes.Prescholar
      };

      var courses = GenerateCourses(school);
      var subjects = GenerateSubjects(courses);
      var students = GenerateStudentsByCourses(courses);

      modelBuilder.Entity<School>().HasData(school);
      modelBuilder.Entity<Course>().HasData(courses.ToArray());
      modelBuilder.Entity<Subject>().HasData(subjects.ToArray());
      modelBuilder.Entity<Student>().HasData(students.ToArray());
    }

    private static List<Student> GenerateStudentsByCourses(List<Course> courses)
    {
      var students = new List<Student>();
      Random rnd = new Random();
      foreach (var course in courses)
      {
        var studentLimit = rnd.Next(5, 20);
        var studentsByCourse = GenerateStudents(studentLimit, course);
        students.AddRange(studentsByCourse);
      }

      return students;
    }
    private static List<Subject> GenerateSubjects(List<Course> courses)
    {
      List<Subject> subjects = new List<Subject>();
      foreach (var course in courses)
      {
        var subjectsByCourse = new List<Subject>() {
                new Subject() { Id = GetGUID(), Name = "Maths", CourseId = course.Id },
                new Subject() { Id = GetGUID(), Name = "English", CourseId = course.Id  },
                new Subject() { Id = GetGUID(), Name = "History", CourseId = course.Id },
                new Subject() { Id = GetGUID(), Name = "Technology", CourseId = course.Id  }
            };
        subjects.AddRange(subjectsByCourse);
      }
      return subjects;
    }

    private static List<Course> GenerateCourses(School school)
    {
      var courses = new List<Course>(){
        new Course() { Id = GetGUID(), SchoolId = school.Id, Name = "101", DayTime = DayTimes.Afternoon, Address = "Cll 0 l a68" },
        new Course() { Id = GetGUID(), SchoolId = school.Id, Name = "201", DayTime = DayTimes.Evenight, Address = "Cll 0 l a68" },
        new Course() { Id = GetGUID(), SchoolId = school.Id, Name = "301", DayTime = DayTimes.Morning, Address = "Cll 0 l a68" },
        new Course() { Id = GetGUID(), SchoolId = school.Id, Name = "401", DayTime = DayTimes.Afternoon, Address = "Cll 0 l a68" },
        new Course() { Id = GetGUID(), SchoolId = school.Id, Name = "501", DayTime = DayTimes.Evenight, Address = "Cll 0 l a68" }
      };
      return courses;
    }

    private static List<Student> GenerateStudents(int limit, Course course)
    {
      string[] firstname = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "NicolÃ¡s" };
      string[] secondname = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
      string[] lastname = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

      var students = from n1 in firstname
                     from n2 in secondname
                     from a1 in lastname
                     select new Student
                     {
                       Id = GetGUID(),
                       Name = $"{n1} {n2} {a1}",
                       CourseId = course.Id
                     };

      return students.OrderBy((al) => al.Id).Take(limit).ToList();
    }
  }
}