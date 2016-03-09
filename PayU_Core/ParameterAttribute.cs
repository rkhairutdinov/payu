using System;

namespace PayU_Core
{
    public class ParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsNested { get; set; }
        public string FormatString { get; set; }
        public bool ExcludeFromHash { get; set; }
        public int SortIndex { get; set; }
    }
}