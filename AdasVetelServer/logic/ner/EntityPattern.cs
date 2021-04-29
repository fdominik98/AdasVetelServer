using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdasVetelServer.logic.ner
{
    [XmlRoot("EntityPattern")]
    public class EntityPattern
    {
        [XmlAttribute("OnlyPattern")]
        public bool OnlyPattern { get; set; } = false;

        [XmlAttribute("PatternCaseInsensitive")]
        public bool PatternCaseInsensitive { get; set; } = false;

        [XmlAttribute("PatternLargestIndex")]
        public bool PatternLargestIndex { get; set; } = false;

        [XmlArray("Patterns")]
        public List<string> Patterns { get; set; } = new List<string>();
        [XmlArray("ContextsBefore")]
        public List<string> ContextsBefore { get; set; } = new List<string>();
        [XmlArray("ContextsAfter")]
        public List<string> ContextsAfter { get; set; } = new List<string>();
        [XmlArray("InvalidsBefore")]
        public List<string> InvalidsBefore { get; set; } = new List<string>();
        [XmlArray("InvalidsAfter")]
        public List<string> InvalidsAfter { get; set; } = new List<string>();

        public void save(string filename)
        {
            using (var stream = new StreamWriter(new FileStream(filename, FileMode.Create),Encoding.UTF8))
            {
                makeUnique();
                var XML = new XmlSerializer(typeof(EntityPattern));
                XML.Serialize(stream, this);
            }
        }
        public static EntityPattern load(string filename)
        {
            using (var stream = new StreamReader(new FileStream(filename, FileMode.Open), Encoding.UTF8))
            {
                var XML = new XmlSerializer(typeof(EntityPattern));
               return (EntityPattern)XML.Deserialize(stream);
            }
        }
        public bool isEmpty()
        {
            if (!OnlyPattern) { 
                return ContextsAfter.Count == 0 && ContextsBefore.Count == 0
                && InvalidsAfter.Count == 0 && InvalidsBefore.Count == 0;
            }
            return false;
        }
        private void makeUnique()
        {
            Patterns = Patterns.Distinct().ToList();
            ContextsAfter = ContextsAfter.Distinct().ToList(); ;
            ContextsBefore = ContextsBefore.Distinct().ToList(); ;
            InvalidsAfter = InvalidsAfter.Distinct().ToList(); ;
            InvalidsBefore = InvalidsBefore.Distinct().ToList();
            Patterns.Remove("");
            ContextsAfter.Remove("");
            ContextsBefore.Remove("");
            InvalidsAfter.Remove("");
            InvalidsBefore.Remove("");
        }
    }
}
