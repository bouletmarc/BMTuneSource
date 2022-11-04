namespace Dal.Settings
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Reflection;
    using System.Text;
    using System.Xml;

    public sealed class SettingsKey : IDisposable
    {
        internal bool bool_0;
        private const char char_0 = ',';
        private const char char_1 = '}';
        private const char char_2 = ',';
        private const char char_3 = '}';
        private const char char_4 = ']';
        private const string string_0 = "The specified string parameter is null or empty.";
        private const string string_1 = "The current Settings.Key is the Root Settings.Key or read-only.";
        private const string string_10 = "COLOR[";
        private const string string_11 = "RGB[";
        private const string string_2 = "The specified paramter is not a valid reference to a Settings.Key.";
        private const string string_3 = "The specified paramter is not a valid reference to a setting.";
        private const string string_4 = "The specified Settings.Key has subkeys.Cannot delete a Settings.Key with  subkeys. To delete a Settings.Key that has  subkeys use the DeleteSettings.KeyTree method.";
        private const string string_5 = "{X=";
        private const string string_6 = "Y=";
        private const string string_7 = "{Width=";
        private const string string_8 = " Height=";
        private const string string_9 = "Color could not be parsed";
        private XmlElement xmlElement_0;

        private SettingsKey()
        {
            this.bool_0 = true;
        }

        internal SettingsKey(XmlElement data, bool isReadOnly)
        {
            this.bool_0 = true;
            this.xmlElement_0 = data;
            this.bool_0 = isReadOnly;
        }

        public SettingsKey CreateSubKey(string subkeyName)
        {
            XmlElement element2;
            subkeyName = subkeyName.Trim();
            subkeyName = subkeyName.TrimStart(new char[] { '/' });
            subkeyName = subkeyName.TrimEnd(new char[] { '/' });
            string innerXml = this.xmlElement_0.InnerXml;
            if ((subkeyName == null) || (subkeyName == string.Empty))
            {
                this.method_2("subkeyName");
            }
            string[] strArray = subkeyName.Split(new char[] { '/' });
            XmlElement data = this.xmlElement_0;
            int index = 0;
            while ((element2 = data[strArray[index].Trim()]) != null)
            {
                data = element2;
                index++;
                if (index == strArray.Length)
                {
                    return new SettingsKey(data, false);
                }
            }
            for (int i = index; i < strArray.Length; i++)
            {
                try
                {
                    data = (XmlElement) data.AppendChild(data.OwnerDocument.CreateElement(strArray[i].Trim()));
                }
                catch
                {
                    this.xmlElement_0.InnerXml = innerXml;
                    return null;
                }
            }
            return new SettingsKey(data, false);
        }

        public void DeleteSetting(string settingName)
        {
            this.DeleteSetting(settingName, true);
        }

        public void DeleteSetting(string settingName, bool throwOnMissingValue)
        {
            if (this.bool_0)
            {
                this.method_3();
            }
            if ((settingName == null) || (settingName == string.Empty))
            {
                this.method_2("name");
            }
            if (!this.xmlElement_0.HasAttribute(settingName) & throwOnMissingValue)
            {
                this.method_4("name", settingName);
            }
            if (this.xmlElement_0.HasAttribute(settingName))
            {
                this.xmlElement_0.RemoveAttribute(settingName);
            }
        }

        public void DeleteSettingKeyTree(string subkeyName)
        {
            this.method_7(subkeyName, true, true);
        }

        public void DeleteSubKey(string subkeyName)
        {
            this.DeleteSubKey(subkeyName, true);
        }

        public void DeleteSubKey(string subkeyName, bool throwOnMissingSubkey)
        {
            this.method_7(subkeyName, throwOnMissingSubkey, false);
        }

        ~SettingsKey()
        {
        }

        public Color GetColor(string settingName, Color defaultSetting)
        {
            Color color;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Color.Empty) StoreColor(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            try
            {
                color = this.method_10(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Color.Empty) StoreColor(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            return color;
        }

        public Point GetPoint(string settingName, Point defaultSetting)
        {
            Point point;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Point.Empty) StorePoint(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            try
            {
                point = this.method_8(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Point.Empty) StorePoint(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            return point;
        }

        public string GetSetting(string settingName)
        {
            if ((settingName == null) || (settingName == string.Empty))
            {
                this.method_2("name");
            }
            if (!this.xmlElement_0.HasAttribute(settingName))
            {
                this.method_5("name", settingName);
            }
            return this.xmlElement_0.Attributes[settingName].Value;
        }

        public bool GetSetting(string settingName, bool defaultSetting)
        {
            bool flag = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return flag;
            }
            try
            {
                if (setting == "True") setting = "true";
                if (setting == "False") setting = "false";
                return XmlConvert.ToBoolean(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public byte GetSetting(string settingName, byte defaultSetting)
        {
            byte num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToByte(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public char GetSetting(string settingName, char defaultSetting)
        {
            char ch = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return ch;
            }
            try
            {
                return XmlConvert.ToChar(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public DateTime GetSetting(string settingName, DateTime defaultSetting)
        {
            DateTime time = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return time;
            }
            try
            {
                return XmlConvert.ToDateTime(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public decimal GetSetting(string settingName, decimal defaultSetting)
        {
            decimal num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToDecimal(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public double GetSetting(string settingName, double defaultSetting)
        {
            double num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToDouble(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public Guid GetSetting(string settingName, Guid defaultSetting)
        {
            Guid guid = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Guid.Empty) StoreSetting(settingName, defaultSetting);
                }
                return guid;
            }
            try
            {
                return XmlConvert.ToGuid(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Guid.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public short GetSetting(string settingName, short defaultSetting)
        {
            short num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToInt16(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public int GetSetting(string settingName, int defaultSetting)
        {
            int num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToInt32(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public long GetSetting(string settingName, long defaultSetting)
        {
            long num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToInt64(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public float GetSetting(string settingName, float defaultSetting)
        {
            float num = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return num;
            }
            try
            {
                return XmlConvert.ToSingle(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public string GetSetting(string settingName, string defaultSetting)
        {
            string setting;
            try
            {
                setting = this.GetSetting(settingName);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                setting = defaultSetting;
            }
            return setting;
        }

        public TimeSpan GetSetting(string settingName, TimeSpan defaultSetting)
        {
            TimeSpan span = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return span;
            }
            try
            {
                return XmlConvert.ToTimeSpan(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public DateTime GetSetting(string settingName, DateTime defaultSetting, string format)
        {
            DateTime time = defaultSetting;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return time;
            }
            try
            {
                return XmlConvert.ToDateTime(setting, format);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty) StoreSetting(settingName, defaultSetting);
                }
                return defaultSetting;
            }
        }

        public string[] GetSettingNames()
        {
            string[] strArray = new string[this.xmlElement_0.Attributes.Count];
            int index = 0;
            IEnumerator enumerator = this.xmlElement_0.Attributes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XmlAttribute current = (XmlAttribute) enumerator.Current;
                strArray[index] = current.Name;
                index++;
            }
            return strArray;
        }

        public Size GetSize(string settingName, Size defaultSetting)
        {
            Size size;
            string setting = this.GetSetting(settingName, string.Empty);
            if (!(setting != string.Empty))
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Size.Empty) StoreSize(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            try
            {
                size = this.method_9(setting);
            }
            catch
            {
                if (settingName != null && defaultSetting != null)
                {
                    if (settingName != string.Empty && defaultSetting != Size.Empty) StoreSize(settingName, defaultSetting);
                }
                return defaultSetting;
            }
            return size;
        }

        public string[] GetSubKeyNames()
        {
            string[] strArray = new string[this.xmlElement_0.ChildNodes.Count];
            int index = 0;
            IEnumerator enumerator = this.xmlElement_0.ChildNodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XmlElement current = (XmlElement) enumerator.Current;
                strArray[index] = current.Name;
                index++;
            }
            return strArray;
        }

        internal DateTime method_0(string string_12, DateTime dateTime_0, string[] string_13)
        {
            DateTime time = dateTime_0;
            string setting = this.GetSetting(string_12, string.Empty);
            if (!(setting != string.Empty))
            {
                return time;
            }
            try
            {
                return XmlConvert.ToDateTime(setting, string_13);
            }
            catch
            {
                return dateTime_0;
            }
        }

        private bool method_1(string string_12, ref bool bool_1)
        {
            bool flag;
            string setting = this.GetSetting(string_12, string.Empty);
            if (!(setting != string.Empty))
            {
                return false;
            }
            try
            {
                flag = XmlConvert.ToBoolean(setting);
            }
            catch
            {
                return false;
            }
            bool_1 = flag;
            return true;
        }

        private Color method_10(string string_12)
        {
            if (string_12.StartsWith("COLOR["))
            {
                try
                {
                    return this.method_11(string_12);
                }
                catch
                {
                    throw;
                }
            }
            if (string_12.StartsWith("RGB["))
            {
                try
                {
                    return this.method_12(string_12);
                }
                catch
                {
                    throw;
                }
            }
            throw new ArgumentException("Color could not be parsed", "colorString");
        }

        private Color method_11(string string_12)
        {
            string str = string_12.Substring(string_12.IndexOf('[') + 1);
            str = str.Remove(str.Length - 1);
            KnownColor color = (KnownColor)Enum.Parse(typeof(KnownColor), str, true);
            return Color.FromKnownColor(color);
        }

        private Color method_12(string string_12)
        {
            char[] trimChars = "RGB[".ToCharArray();
            return Color.FromArgb(int.Parse(string_12.TrimStart(trimChars).Trim(new char[] { ']' })));
        }

        private void method_2(string string_12)
        {
            throw new ArgumentNullException(string_12, "The specified string parameter is null or empty.");
        }

        private void method_3()
        {
            throw new UnauthorizedAccessException("The current SettingsKey is the Root SettingsKey or read-only.");
        }

        private void method_4(string string_12, string Parameter)
        {
            throw new ArgumentException("The specified parameter '" + Parameter + "' is not a valid reference to a setting.", string_12);
        }

        private void method_5(string string_12, string Parameter)
        {
            throw new ArgumentException("The specified parameter '" + Parameter + "' is not a valid reference to a SettingsKey.", string_12);
        }

        private void method_6()
        {
            throw new InvalidOperationException("The specified SettingsKey has subkeys.Cannot delete a SettingsKey with  subkeys. To delete a SettingsKey that has  subkeys use the DeleteSettingsKeyTree method.");
        }

        private void method_7(string string_12, bool bool_1, bool bool_2)
        {
            if (this.bool_0)
            {
                this.method_3();
            }
            if ((string_12 == null) || (string_12 == string.Empty))
            {
                this.method_2("subkeyName");
            }
            if (this.xmlElement_0[string_12] == null)
            {
                if (!bool_1)
                {
                    return;
                }
                this.method_5("subkeyName", string_12);
            }
            if (!bool_2 && ((this.xmlElement_0[string_12] != null) & this.xmlElement_0[string_12].HasChildNodes))
            {
                this.method_6();
            }
            if (this.xmlElement_0[string_12] != null)
            {
                this.xmlElement_0.RemoveChild(this.xmlElement_0[string_12]);
            }
        }

        private Point method_8(string string_12)
        {
            Point point = new Point();
            char[] trimChars = "{X=".ToCharArray();
            char[] chArray2 = "Y=".ToCharArray();
            string[] strArray = string_12.Split(new char[] { ',' });
            string s = strArray[0].TrimStart(trimChars);
            point.X = int.Parse(s);
            string str2 = strArray[1].TrimStart(chArray2);
            point.Y = int.Parse(str2.Trim(new char[] { '}' }));
            return point;
        }

        private Size method_9(string string_12)
        {
            Size size = new Size();
            char[] trimChars = "{Width=".ToCharArray();
            char[] chArray2 = " Height=".ToCharArray();
            string[] strArray = string_12.Split(new char[] { ',' });
            size.Width = int.Parse(strArray[0].Trim(trimChars));
            string str = strArray[1].Trim(chArray2);
            size.Height = int.Parse(str.Trim(new char[] { '}' }));
            return size;
        }

        public SettingsKey OpenSubKey(string subkeyName)
        {
            return this.OpenSubKey(subkeyName, false);
        }

        public SettingsKey OpenSubKey(string subkeyName, bool writable)
        {
            if ((subkeyName == null) || (subkeyName == string.Empty))
            {
                this.method_2("subkeyName");
            }
            if (this.xmlElement_0[subkeyName] != null)
            {
                return new SettingsKey(this.xmlElement_0[subkeyName], !writable);
            }
            return null;
        }

        public void StoreColor(string settingName, Color settingValue)
        {
            settingName = XmlConvert.EncodeName(settingName);
            if (settingValue.IsEmpty)
            {
                this.method_2("setting");
            }
            if (settingValue.IsKnownColor)
            {
                StringBuilder builder = new StringBuilder(settingValue.ToKnownColor().ToString());
                builder.Insert(0, "COLOR[");
                builder.Append(']');
                this.StoreSetting(settingName, builder.ToString());
            }
            else
            {
                StringBuilder builder2 = new StringBuilder(settingValue.ToArgb().ToString());
                builder2.Insert(0, "RGB[");
                builder2.Append(']');
                this.StoreSetting(settingName, builder2.ToString());
            }
        }

        public void StorePoint(string settingName, Point settingValue)
        {
            this.StoreSetting(settingName, settingValue.ToString());
        }

        public void StoreSetting(string settingName, bool settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, byte settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, char settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, DateTime settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, decimal settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, double settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, Guid settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, short settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, int settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, long settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, float settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, string settingValue)
        {
            if (this.bool_0)
            {
                this.method_3();
            }
            if ((settingName == null) || (settingName == string.Empty))
            {
                this.method_2("settingName");
            }
            if ((settingValue == null) || (settingValue == string.Empty))
            {
                this.method_2("setting");
            }
            this.xmlElement_0.SetAttribute(settingName, settingValue);
        }

        public void StoreSetting(string settingName, TimeSpan settingValue)
        {
            string str = XmlConvert.ToString(settingValue);
            this.StoreSetting(settingName, str);
        }

        public void StoreSetting(string settingName, DateTime settingValue, string format)
        {
            string str = XmlConvert.ToString(settingValue, format);
            this.StoreSetting(settingName, str);
        }

        public void StoreSize(string settingName, Size settingValue)
        {
            this.StoreSetting(settingName, settingValue.ToString());
        }

        void IDisposable.Dispose()
        {
        }

        public override string ToString()
        {
            return this.FullName;
        }

        public string ToXml()
        {
            return this.xmlElement_0.OuterXml;
        }

        public string FullName
        {
            get
            {
                if (this.xmlElement_0 == SettingsFile.Settings.xmlElement_0)
                {
                    return ("/" + this.xmlElement_0.Name);
                }
                if (((XmlElement) this.xmlElement_0.ParentNode) == null)
                {
                    return this.xmlElement_0.Name;
                }
                SettingsKey key = new SettingsKey((XmlElement) this.xmlElement_0.ParentNode, true);
                return (key.FullName + "/" + this.xmlElement_0.Name);
            }
        }

        public SettingsKey this[string path]
        {
            get
            {
                return this.CreateSubKey(path);
            }
        }

        public string Name
        {
            get
            {
                return this.xmlElement_0.Name;
            }
        }

        public int SettingsCount
        {
            get
            {
                return this.xmlElement_0.Attributes.Count;
            }
        }

        public int SubKeyCount
        {
            get
            {
                return this.xmlElement_0.ChildNodes.Count;
            }
        }
    }
}

