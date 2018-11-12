namespace PlatziMVC.Models
{
    public abstract class SchoolBaseModel
    {
        public string Id { get; set; }
        public virtual string Name { get;set; }

        public SchoolBaseModel() {}

        public override string ToString()
        {
            return $"Name: {Name}, UUID: {Id}";
        }
    }
}