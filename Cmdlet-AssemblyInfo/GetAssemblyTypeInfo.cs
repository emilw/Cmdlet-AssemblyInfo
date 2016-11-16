using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using Mono.Cecil;

namespace Cmdlet_AssemblyInfo
{
    [Cmdlet(VerbsCommon.Get, "AssemblyTypes")]
    [OutputType(typeof(List<Type>))]
    public class GetAssemblyTypeInfo : Cmdlet
    {
        [Parameter(Position=1,Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string AssemblyPath { get; set; }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string FullNameFilter { get; set; } = "";

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public int MaxEntries { get; set; } = 100;

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public string Namespace { get; set; }

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true)]
        public string BaseTypeFilter { get; set; }

        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true)]
        public string Attribute { get; set; }
        protected override void ProcessRecord()
        {
            var assembly =
                AssemblyDefinition.ReadAssembly(AssemblyPath);

            var result = new List<Type>();
            List<TypeDefinition> types = assembly.MainModule.Types.ToList();

            if (!String.IsNullOrEmpty(Namespace))
            {
                types = types.Where(x => String.Equals(x.Namespace, Namespace, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            if (!String.IsNullOrEmpty(FullNameFilter))
            {
                types = types.Where(x => x.FullName.Contains(FullNameFilter)).ToList();
            }
            if (!String.IsNullOrEmpty(BaseTypeFilter))
            {
                types = types.Where(x => x.BaseType != null ? x.BaseType.FullName.Contains(BaseTypeFilter) : false).ToList();
            }

            if (!String.IsNullOrEmpty(Attribute))
            {
                types = types.Where(x => x.CustomAttributes.Any(y => y.AttributeType.FullName.Contains(Attribute))).ToList();
            }

            types.Take(MaxEntries).ToList().ForEach(x => result.Add(CreateType(x)));
            result.ForEach(WriteObject);

            if(MaxEntries == types.Count())
                WriteWarning("Please narrow the result with a more specific filter or change the MaxEntries parameter to get all results");
        }

        private Type CreateType(TypeDefinition typeDef)
        {
            var baseType = "";
            if (typeDef.BaseType != null)
                baseType = typeDef.BaseType.FullName;

            return Type.Create(typeDef.FullName, typeDef.Namespace, baseType);
        }
    }


    public class Type
    {
        public static Type Create(string name, string namespac, string baseType)
        {
            return new Type(name, namespac, baseType);
        }
        private Type(string name, string namespac, string baseType)
        {
            Name = name;
            Namespace = namespac;
            BaseType = baseType;
        }

        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public string BaseType { get; private set; }
    }
}
