using System.Collections.Generic;

namespace PlatziMVC.Models
{
  public class Subject : SchoolBaseModel
  {
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public List<Quiz> Quizzes { get; set; }
  }
}