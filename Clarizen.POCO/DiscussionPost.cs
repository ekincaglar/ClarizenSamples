namespace Clarizen.POCO
{
    public class DiscussionPost
    {
        public string id { get; set; }
        public string Body { get; set; }
        public string Container { get; set; }
        public string Via { get; set; }

        public DiscussionPost(string id, string Body, string Container, string Via)
        {
            this.id = id;
            this.Body = Body;
            this.Container = Container;
            this.Via = Via;
        }
    }
}
