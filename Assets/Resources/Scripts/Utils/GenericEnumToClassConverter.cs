using System;

namespace Beathoven.Utils
{
    class GenericEnumToClassConverter<C, E>
    {
        private readonly string _assemblyPath;

        /// <param name="assemblyPath">Path in the format Beathoven.Core.Notes</param>
        public GenericEnumToClassConverter(string assemblyPath)
        {
            this._assemblyPath = assemblyPath;
        }

        public C EnumToClassInstance(E enumeration)
        {
            string className = Enum.GetName(typeof(E), enumeration);
            return (C)Activator.CreateInstance(Type.GetType(_assemblyPath + className));
        }
    }
}