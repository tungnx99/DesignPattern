using System.Xml;

namespace Applications.Implement.Interfaces.ConvertXMLToObject
{
    public interface IConvertXMLToObject
    {
        public T Convert<T>(string xmlString);
    }
}
