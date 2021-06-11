namespace Kombit.InfrastructureSamples.SagDokumentIndeksService {
    /// <summary>
    /// Add-on class to use LokalUdvidelseLists. It originally comes with an 'any' property of the type XmlElement, but we want objects.
    /// The types of objects we want to serialize are defined above the Udvidelse property.
    /// </summary>
    public partial class LokalUdvidelseListeType {
        
        private object[] udvidelseField;

        [System.Xml.Serialization.XmlElement("SagIndeksEgenskaber", typeof(EgenskaberTypeSag), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("SagsaktoerLokalUdvidelse", typeof(SagsaktoerLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("SagspartLokalUdvidelse", typeof(SagspartLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("SagsklasseLokalUdvidelse", typeof(SagsklasseLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("SagsgenstandeLokalUdvidelse", typeof(SagsgenstandeLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("SagsitsystemRelation", typeof(SagsitsystemRelationType), Order = 1, Namespace = "urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("DokumentaktoerLokalUdvidelse", typeof(DokumentaktoerLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("DokumentklasseLokalUdvidelse", typeof(DokumentklasseLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
        [System.Xml.Serialization.XmlElement("DokumentpartLokalUdvidelse", typeof(DokumentpartLokalUdvidelseType), Order = 1, Namespace = "urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]

        public object[] Udvidelse {
            get {
                return udvidelseField;
            }
            set {
                udvidelseField = value;
            }
        }
    }
}
