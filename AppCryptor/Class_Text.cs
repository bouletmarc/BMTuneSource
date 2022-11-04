using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCryptor
{
    public class Class_Text
    {
        public List<string> CryptedTextStr;
        public List<string> CryptedTextStrUpper;
        public List<string> CryptedTextStrNumber;

        public List<string> NotCryptedText;
        public List<string> NotCryptedClassList;
        public List<string> NotCryptedClassListCrypted;


        public List<string> CryptedTextAllString;
        public List<string> CryptedTextAllNumber;

        Random rnd = new Random();

        Form1 form1_0;

        public Class_Text(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        public void CreateList()
        {
            if (NotCryptedClassList != null) NotCryptedClassList.Clear();
            NotCryptedClassList = new List<string>();
            if (NotCryptedClassListCrypted != null) NotCryptedClassListCrypted.Clear();
            NotCryptedClassListCrypted = new List<string>();

            if (CryptedTextAllString != null) CryptedTextAllString.Clear();
            CryptedTextAllString = new List<string>();
            if (CryptedTextAllNumber != null) CryptedTextAllNumber.Clear();
            CryptedTextAllNumber = new List<string>();

            if (NotCryptedText != null) NotCryptedText.Clear();
            NotCryptedText = new List<string>();
            NotCryptedText.Add("private");
            NotCryptedText.Add("public");
            NotCryptedText.Add("internal");
            NotCryptedText.Add("ref");
            NotCryptedText.Add("class");
            NotCryptedText.Add("InitializeComponent");
            NotCryptedText.Add("this");
            NotCryptedText.Add("This");
            NotCryptedText.Add("LogThis");
             //NotCryptedText.Add("Files");
             NotCryptedText.Add("");
            NotCryptedText.Add("for");
            NotCryptedText.Add("BackgroundWorker");
            NotCryptedText.Add("DateTime");
            NotCryptedText.Add("IntPtr");
            NotCryptedText.Add("float");
            NotCryptedText.Add("float[]");
            NotCryptedText.Add("float[,]");
            NotCryptedText.Add("string");
            NotCryptedText.Add("string[]");
            NotCryptedText.Add("string[,]");
            NotCryptedText.Add("bool");
            NotCryptedText.Add("bool[]");
            NotCryptedText.Add("bool[,]");
            NotCryptedText.Add("int");
            NotCryptedText.Add("int[]");
            NotCryptedText.Add("int[,]");
            NotCryptedText.Add("long");
            NotCryptedText.Add("long[]");
            NotCryptedText.Add("long[,]");
            NotCryptedText.Add("byte");
            NotCryptedText.Add("byte[]");
            NotCryptedText.Add("byte[,]");
            NotCryptedText.Add("double");
            NotCryptedText.Add("double[]");
            NotCryptedText.Add("double[,]");
            NotCryptedText.Add("List<string>");
            NotCryptedText.Add("List<bool>");
            NotCryptedText.Add("List<int>");
            NotCryptedText.Add("List<long>");
            NotCryptedText.Add("List<byte>");
            NotCryptedText.Add("List<double>");
            NotCryptedText.Add("List<string[]>");
            NotCryptedText.Add("List<bool[]>");
            NotCryptedText.Add("List<int[]>");
            NotCryptedText.Add("List<long[]>");
            NotCryptedText.Add("List<byte[]>");
            NotCryptedText.Add("List<double[]>");
            NotCryptedText.Add("void");
            NotCryptedText.Add("ProcessStartInfo");
            NotCryptedText.Add("WindowsIdentity");
            NotCryptedText.Add("WindowsPrincipal");
            NotCryptedText.Add("MD5CryptoServiceProvider");
            NotCryptedText.Add("Process");
            NotCryptedText.Add("RegistryPermission");
            NotCryptedText.Add("var");
            NotCryptedText.Add("StreamReader");
            NotCryptedText.Add("StreamWriter");
            NotCryptedText.Add("ManagementClass");
            NotCryptedText.Add("ManagementObjectCollection");
            NotCryptedText.Add("ManagementObject");
            NotCryptedText.Add("DialogResult");
            NotCryptedText.Add("ToolStripMenuItem");
            NotCryptedText.Add("IContainer");
            NotCryptedText.Add("MenuStrip");
            NotCryptedText.Add("ToolStripPanel");
            NotCryptedText.Add("ToolStripSeparator");
            NotCryptedText.Add("ToolTip");
            NotCryptedText.Add("TrackBar");
            NotCryptedText.Add("System.Windows.Forms.Timer");
            NotCryptedText.Add("FormWindowState");
            NotCryptedText.Add("SplitContainer");
            NotCryptedText.Add("TabControl");
            NotCryptedText.Add("TabPage");
            NotCryptedText.Add("PageSetupDialog");
            NotCryptedText.Add("StatusStrip");
            NotCryptedText.Add("ToolStripProgressBar");
            NotCryptedText.Add("ToolStripStatusLabel");
            NotCryptedText.Add("ToolStripButton");
            NotCryptedText.Add("ToolStrip");
            NotCryptedText.Add("ToolStripDropDownButton");
            NotCryptedText.Add("ToolStripSplitButton");
            NotCryptedText.Add("Button");
            NotCryptedText.Add("CheckBox");
            NotCryptedText.Add("ComboBox");
            NotCryptedText.Add("ColorDialog");
            NotCryptedText.Add("ErrorProvider");
            NotCryptedText.Add("FontDialog");
            NotCryptedText.Add("GroupBox");
            NotCryptedText.Add("Label");
            NotCryptedText.Add("RadioButton");
            NotCryptedText.Add("TextBox");
            NotCryptedText.Add("DataGridView");
            NotCryptedText.Add("DataGridViewTextBoxColumn");
            NotCryptedText.Add("Color");
            NotCryptedText.Add("PictureBox");
            NotCryptedText.Add("OpenFileDialog");
            NotCryptedText.Add("SaveFileDialog");
            NotCryptedText.Add("NumericUpDown");
            NotCryptedText.Add("delegate");
            NotCryptedText.Add("Delegate");
            NotCryptedText.Add("Main");
            NotCryptedText.Add("=");
            NotCryptedText.Add("FileInfo");
            NotCryptedText.Add("new");
            NotCryptedText.Add("Path");
            NotCryptedText.Add("DirectoryInfo");
            NotCryptedText.Add("DirectoryInfo[]");
            NotCryptedText.Add("Directory");
            NotCryptedText.Add("enum");
            NotCryptedText.Add("DoNotObfuscate");
            NotCryptedText.Add("Attribute");
            NotCryptedText.Add(":");
            NotCryptedText.Add("Form");
            NotCryptedText.Add("namespace");
            NotCryptedText.Add("Serializable");
            NotCryptedText.Add("using");
            NotCryptedText.Add("Settings");
            NotCryptedText.Add("Enum");
            NotCryptedText.Add("Enum0");
            NotCryptedText.Add("Enum1");
            NotCryptedText.Add("Enum2");
            NotCryptedText.Add("Enum3");
            NotCryptedText.Add("Enum4");
            NotCryptedText.Add("Enum5");
            NotCryptedText.Add("Enum6");
            NotCryptedText.Add("Enum7");
            NotCryptedText.Add("Enum8");
            NotCryptedText.Add("Enum9");
            NotCryptedText.Add("Enum10");
            NotCryptedText.Add("buffer");
            NotCryptedText.Add("Buffer");
            NotCryptedText.Add("Index");
            NotCryptedText.Add("Array");
            NotCryptedText.Add("to");
            //NotCryptedText.Add("To");
            NotCryptedText.Add("from");
            NotCryptedText.Add("Version");
            NotCryptedText.Add("convertion");
            //NotCryptedText.Add("convertion!");
            //NotCryptedText.Add(@"convertion!""");
            NotCryptedText.Add("and");
            NotCryptedText.Add("convert");
            NotCryptedText.Add("Convert");
            NotCryptedText.Add("lower");
            NotCryptedText.Add("the");
            NotCryptedText.Add("if");
            NotCryptedText.Add("long_0");
            NotCryptedText.Add("long_1");
            NotCryptedText.Add("StructLayout(LayoutKind.Sequential)");
            NotCryptedText.Add("struct");
            NotCryptedText.Add("ushort");
            NotCryptedText.Add("demon");
            NotCryptedText.Add("ostrich");
            NotCryptedText.Add("try");
            NotCryptedText.Add("catch");
            NotCryptedText.Add("static");
            NotCryptedText.Add("STAThread");
            NotCryptedText.Add("RegistryKey");
            NotCryptedText.Add("Text");
            NotCryptedText.Add("Enabled");
            NotCryptedText.Add("Visible");
            NotCryptedText.Add("Application");
            NotCryptedText.Add("EnableVisualStyles");
            NotCryptedText.Add("Run");
            NotCryptedText.Add("MessageBox");
            NotCryptedText.Add("Show");
            NotCryptedText.Add("ShowDialog");
            NotCryptedText.Add("DialogResult");
            NotCryptedText.Add("Environment");
            NotCryptedText.Add("Newline");
            NotCryptedText.Add("GetEnvironmentVariable");
            NotCryptedText.Add("Exit");
            NotCryptedText.Add("Quit");
            NotCryptedText.Add("Clear");
            NotCryptedText.Add("BMTune");
            NotCryptedText.Add("WebClient");
            NotCryptedText.Add("Dev");
            NotCryptedText.Add("Tuner");
            NotCryptedText.Add("datalogger");
            NotCryptedText.Add("Tuner");
            NotCryptedText.Add("Free");
            /*NotCryptedText.Add("0");
            NotCryptedText.Add("1");
            NotCryptedText.Add("2");
            NotCryptedText.Add("3");
            NotCryptedText.Add("4");
            NotCryptedText.Add("5");
            NotCryptedText.Add("6");
            NotCryptedText.Add("7");
            NotCryptedText.Add("8");
            NotCryptedText.Add("9");*/
            //NotCryptedText.Add("");


            if (CryptedTextStr != null) CryptedTextStr.Clear();
            CryptedTextStr = new List<string>();
            //CryptedTextStr.Add("a");
            //CryptedTextStr.Add("ā͆ͣ̚͘͜");
            CryptedTextStr.Add("b̸̵̝̘͍̪̫̘̩̙̺̜͓̺̈́̌̒̈ͭ");
            CryptedTextStr.Add("c̨̛̥͈̞̺͔̞̼ͧ͆̈̾̐͋̎̚͜͝ͅ");
            CryptedTextStr.Add("d̷̢͈̣͇͙̤̦̟̱̺̩̦͎̞̬̤̪̖̿ͨͪ̈́̓̏ͫͫ̌͆̎̌ͦ̄̈̔̚̚͟");
            CryptedTextStr.Add("e̛̒͂͌̓ͣͬ͗̉ͣͬ͆̃̒͂");
            CryptedTextStr.Add("f̸̡͈͍̳̯̖̣̱͊͊͋̂̚̚");
            CryptedTextStr.Add("ǧ̴̵̡̼͎̻̝̲̹̲̖͂̐̿̆ͪ̎̍͒̿̓̂͘͟");
            CryptedTextStr.Add("ẖ̸̵̢̢̝̥̬̯̯̼͊̏̋ͩͨͫͪ̆̍ͦ̒̾͋̐̉̈ͥ̏ͥ͡");
            CryptedTextStr.Add("i̶̸̧̪͙͓̯̠̱̝̤͇̅̆͑ͮͭͮ̽͢͜");
            CryptedTextStr.Add("j̧̡͕̮̘͕̞̹̤̾̇ͤ͂͐͊ͦͮ͟͠");
            CryptedTextStr.Add("k̶̼̰̘̲̪͎̲̟͇̰̪̪̗̅́ͤ͐͗͑͑͐̓̊͑ͯ̒̊̎ͮ̆̚̕");
            CryptedTextStr.Add("l̴͚͎̙̻͎̟̩͓͕̜̀̉̓̀͛̿ͣ̆̿̊̃ͨ̄̇̔̀ͣ̒ͣ");
            CryptedTextStr.Add("m̨̫͈̣̦̼̱̦͓͈̲͙̫͈͔̞̟͙̠̲͑͑ͦͦ͛ͧ̓̕͝");
            CryptedTextStr.Add("n̑̆͑͋͆̏̊ͭͫ̾ͭ̇ͩ̒̒ͩ̏̚̕");
            CryptedTextStr.Add("o̭͖̘͙̹͎̦̮̪̠̓ͦ̅̒ͣ̑ͬ̓ͪ̊ͫͤͭ̕͜͠ͅ");
            CryptedTextStr.Add("p̷̨̧͇̗̩͉̲̱̙̬̖̜̝̤̻̱̝̮͕̯͑̒̍͋ͦ̊͘");
            CryptedTextStr.Add("q́͐ͤ̄̃͌͗̔ͯ̈́̀̀͏͈͕͍̲͓̜̳̲̤̪̱̞̣̼͙̩̯̘");
            //CryptedTextStr.Add("r");
            //CryptedTextStr.Add("r̶̵̲̗̥̘̠̭̳̭͓̫̜̹͓̝̟͙̋͑̒ͪ̌ͮ̐ͧ̈ͤ͠");
            CryptedTextStr.Add("s̶̡̺̙̪̣͎̟͉̟̥̜͈̯̳̪̀̑͐́̇ͩͥ̑ͪ̔ͪ͂ͤ̐̾̈́͑̄͘̕͡");
            CryptedTextStr.Add("ţ̶̝͖͓̟̝̳̻̱͖̟͙̜̬̳̯̤ͨ̓̂́ͯ̾͒ͫ̿̇͐ͪͩ͐͋ͬ͑̄̚͢͞");
            CryptedTextStr.Add("u̶̠̘̗̻̼͓̤͓̦̯̝̹̳̺̹͗̽̑̇͌ͯ͐͌̿ͤ͢ͅ");
            CryptedTextStr.Add("v̸́͛̓͛͌̅ͯ͌ͮ̆͊ͦ̂̇ͯͪͫ͏̷̙̻̖");
            CryptedTextStr.Add("ẅ̴̶̷̡͎̭̺͙͚̤͒͑͆ͣͥͫ͊ͯ̈̒͛̚͟");
            CryptedTextStr.Add("x̗̟̬͔̤̻̟̎ͥ̀̅͑ͨͥ͌ͣ̍̑̽ͤ̇̿̈́̈́ͬ͘͝ͅ");
            CryptedTextStr.Add("y͍͔̬̫͙̝̼͎̭͔̥̻̩̺͎̤̻̤̑ͫ̃ͫ̀̍̿̎̄͐͌͌͢");
            CryptedTextStr.Add("z̴͓͍̗̥̤͌ͬ̑̓̈́͋̏̽̐̋͌͛̾ͮ̾̕͢͝");

            if (CryptedTextStrUpper != null) CryptedTextStrUpper.Clear();
            CryptedTextStrUpper = new List<string>();
            CryptedTextStrUpper.Add("Å̷̢̰̺̻̟͕̫̱̯͔̫̯͕̪̘͉̬ͯ̄ͭ̄ͫ̀ͯ");
            CryptedTextStrUpper.Add("B̴̩͇̫͙͆ͭͣ͌͑̂ͬͮ̈̄̔ͨ̏̑ͨ͊͆͂́͝");
            CryptedTextStrUpper.Add("Ç̧̻̠͈͈͕̞̥̭̦̳̯͈̤̲̈́͗͐̆́͊̍̀̑̾̇ͤͭ̍ͫ̽͘");
            CryptedTextStrUpper.Add("Ḏ̛̥̘̟͎̹͍͖̩̳̾̽ͮ̾ͫ̿̓͆́ͨͮͦͩ͌̀̚");
            CryptedTextStrUpper.Add("E̺̳̭͚̣̠̳̹̩̝̹̝̺̳̬̙̥̙̹ͭ̽͛̉ͭ͋̊̚͢");
            CryptedTextStrUpper.Add("F̡̝̭̪̣͓̼͍̩̩̲̪̲͒ͨ̈ͦ̋͒͑͐͐͂͊̾̊ͪ̕͢͠͠ͅͅ");
            CryptedTextStrUpper.Add("G̛͌̈̄ͬ̾͒̎ͦ͂ͣ̓͟");
            CryptedTextStrUpper.Add("Ḣ̵̳̪̦͖̥̭͚̼͐̔ͨͬ̇͋̑ͥ͐̀́͘͜");
            CryptedTextStrUpper.Add("I̽̀̀̉̇̋̈̊͒͋͛̓͛̋̑");
            CryptedTextStrUpper.Add("J͛ͪ̌͆̽ͯͨ̈̄ͦ͜͡͏̲͇̞̝͚̻̗̬͕̞̞̩̭̕͡");
            CryptedTextStrUpper.Add("K͋ͭ̄́̽͌̏̂̉͛");
            CryptedTextStrUpper.Add("Ļ̴̥̟̩̟̪͚̟͖̟̫̺̤͎̮̜͙ͯͩ̃͆͋ͤ̓̎ͣ̆̓ͭ͝");
            CryptedTextStrUpper.Add("M̰͎͍͇̞͖͓ͣͤ̾̂ͭ̂́͒̌ͩ͘͜͡͠");
            CryptedTextStrUpper.Add("Ņ̨͈͚͔̭̲͎̗̤̫̣͓͙̟ͨͪͮ̈́̎͐̾ͭͩ̈́̄̎͋̊ͣ̄́ͧ͋͘͜");
            CryptedTextStrUpper.Add("O̵ͯ̑̎̓͒̐̔̋̈́͌̄̿͋̋̈͐͏");
            CryptedTextStrUpper.Add("P̷̸̢̨̼̗̬̬̥͕̪̲̗̰̞̫̖̙̯̭͖͊̉ͭ̊̀̈́̕");
            CryptedTextStrUpper.Add("Q̞̝͔͌̇ͬͨ̔ͮ̉͒̔ͭ̎͌͝͡͡");
            CryptedTextStrUpper.Add("R̰̺̟̺͈͂̏͛ͭ́̀͡͡͝");
            CryptedTextStrUpper.Add("S̴̸͚͖̫͉̙̹̭̯̱̺̠͎̻̻̳̮͍̓́ͬ̈̃̎ͤ̄ͫͤͦͫ̚͟͠͡ͅ");
            CryptedTextStrUpper.Add("T̛̮̗͚̖̬̺͔̮̝͈͇̦̐̓̇́̒ͫ̀͢͟");
            CryptedTextStrUpper.Add("U͉͈͍̖̫̳̙̥̼̹̘͍̔̈́͑̐͛ͥ̿ͧ̔ͩ̚͠͞");
            CryptedTextStrUpper.Add("V̸̒̔̒ͧͭ̎̆͗ͥͥͩ̈́ͬ̔ͦ́̔̚̚");
            CryptedTextStrUpper.Add("Ŵ͊̈́͛̆ͤ͛͗̈́̆̾̀͛͋ͥ̊̐ͪ");
            CryptedTextStrUpper.Add("X̨̛͈̻̮̗̙͔̠̼͖̫͙̼͉̓ͣ̊̄͒͆͒̀ͯͩ̇̓̌ͨ̍ͣ̃ͮ͠");
            CryptedTextStrUpper.Add("Y̒̄̔͆́̑͊̈̿̒͂ͪ̂ͨ̃ͬ͘");
            CryptedTextStrUpper.Add("Z̨̡͍͈̖̳̹͔͕̝̘̠͐͆͆̄͢ͅ");

            if (CryptedTextStrNumber != null) CryptedTextStrNumber.Clear();
            CryptedTextStrNumber = new List<string>();
            CryptedTextStrNumber.Add("0̶̢̖͇̠̣͈̪ͩͯ̄̅ͣͫͫ̾ͣ̾͡");
            CryptedTextStrNumber.Add("1̢̡͔̯̦̠̦̻̲͕̝̤͎̘̥͇̬̠̗͍́̃̏̇͊̍̀́͟");
            CryptedTextStrNumber.Add("2̴̫̞̰̲̼̭̣̠͔̐̂̽̃̎ͨ̐ͣ̽ͭͭ̆");
            CryptedTextStrNumber.Add("3̛̓ͬ̑̅̐̓̌́̚҉̢̘̭͎̣͚̱͘");
            CryptedTextStrNumber.Add("4̴̡̧̘̻̯̳̆̈ͨͭ̇");
            CryptedTextStrNumber.Add("5̦̺̱̤͖̘̦̙̪̘̜͕͇̋̿͛̂͋̕͠");
            CryptedTextStrNumber.Add("6̛̹͉̜̻͓͈̳ͥ͂̎̓̎͐͗͘͟");
            CryptedTextStrNumber.Add("7̛̯͔̩̻̮͖̰̟͍̭̝̓͋̎̓̆̀̿͋̑͆ͥ̃̓̓͌̋̂̌̚͡͝");
            CryptedTextStrNumber.Add("8̷̖̼͎͈̻͚̬͖̣̦͕̤ͥͯ͋ͮͬ͋̓͗ͧ̀̚͘͡ͅͅͅ");
            CryptedTextStrNumber.Add("9̛͉̰͙͕̦̭̜̬͇̥̦͓ͭ͛̍ͯ̍̍̔̋ͣ̐̍͜ͅͅ");

            //RegenerateCrypted();

            /*for (int i = 0; i < 0x1800; i++)
            {
                string unicodee = char.ConvertFromUtf32(int.Parse(i.ToString("X4"), System.Globalization.NumberStyles.HexNumber));
                Console.WriteLine("u" + i.ToString("X4") + ":" + unicodee);
            }
            for (int i = 0x1800; i < 0x3500; i++)
            {
                string unicodee = char.ConvertFromUtf32(int.Parse(i.ToString("X4"), System.Globalization.NumberStyles.HexNumber));
                Console.WriteLine("u" + i.ToString("X4") + ":" + unicodee);
            }*/
        }

        public void AddToNotEncrypt(string AddThis)
        {
            NotCryptedText.Add(AddThis);
        }

        public void AddToNotEncryptClass(string AddThis, string ThisCrypted)
        {
            NotCryptedClassList.Add(AddThis);
            NotCryptedClassListCrypted.Add(ThisCrypted);
        }

        public void ClearRemake()
        {
            NotCryptedText.Clear();
            NotCryptedClassList.Clear();
            NotCryptedClassListCrypted.Clear();
            CreateList();
        }

        /*private void RegenerateCrypted()
        {
            if (ToEncryptTextEncrypted != null) ToEncryptTextEncrypted.Clear();
            ToEncryptTextEncrypted = new List<string>();
            for (int i = 0; i < ToEncryptText.Count; i++)
            {
                ToEncryptTextEncrypted.Add(CreateCryptedText());
                //Console.WriteLine(ToEncryptText[i] + "=" + ToEncryptTextEncrypted[ToEncryptTextEncrypted.Count - 1]);
            }
        }*/

        public const string Hell2 = "\u00A0\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u3000";

        public string CreateCryptedText()
        {
            //Console.WriteLine(Hell2);
            // ­?????????       ???????? 

            string CryptedGenerated = "";

            CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];
            //for (int i = 0; i < rnd.Next(form1_0.CryptedMinLenght, form1_0.CryptedMaxLenght) - 1; i++)
            //{
                int Modeee = rnd.Next(0, 1);
                //int Modeee = rnd.Next(0, 2);
                if (Modeee == 0) CryptedGenerated += CryptedTextStr[rnd.Next(0, CryptedTextStr.Count)];
                else if (Modeee == 1) CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];
                //else if (Modeee == 2) CryptedGenerated += CryptedTextStrNumber[rnd.Next(0, CryptedTextStrNumber.Count)];
            //}

            if (CryptedTextAllString.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllString.Count; i++) if (CryptedTextAllString[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    Modeee = rnd.Next(0, 1);
                    if (Modeee == 0) CryptedGenerated += CryptedTextStr[rnd.Next(0, CryptedTextStr.Count)];
                    else if (Modeee == 1) CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllString.Count; i++) if (CryptedTextAllString[i] == CryptedGenerated) Exist = true;
                }
            }

            //Add to list
            CryptedTextAllString.Add(CryptedGenerated);

            return CryptedGenerated;
        }

        public string CreateCryptedTextNumber(int MinNumber, int MaxNumber)
        {
            string CryptedGenerated = "";

            CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];
            //for (int i = 0; i < rnd.Next(MinNumber, MaxNumber) - 1; i++)
            //{
                int Modeee = rnd.Next(0, 1);
                //int Modeee = rnd.Next(0, 2);
                if (Modeee == 0) CryptedGenerated += CryptedTextStr[rnd.Next(0, CryptedTextStr.Count)];
                else if (Modeee == 1) CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];
                //else if (Modeee == 2) CryptedGenerated += CryptedTextStrNumber[rnd.Next(0, CryptedTextStrNumber.Count)];
            //}


            if (CryptedTextAllNumber.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllNumber.Count; i++) if (CryptedTextAllNumber[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    Modeee = rnd.Next(0, 1);
                    if (Modeee == 0) CryptedGenerated += CryptedTextStr[rnd.Next(0, CryptedTextStr.Count)];
                    else if (Modeee == 1) CryptedGenerated += CryptedTextStrUpper[rnd.Next(0, CryptedTextStrUpper.Count)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllNumber.Count; i++) if (CryptedTextAllNumber[i] == CryptedGenerated) Exist = true;
                }
            }

            //Add to list
            CryptedTextAllNumber.Add(CryptedGenerated);

            return CryptedGenerated;
        }
    }
}
