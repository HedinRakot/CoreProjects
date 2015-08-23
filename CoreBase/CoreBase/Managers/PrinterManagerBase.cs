using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CoreBase.Managers
{
    public class PrinterManagerBase
    {
        private static Regex htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        #region Prepare Print

        private MemoryStream PreparePrintData(string path)
        {
            var result = new MemoryStream();
            try
            {
                Package pkg;
                PackagePart part;
                XmlReader xmlReader;
                XDocument xmlMainXMLDoc;
                GetXmlDoc(path, result, out pkg, out part, out xmlReader, out xmlMainXMLDoc);

                //replace fields
                var templateBody = ReplaceFields(xmlMainXMLDoc);

                xmlMainXMLDoc = SaveDoc(result, pkg, part, xmlReader, xmlMainXMLDoc, templateBody);
            }
            catch
            {
            }

            return result;
        }

        protected void GetXmlDoc(string path, MemoryStream result, out Package pkg, out PackagePart part, out XmlReader xmlReader, out XDocument xmlMainXMLDoc)
        {
            var fileStream = System.IO.File.Open(path, FileMode.Open);
            CopyStream(fileStream, result);
            fileStream.Close();

            pkg = Package.Open(result, FileMode.Open, FileAccess.ReadWrite);

            var uri = new Uri("/word/document.xml", UriKind.Relative);
            part = pkg.GetPart(uri);

            xmlReader = XmlReader.Create(part.GetStream(FileMode.Open, FileAccess.Read));
            xmlMainXMLDoc = XDocument.Load(xmlReader);
        }

        protected XDocument SaveDoc(MemoryStream result, Package pkg, PackagePart part, XmlReader xmlReader, XDocument xmlMainXMLDoc, string templateBody)
        {
            xmlMainXMLDoc = XDocument.Parse(templateBody);

            var partWrt = new StreamWriter(part.GetStream(FileMode.Open, FileAccess.ReadWrite));
            xmlMainXMLDoc.Save(partWrt);

            partWrt.Flush();
            partWrt.Close();
            pkg.Close();

            result.Position = 0;

            xmlReader.Close();
            return xmlMainXMLDoc;
        }

        protected void CopyStream(Stream source, Stream target)
        {
            source.Position = 0;

            int bytesRead;
            byte[] buffer = new byte[source.Length];

            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                target.Write(buffer, 0, bytesRead);
            }

            source.Position = 0;
        }

        #endregion

        #region Replace Fields Info

        protected virtual string ReplaceFields(XDocument xmlMainXMLDoc)
        {
            return xmlMainXMLDoc.Root.ToString();
        }

        #endregion

        #region Common Functions

        protected string ConvertToTimeString(DateTime date)
        {
            if (date != DateTime.MinValue && date != DateTime.MaxValue)
                return date.ToString("dd.MM.yyyy hh:mm");
            else
                return String.Empty;
        }

        protected XElement GetParentElementByName(XElement element, string name)
        {
            XElement result = null;

            while (true)
            {
                if (element == null || element.Parent == null)
                {
                    break;
                }
                else
                {
                    if (element.Parent.ToString().StartsWith(name))
                    {
                        result = element.Parent;
                        break;
                    }

                    element = element.Parent;
                }
            }

            return result;
        }

        protected XElement GetInnerElementByName(XElement element, string name)
        {
            XElement result = null;

            if (element != null && element.Elements() != null)
            {
                foreach (var item in element.Elements())
                {
                    if (item.ToString().StartsWith(name))
                    {
                        result = item;
                        break;
                    }
                }
            }

            return result;
        }

        protected string ReplaceFieldValue(string source, string fieldKey, string fieldValue)
        {
            if (String.IsNullOrEmpty(fieldValue))
            {
                fieldValue = String.Empty;
            }

            return source.Replace(fieldKey, htmlRegex.Replace(fieldValue, String.Empty).
                Replace("&", "&amp;").
                Replace("<", "&lt;").
                Replace(">", "&gt;").
                Replace("\"", "&quot;").
                Replace("'", "&apos;"));
        }

        #endregion
    }
}
