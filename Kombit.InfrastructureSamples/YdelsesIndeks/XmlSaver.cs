using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kombit.InfrastructureSamples.UnitTests
{
    public class XmlSaver
    {
        public static void SaveRequestAsXml(YdelseIndeksService.fremsoegRequest request, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(YdelseIndeksService.fremsoegRequest));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, request);
            }
        }
    }
}
