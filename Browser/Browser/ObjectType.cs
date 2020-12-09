using System;
using System.Collections.Generic;
using System.Text;

namespace Browser
{
    public class ObjectType
    {
        public IList<IComponent> components { get; }

        public string name { get; }

        public ObjectType(string name)
        {
            this.name = name;
            components = new List<IComponent>();
        }

        public void addComponent(IComponent component)
        {
            components.Add(component);
        }

    }
}
