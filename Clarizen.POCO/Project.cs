namespace Clarizen.POCO
{
    public class Project
    {
        public string id { get; set; }
        public string Name { get; set; }

        public Project(string id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public Project(string name)
        {
            this.Name = name;
        }
    }
}
