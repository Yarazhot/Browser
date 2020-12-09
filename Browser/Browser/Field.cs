using System;

namespace Browser
{
    public class Field : IComponent
    {
        public string name { get; }
        public string type { get; }

        public Field(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string stringRepresentation => type + " " + name;

        public override string ToString()
        {
            return this.stringRepresentation;
        }
    }
}
