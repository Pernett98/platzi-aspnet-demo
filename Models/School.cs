using System.Collections.Generic;

namespace PlatziMVC.Models
{
  public class School : SchoolBaseModel
  {
    public int FundationYear { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public SchoolTypes SchoolType { get; set; }
    public List<Course> Courses { get; set; }

    public School() { }
    public School(string name, int year) => (Name, FundationYear) = (name, FundationYear);

    public School(
        string name,
        int year,
        SchoolTypes schoolType,
        string country = "",
        string city = ""
        ) : base()
    {
      (Name, FundationYear) = (name, year);
      SchoolType = schoolType;
      (Country, City) = (country, city);
    }

    public override string ToString()
    {
      return $"Name: {Name}, Type: {SchoolType}," +
      System.Environment.NewLine +
      $"Country: {Country}, City: {City}";
    }

  }
}