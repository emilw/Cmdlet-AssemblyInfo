using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cmdlet_AssemblyInfo;
using Tests.Mock;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BasicFunctionalityTests
    {
        private List<Cmdlet_AssemblyInfo.Type> RunCmdWithParameter(string attribute = null, string fullName = null, string baseType = null, string namespac = null)
        {
            var assemblyTypeInfo = new GetAssemblyTypeInfo();
            assemblyTypeInfo.AssemblyPath = this.GetType().Assembly.Location;

            assemblyTypeInfo.AttributeFilter = attribute;
            assemblyTypeInfo.FullNameFilter = fullName;
            assemblyTypeInfo.BaseTypeFilter = baseType;
            assemblyTypeInfo.Namespace = namespac;

            var result = assemblyTypeInfo.Invoke();
            return result.Cast<Cmdlet_AssemblyInfo.Type>().ToList();
        }

        [TestMethod]
        public void GetTypesByAttribute()
        {
            var attributeFilter = typeof(DummyAttribute).FullName.ToString();
            var result = RunCmdWithParameter(attribute:attributeFilter);

            Assert.IsTrue(result.Count() == 1);
            var type = result.First();
            Assert.AreEqual(typeof(Mock.SubGroup.SpecialTypeWithAttribute).FullName, type.Name);
        }

        [TestMethod]
        public void GetTypesByFullNameComplete()
        {
            var fullNameComplete = typeof(Mock.SubGroup.SubType).FullName.ToString();
            var result = RunCmdWithParameter(fullName: fullNameComplete);

            Assert.IsTrue(result.Count() == 1);
            var type = result.First();
            Assert.AreEqual(typeof(Mock.SubGroup.SubType).FullName, type.Name);
        }

        [TestMethod]
        public void GetTypesByFullNameOnlyName()
        {
            var name = typeof(Mock.SubGroup.SubType).Name.ToString();
            var result = RunCmdWithParameter(fullName: name);

            Assert.IsTrue(result.Count() == 1);
            var type = result.First();
            Assert.AreEqual(typeof(Mock.SubGroup.SubType).FullName, type.Name);
        }

        [TestMethod]
        public void GetTypesByBaseType()
        {
            var baseType = typeof(Mock.BaseType).FullName.ToString();
            var result = RunCmdWithParameter(baseType: baseType);

            Assert.IsTrue(result.Count() == 1);
            var type = result.First();
            Assert.AreEqual(typeof(Mock.SubGroup.SubType).FullName, type.Name);
        }
    }
}
