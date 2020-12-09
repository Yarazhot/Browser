using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Browser
{
    public class Namespace
    {
        public string name { get; }
        public ObservableCollection<ObjectType> types { get; }
        public Namespace(string name)
        {
            this.name = name;
            types = new ObservableCollection<ObjectType>();
        }

        public void addType(ObjectType type)
        {
            types.Add(type);
        }
    }
}
