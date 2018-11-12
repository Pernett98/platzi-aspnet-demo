namespace PlatziMVC.Models
{
  public class Quiz : SchoolBaseModel
  {
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string SubjectId { get; set; }
    public Subject Subject { get; set; }
    public float Qualification { get; set; }

    public override string ToString()
    {
      if (Student != null)
      {
        return $"Q: ${Qualification}, St: {Student.Name}, Sb:{Subject.Name}";
      }
      return $"Q: ${Qualification}";
    }
  }
}