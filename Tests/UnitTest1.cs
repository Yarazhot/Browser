using Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        public const string DllPath = "D:\\Learning\\3 курс\\СПП\\Laba3\\Example\\Browser\\Browser\\Browser\\bin\\Debug\\netcoreapp3.1\\Browser.dll";

        [TestMethod]
        public void TestNamespacesName()
        {
            var assemblyInfo = new DllTreeProvider(DllPath).getTree();

            var actual = assemblyInfo[0].name;
            var expected = "Browser";
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestTypesName()
        {
            var assemblyInfo = new DllTreeProvider(DllPath).getTree();

            var actual = assemblyInfo[0].types[0].name;
            var expected = "DllTreeProvider";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestTypesCount()
        {
            var assemblyInfo = new DllTreeProvider(DllPath).getTree();

            var actual = assemblyInfo[0].types.Count;
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMembersName()
        {
            var assemblyInfo = new DllTreeProvider(DllPath).getTree();

            var actual = assemblyInfo[0].types[0].components[1].stringRepresentation;
            var expected = "Type GetType()";
            Assert.AreEqual(expected, actual);
        }


    }
}