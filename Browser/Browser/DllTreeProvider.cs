using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Browser
{
    public class DllTreeProvider : ITreeProvider
    {
        const string STATIC = "static";
        private string path;

        public DllTreeProvider(string path)
        {
            this.path = path;
        }

        public IList<Namespace> getTree()
        {
            var namespaces = new Dictionary<string, Namespace>();
            var assembly = Assembly.LoadFile(path);
            foreach (var type in assembly.GetTypes())
            {
                var namespaceName = type.Namespace ?? STATIC;
                Namespace currentNamespace;
                if (namespaces.ContainsKey(namespaceName))
                {
                    currentNamespace = namespaces[namespaceName];
                } 
                else
                {
                    currentNamespace = new Namespace(namespaceName);
                    namespaces.Add(namespaceName, currentNamespace);
                }
                var objectType = new ObjectType(type.Name);
                setupFields(objectType, type);
                setupProperties(objectType, type);
                setupMethods(objectType, type);
                currentNamespace.addType(objectType);
            }

            return namespaces.Values.ToList();
        }

        private void setupFields(ObjectType objectType, Type type)
        {
            foreach (var field in type.GetFields())
            {
                objectType.addComponent(new Field(field.Name, field.FieldType.Name));
            }
        }

        private void setupProperties(ObjectType objectType, Type type)
        {
            foreach (var property in type.GetProperties())
            {
                objectType.addComponent(new Property(property.Name, property.PropertyType.Name));
            }
        }

        private void setupMethods(ObjectType objectType, Type type)
        {
            foreach (var method in type.GetMethods())
            {
                var methodType = new Method(method.Name, method.ReturnType.Name);
                foreach (var parameter in method.GetParameters())
                {
                    methodType.addParametr(new Field(parameter.Name, parameter.ParameterType.Name));
                }
                objectType.addComponent(methodType);
            }
        }
    }
}
