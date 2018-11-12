using System.Collections.Generic;

namespace PlatziMVC.Models
{
    public class Student: SchoolBaseModel
    {
        public List<Quiz> Quizzes { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}