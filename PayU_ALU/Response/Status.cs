using System.Xml.Serialization;

namespace PayU_ALU
{
    public enum Status
    {
        [XmlEnum("SUCCESS")]
        Success,
        [XmlEnum("FAILED")]
        Failed,
        [XmlEnum("INPUT_ERROR")]
        InputError
    }
}