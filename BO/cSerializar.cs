using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace BO
{
    public class cSerializar
    {
        public cSerializar()
        {
        }

        public string Serializar(belModulos vModulos, string vDiret, string vNomeArq)
        {
            string sXmlSerializer = null;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(
                new[] { new XmlQualifiedName("ns", "http://www.springframework.net"),
                new XmlQualifiedName("default-lazy-init", "true")});
            XmlSerializer xs = new XmlSerializer(typeof(belModulos));
            MemoryStream memory = new MemoryStream();
            XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
            xs.Serialize(xmltext, vModulos, ns);
            UTF8Encoding encoding = new UTF8Encoding();
            sXmlSerializer = encoding.GetString(memory.ToArray());
            sXmlSerializer = sXmlSerializer.Replace("ns:", "");
            sXmlSerializer = sXmlSerializer.Replace("xmldefault-lazy-init", "default-lazy-init");
            if (!Directory.Exists(vDiret))
            {
                Directory.CreateDirectory(vDiret);
            }
            File.Create(vDiret +@"\"+ vNomeArq + ".xml").Close();
            StreamWriter _sw = new StreamWriter(vDiret + vNomeArq + ".xml");
            _sw.Write(sXmlSerializer);
            _sw.Close();
            return vDiret + vNomeArq + ".xml";      
        }
                
    }
}
