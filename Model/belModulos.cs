using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("objects")]
    public class belModulos
    {
        public belModulos()
        {
            lFormularios = new List<belFormularios>();
        }

        [System.Xml.Serialization.XmlElement("object")]
        public List<belFormularios> lFormularios { get; set; }
    }

    [System.Xml.Serialization.XmlRoot("object")]
    public class belFormularios
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public string xId { get; set; }

        [System.Xml.Serialization.XmlAttribute("name")]
        public string xName { get; set; }

        [System.Xml.Serialization.XmlAttribute("singleton")]
        public string stSingleton { get; set; }

        [System.Xml.Serialization.XmlAttribute("scope")]
        public string xScope { get; set; }

        [System.Xml.Serialization.XmlAttribute("type")]
        public string xType { get; set; }
    }
}
