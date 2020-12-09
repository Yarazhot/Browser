using System.Collections.Generic;
using System.Text;

namespace Browser
{
    public class Method : IComponent
    {
        public string name { get; }
        public IList<Field> parameters { get; }
        public string returnType { get; }

        public Method(string name, string returnType)
        {
            this.name = name;
            parameters = new List<Field>();
            this.returnType = returnType;
        }

        public void addParametr(Field parameter)
        {
            parameters.Add(parameter);
        }

        public string stringRepresentation
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.Append(returnType + " " + name + "(");
                result.AppendJoin(", ", parameters);
                result.Append(")");
                return result.ToString();
            }
        }
    }
}
