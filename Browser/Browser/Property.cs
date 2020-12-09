namespace Browser
{
    public class Property : IComponent
    {
        public string name { get; }
        public string type { get; }

        public Property(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string stringRepresentation => type + " " + name;
    }
}
