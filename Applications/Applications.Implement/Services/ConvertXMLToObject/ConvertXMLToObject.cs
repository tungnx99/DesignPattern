using Applications.Implement.Interfaces.ConvertXMLToObject;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Applications.Implement.Services.ConvertXMLToObject
{
    public class ConvertXMLToObject : IConvertXMLToObject
    {
        public T Convert<T>(string xmlString)
        {
            T result = default(T);

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xmlString))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
