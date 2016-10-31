namespace Clarizen.POCO
{
    public class Task
    {
        public string id { get; set; }
        public string Name { get; set; }

        public Task() { }

        public Task(string id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        public Task(string name)
        {
            this.Name = name;
        }

    }
}
