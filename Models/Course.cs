using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziMVC.Models
{
  public class Course : SchoolBaseModel
  {
    [Required]
    [StringLength(15)]
    public override string Name { get; set; }
    public DayTimes DayTime { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<Student> Students { get; set; }
    
    [Required]
    [StringLength(20)]
    [Display(Prompt="School Address")]
    public string Address { get; set; }

    public string SchoolId { get; set; }

    public School School { get; set; }
  }
}