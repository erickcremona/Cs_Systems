using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace CrossCutting
{
    public class ValidadorSchemaXml
    {
        private static string ErroValidadorXML;

        public static void Validar(string arquivoXML, string schemaXML)
        {
            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.ValidationType = ValidationType.Schema;
                xmlSettings.Schemas.Add(null, schemaXML);
                xmlSettings.ValidationEventHandler += new ValidationEventHandler(xmlSettingsValidationEventHandler);

                XmlReader xml = XmlReader.Create(arquivoXML, xmlSettings);
                ErroValidadorXML = string.Empty;
                while (xml.Read()) { }
                xml.Close();

                if (!string.IsNullOrEmpty(ErroValidadorXML))
                    throw new XmlSchemaException(ErroValidadorXML);
            }
            catch (XmlSchemaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void xmlSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                ErroValidadorXML += "Cuidado: \n" + e.Message + "\n";
            else if (e.Severity == XmlSeverityType.Error)
                ErroValidadorXML += "ERRO: \n" + e.Message + "\n";
            else
                ErroValidadorXML += "ERRO: \n" + e.Message + "\n";
        }
    }
}
