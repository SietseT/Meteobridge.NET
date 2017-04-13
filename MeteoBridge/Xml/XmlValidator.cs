using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MeteoBridge.Xml
{
    internal static class XmlValidator
    {
        internal static bool ValidMeteoBridgeData(this XDocument document)
        {                      
            var schema = new XmlSchemaSet();
            schema.Add("", XmlReader.Create(new StringReader(GetSchema())));

            //Validate
            bool error = false;
            document.Validate(schema, (o, e) =>
            {
                error = true;
            }, true);

            return error;
        }

        private static string GetSchema()
        {
            Assembly _assembly;
            StreamReader _textStreamReader;

            //Get XSD as Embedded Resource
            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("MeteoBridge.Xml.MeteoBridge.xsd"));
                return _textStreamReader.ReadToEnd();
            }
            catch
            {
                throw new Exception("Xml schema not found: MeteoBridge.xsd");
            }
        }

    }
}
