namespace Dal.Settings
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;

    public sealed class SettingsFile
    {
        private static bool bool_0 = false;
        private static bool bool_1 = false;
        private static SettingsKey settingsKey_0;
        private const string string_0 = "The specified string parameter is null or empty.";
        private const string string_1 = "Could not Parse or Load the Settings File";
        private const string string_2 = "Settings";
        private const string string_3 = "Settings.xml";
        private static string string_4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\SettingsV2.xml";
        private static XmlDocument xmlDocument_0;

        private SettingsFile()
        {
        }

        public static void Create(string fileName)
        {
            string_4 = fileName;
            smethod_0();
        }

        private static void smethod_0()
        {
            if ((string_4 == null) | (string_4 == string.Empty))
            {
                smethod_2("fileName");
            }
            xmlDocument_0 = new XmlDocument();

            FileInfo info = new FileInfo(string_4);
            if (info.Exists)
            {
                try
                {
                    xmlDocument_0.Load(string_4);
                }
                catch (XmlException exception)
                {
                    smethod_3(exception);
                }
            }
            else
            {
                xmlDocument_0.AppendChild(xmlDocument_0.CreateElement("Settings"));
                settingsKey_0 = new SettingsKey(xmlDocument_0.DocumentElement, true);
            }
            info = null;
            settingsKey_0 = new SettingsKey(xmlDocument_0.DocumentElement, true);
            XmlNodeChangedEventHandler handler = new XmlNodeChangedEventHandler(SettingsFile.smethod_4);
            xmlDocument_0.NodeChanged += handler;
            xmlDocument_0.NodeInserted += handler;
            xmlDocument_0.NodeRemoved += handler;
            bool_1 = false;
            bool_0 = true;
        }

        internal static void smethod_1()
        {
            if (bool_1)
            {
                xmlDocument_0.Save(string_4);
            }
            bool_1 = false;
        }

        private static void smethod_2(string string_5)
        {
            throw new ArgumentNullException(string_5, "The specified string parameter is null or empty.");
        }

        private static void smethod_3(XmlException xmlException_0)
        {
            throw new SettingsFormatException("Could not Parse or Load the Settings File" + string_4, xmlException_0.LineNumber, xmlException_0.LinePosition, xmlException_0);
        }

        private static void smethod_4(object sender, XmlNodeChangedEventArgs e)
        {
            bool_1 = true;
        }

        public static void Update()
        {
            smethod_1();
        }

        public static void WriteTo(XmlWriter w)
        {
            xmlDocument_0.WriteTo(w);
        }

        public static SettingsKey Settings
        {
            get
            {
                if (!bool_0)
                {
                    smethod_0();
                }
                return settingsKey_0;
            }
        }
    }
}

