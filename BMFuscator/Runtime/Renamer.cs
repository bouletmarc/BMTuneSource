using BMDevs.Runtime;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMDevs
{
    public class Renamer
    {
        public static List<string> CryptedTextAllString = new List<string> { };
        public static List<string> CryptedTextAllString2 = new List<string> { };
        //public static List<string> CryptedTextAllString3 = new List<string> { };
        //public static List<string> CryptedTextAllString4 = new List<string> { };
        static Random rnd = new Random();

        public static void Rename(IMemberDef member, RenameMode mode, int depth = 1, int sublength = 10)
        {
            member.Name = GetEndName(mode, depth, sublength);
        }

        public static string GetEndName(RenameMode mode, int depth = 1, int sublength = 10)
        {
            string endname = string.Empty;
            for (int i = 0; i < depth; i++)
            {
                endname += GetName(mode, sublength);
            }
            return endname;
        }

        public static string GetName(RenameMode mode, int length)
        {
            switch (mode)
            {
                case RenameMode.Base64:
                    return GetRandomName().Base64Representation();
                case RenameMode.Chinese:
                    return GetChineseString(length);
                case RenameMode.Invalid:
                    return GetFuckedString(length);
                case RenameMode.Invalid2:
                    return GetFuckedString2(length);
                case RenameMode.Invalid3:
                    return GetFuckedString3(length);
                case RenameMode.Logical:
                    return GetRandomName();
                default:
                    throw new InvalidOperationException();
            }
        }

        public enum RenameMode
        {
            Base64,
            Chinese,
            Invalid,
            Invalid2,
            Invalid3,
            Logical
        }

        public static string GetChineseString(int len)
        {
            string shit = "";
            for (int i = 0; i < len; i++)
            {
                shit += ChineseCharacters[RuntimeHelper.Random.Next(ChineseCharacters.Length)];
            }
            return shit;
            //#########################################################
            /*string CryptedGenerated = "";

            CryptedGenerated += ChineseCharacters[0];

            if (CryptedTextAllString4.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllString4.Count; i++) if (CryptedTextAllString4[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    CryptedGenerated += ChineseCharacters[rnd.Next(0, ChineseCharacters.Length)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllString4.Count; i++) if (CryptedTextAllString4[i] == CryptedGenerated) Exist = true;
                }
            }

            //Add to list
            CryptedTextAllString4.Add(CryptedGenerated);
            return CryptedGenerated;*/
        }

        public static char[] ChineseCharacters => new char[]
        {
            '㐀',
            '㐁',
            '㐂',
            '㐃',
            '㐄',
            '㐅',
            '㐆',
            '㐇',
            '㐈',
            '㐉',
            '㐊'
        };

        public static string GetRandomName()
        {
            return Names[RuntimeHelper.Random.Next(Names.Length)];
        }

        public static string[] Names =
        {
            "HasPermission", "HasPermissions", "GetPermissions", "GetOpenWindows", "EnumWindows", "GetWindowText", "GetWindowTextLength", "IsWindowVisible", "GetShellWindow", "Awake", "FixedUpdate", "add_OnRockedInitialized", "remove_OnRockedInitialized", "Awake", "Initialize", "Translate", "Reload", "<Initialize>b__13_0", "Initialize", "FixedUpdate", "Start", "checkTimerRestart", "QueueOnMainThread", "QueueOnMainThread", "RunAsync", "RunAction", "Awake", "FixedUpdate", "IsUri", "GetTypes", "GetTypesFromParentClass", "GetTypesFromParentClass", "GetTypesFromInterface", "GetTypesFromInterface", "get_Timeout", "set_Timeout", "GetWebRequest", "get_SteamID64", "set_SteamID64", "get_SteamID", "set_SteamID", "get_OnlineState", "set_OnlineState", "get_StateMessage", "set_StateMessage", "get_PrivacyState", "set_PrivacyState", "get_VisibilityState", "set_VisibilityState", "get_AvatarIcon", "set_AvatarIcon", "get_AvatarMedium", "set_AvatarMedium", "get_AvatarFull", "set_AvatarFull", "get_IsVacBanned", "set_IsVacBanned", "get_TradeBanState", "set_TradeBanState", "get_IsLimitedAccount", "set_IsLimitedAccount", "get_CustomURL", "set_CustomURL", "get_MemberSince", "set_MemberSince", "get_HoursPlayedLastTwoWeeks", "set_HoursPlayedLastTwoWeeks", "get_Headline", "set_Headline", "get_Location", "set_Location", "get_RealName", "set_RealName", "get_Summary", "set_Summary", "get_MostPlayedGames", "set_MostPlayedGames", "get_Groups", "set_Groups", "Reload", "ParseString", "ParseDateTime", "ParseDouble", "ParseUInt16", "ParseUInt32", "ParseUInt64", "ParseBool", "ParseUri", "IsValidCSteamID", "LoadDefaults", "LoadDefaults", "get_Clients", "Awake", "handleConnection", "FixedUpdate", "Broadcast", "OnDestroy", "Read", "Send", "<Awake>b__8_0", "get_InstanceID", "set_InstanceID", "get_ConnectedTime", "set_ConnectedTime", "Send", "Read", "Close", "get_Address", "get_Instance", "set_Instance", "Save", "Load", "Unload", "Load", "Save", "Load", "get_Configuration", "LoadPlugin", "<.ctor>b__3_0", "<LoadPlugin>b__4_0", "add_OnPluginUnloading", "remove_OnPluginUnloading", "add_OnPluginLoading", "remove_OnPluginLoading", "get_Translations", "get_State", "get_Assembly", "set_Assembly", "get_Directory", "set_Directory", "get_Name", "set_Name", "get_DefaultTranslations", "IsDependencyLoaded", "ExecuteDependencyCode", "Translate", "ReloadPlugin", "LoadPlugin", "UnloadPlugin", "OnEnable", "OnDisable", "Load", "Unload", "TryAddComponent", "TryRemoveComponent", "add_OnPluginsLoaded", "remove_OnPluginsLoaded", "get_Plugins", "GetPlugins", "GetPlugin", "GetPlugin", "Awake", "Start", "GetMainTypeFromAssembly", "loadPlugins", "unloadPlugins", "Reload", "GetAssembliesFromDirectory", "LoadAssembliesFromDirectory", "<Awake>b__12_0", "GetGroupsByIds", "GetParentGroups", "HasPermission", "GetGroup", "RemovePlayerFromGroup", "AddPlayerToGroup", "DeleteGroup", "SaveGroup", "AddGroup", "GetGroups", "GetPermissions", "GetPermissions", "<GetGroups>b__11_3", "Start", "FixedUpdate", "Reload", "HasPermission", "GetGroups", "GetPermissions", "GetPermissions", "AddPlayerToGroup", "RemovePlayerFromGroup", "GetGroup", "SaveGroup", "AddGroup", "DeleteGroup", "DeleteGroup", "<FixedUpdate>b__4_0", "Enqueue", "_Logger_DoWork", "processLog", "Log", "Log", "var_dump", "LogWarning", "LogError", "LogError", "Log", "LogException", "ProcessInternalLog", "logRCON", "writeToConsole", "ProcessLog", "ExternalLog", "Invoke", "_invoke", "TryInvoke", "get_Aliases", "get_AllowedCaller", "get_Help", "get_Name", "get_Permissions", "get_Syntax", "Execute", "get_Aliases", "get_AllowedCaller", "get_Help", "get_Name", "get_Permissions", "get_Syntax", "Execute", "get_Aliases", "get_AllowedCaller", "get_Help", "get_Name", "get_Permissions", "get_Syntax", "Execute", "get_Name", "set_Name", "get_Name", "set_Name", "get_Name", "get_Help", "get_Syntax", "get_AllowedCaller", "get_Commands", "set_Commands", "add_OnExecuteCommand", "remove_OnExecuteCommand", "Reload", "Awake", "checkCommandMappings", "checkDuplicateCommandMappings", "Plugins_OnPluginsLoaded", "GetCommand", "GetCommand", "getCommandIdentity", "getCommandType", "Register", "Register", "Register", "DeregisterFromAssembly", "GetCooldown", "SetCooldown", "Execute", "RegisterFromAssembly"
        };

        //Thanks to Awware#5671
        //public const string Hell = ";̥͓̠̙̠̺̫̱̹̮͈͈͓͍̟̻͆ͧ͒ͩͨ̉ͯ̂̈̉̽̉͑̔̊́͟͜;̢̧͔͓͉̝̆̒ͣͣ̄ͣ̊̈́̎̓͛̇͆ͯͪ̿͟;ͫͭ͒̉̐͑̀҉̭̭͕̟͇̰̺͖͎̗̰̩͉;̸̛̘̬̫̫͔̜͙̣̯̠̯̻͍̰͍̥͓ͦ̎ͯͯ͂ͤ̉̃̊͐̐̽͜;̵̧̂͐̉̆́̚̚҉̜̦̳͇͍;̙͈̞̪̖͚̬͍͙̹ͭ̿͒ͧͧͨ̀;͐̇̋̍̿̎̀͌ͣ͌҉ ̞̙̘̱͟͠_̍̽̋̑͒ͧ̌͐̿͞͡҉̯̣̥̹̗̫̥̩͈̘͟ͅͅ_̈͛̈͊̈́ͥͬ̌ͪ̃̽͑̓͋͛̆̈͋̽҉̸̛̠̝̜͈̮͢_͒͂̋̈́͋̉͒ͦ̊ͯ̐̾̂̐҉҉̧̯̜̣̮̦̱̦̖̗͡_̧̨̹̳̘̯̱͖͙̘̍ͥ͊͌̌ͧͥ̍ͨ̐͡_̵̺̮̞̖̰͔̮̺̳͖̳̳̥͖͖͊͐͛ͥͪ͛͑͠ͅ_ͧ̓ ̴̡̪͎̣̘̳̤̬͔̟̺̳̻̥͇ͧͫ̽͐̄ͤ̎̔_̸̠̪̺͕̩̮̹̦͇̫͙͖̦̻̏̈́̅ͦ͐_̴̸̢͚̤͙͓̱̬̫̝̞̣̥̽͛͊ͥͬ̍͆ͨ͑͋̍͊ͭ͗́ͅ^̵͖̖̹̦͎̦̜͋̉͋͐̈́ͪ̋̊̄́͘͟ ̨͚͙͖̫͚̙̊̏̍̐ͥ̅̏̎͆͗ͧ́̚͞!̧͕͈͕͙̱̟̆ͭ͋ͫ̕͢͞;̛̣̭̖̹̜̘̮̜̭͓̰̫͙͋̏ͯͤ̂ͬ͗ͥ̌ͥ̓ͮͪ͗́͞ͅ;̪̳̼̱̽ͨ͋͛̔ͪͬ̃͌̂̌͐̀ͧͬ̾ͨ̚̚;̛͍̘̗̣͉͓̘͖͙̪͙̦͇̩͈ͩ͋̄̓ͣ́̃ͦͫ͒̑͋̃ͣͥ̋̀;̢͚̰͈͍ͮͤͣ͂̆͋ͨ̀̐̕͞͞ͅ;̨̢̬̹̯̯̤͕͍̺̩̫͈͉̙̪̪̜̻͚̂͋̏̓͛ͣ͟;̥̖̭͕͔̝͇̞̠̰͐̿̆ͣ̈͟͡;̵̸̻̫͔̼͚̤͇̝̞̬̞͚͇̓̐͆̾ͭ̈́ͫ̈́́͜͞;̌ͨ͌̐̉̂̃̅̃̋ͤͤͣͯ҉̧̹̗̺̹͈̙͇̦̣ͅ;̸̫̙͈̫̮̻͎̱͓̗̍a_̈͛̈͊̈́ͥͬ̌ͪ̃̽͑̓͋͛̆̈͋̽҉̸̛̠̝̜͈̮͢_͒‮‮‮‮‮‮‮‮‮‮‮";






        public const string Hell = "b̸̵̝̘͍̪̫̘̩̙̺̜͓̺̈́̌̒̈ͭc̨̛̥͈̞̺͔̞̼ͧ͆̈̾̐͋̎̚͜͝ͅd̷̢͈̣͇͙̤̦̟̱̺̩̦͎̞̬̿ͨͪ̈́̓̏ͫͫ̌͆̎̌ͦ̄̈̔̚̚͟e̛̒͂͌̓ͣͬ͗̉ͣͬ͆̃̒͂f̸̡͈͍̳̯̖̣̱͊͊͋̂̚̚ǧ̴̵̡̼͎̻̝̲̹̲̖͂̐̿̆ͪ̎̍͒̿̓̂͘͟ẖ̸̵̢̢̝̥̬̯̯̼͊̏̋ͩͨͫͪ̆̍ͦ̒̾͋̐̉̈ͥ̏ͥ͡i̶̸̧̪͙͓̯̠̱̝̤͇̅̆͑ͮͭͮ̽͢͜j̧̡͕̮̘͕̞̹̤̾̇ͤ͂͐͊ͦͮ͟͠k̶̼̰̘̲̪͎̲̟͇̰̪̪̗̅́ͤ͐͗͑͑͐̓̊͑ͯ̒̊̎ͮ̆̚̕l̴͚͎̙̻͎̟̩͓͕̜̀̉̓̀͛̿ͣ̆̿̊̃ͨ̄̇̔̀ͣ̒ͣm̨̫͈̣̦̼̱̦͓͈̲͙̫͈͔̞̟͙̠̲͑͑ͦͦ͛ͧ̓̕͝n̑̆͑͋͆̏̊ͭͫ̾ͭ̇ͩ̒̒ͩ̏̚̕o̭͖̘͙̹͎̦̮̪̠̓ͦ̅̒ͣ̑ͬ̓ͪ̊ͫͤͭ̕͜͠ͅp̷̨̧͇̗̩͉̲̱̙̬̖̜̝̤̻̱̝̮͕̯͑̒̍͋ͦ̊͘q́͐ͤ̄̃͌͗̔ͯ̈́̀̀͏͈͕͍̲͓̜̳̲̤̪̱̞̣̼͙̩̯̘s̶̡̺̙̪̣͎̟͉̟̥̜͈̯̳̪̀̑͐́̇ͩͥ̑ͪ̔ͪ͂ͤ̐̾̈́͑̄͘̕͡ţ̶̝͖͓̟̝̳̻̱͖̟͙̜̬̳̯̤ͨ̓̂́ͯ̾͒ͫ̿̇͐ͪͩ͐͋ͬ͑̄̚͢͞u̶̠̘̗̻̼͓̤͓̦̯̝̹̳̺̹͗̽̑̇͌ͯ͐͌̿ͤ͢ͅv̸́͛̓͛͌̅ͯ͌ͮ̆͊ͦ̂̇ͯͪͫ͏̷̙̻̖ẅ̴̶̷̡͎̭̺͙͚̤͒͑͆ͣͥͫ͊ͯ̈̒͛̚͟x̗̟̬͔̤̻̟̎ͥ̀̅͑ͨͥ͌ͣ̍̑̽ͤ̇̿̈́̈́ͬ͘͝ͅy͍͔̬̫͙̝̼͎̭͔̥̻̩̺͎̤̻̤̑ͫ̃ͫ̀̍̿̎̄͐͌͌͢z̴͓͍̗̥̤͌ͬ̑̓̈́͋̏̽̐̋͌͛̾ͮ̾̕͢͝Å̷̢̰̺̻̟͕̫̱̯͔̫̯͕̪̘͉̬ͯ̄ͭ̄ͫ̀ͯB̴̩͇̫͙͆ͭͣ͌͑̂ͬͮ̈̄̔ͨ̏̑ͨ͊͆͂́͝Ç̧̻̠͈͈͕̞̥̭̦̳̯͈̤̲̈́͗͐̆́͊̍̀̑̾̇ͤͭ̍ͫ̽͘Ḏ̛̥̘̟͎̹͍͖̩̳̾̽ͮ̾ͫ̿̓͆́ͨͮͦͩ͌̀̚E̺̳̭͚̣̠̳̹̩̝̹̝̺̳̬̙̥̙̹ͭ̽͛̉ͭ͋̊̚͢F̡̝̭̪̣͓̼͍̩̩̲̪̲͒ͨ̈ͦ̋͒͑͐͐͂͊̾̊ͪ̕͢͠͠ͅͅG̛͌̈̄ͬ̾͒̎ͦ͂ͣ̓͟Ḣ̵̳̪̦͖̥̭͚̼͐̔ͨͬ̇͋̑ͥ͐̀́͘͜I̽̀̀̉̇̋̈̊͒͋͛̓͛̋̑J͛ͪ̌͆̽ͯͨ̈̄ͦ͜͡͏̲͇̞̝͚̻̗̬͕̞̞̩̭̕͡K͋ͭ̄́̽͌̏̂̉͛Ļ̴̥̟̩̟̪͚̟͖̟̫̺̤͎̮̜͙ͯͩ̃͆͋ͤ̓̎ͣ̆̓ͭ͝M̰͎͍͇̞͖͓ͣͤ̾̂ͭ̂́͒̌ͩ͘͜͡͠Ņ̨͈͚͔̭̲͎̗̤̫̣͓͙̟ͨͪͮ̈́̎͐̾ͭͩ̈́̄̎͋̊ͣ̄́ͧ͋͘͜O̵ͯ̑̎̓͒̐̔̋̈́͌̄̿͋̋̈͐͏P̷̸̢̨̼̗̬̬̥͕̪̲̗̰̞̫̖̙̯̭͖͊̉ͭ̊̀̈́̕Q̞̝͔͌̇ͬͨ̔ͮ̉͒̔ͭ̎͌͝͡͡R̰̺̟̺͈͂̏͛ͭ́̀͡͡͝S̴̸͚͖̫͉̙̹̭̯̱̺̠͎̻̻̳̮͍̓́ͬ̈̃̎ͤ̄ͫͤͦͫ̚͟͠͡ͅT̛̮̗͚̖̬̺͔̮̝͈͇̦̐̓̇́̒ͫ̀͢͟U͉͈͍̖̫̳̙̥̼̹̘͍̔̈́͑̐͛ͥ̿ͧ̔ͩ̚͠͞V̸̒̔̒ͧͭ̎̆͗ͥͥͩ̈́ͬ̔ͦ́̔̚̚Ŵ͊̈́͛̆ͤ͛͗̈́̆̾̀͛͋ͥ̊̐ͪX̨̛͈̻̮̗̙͔̠̼͖̫͙̼͉̓ͣ̊̄͒͆͒̀ͯͩ̇̓̌ͨ̍ͣ̃ͮ͠Z̨̡͍͈̖̳̹͔͕̝̘̠͐͆͆̄͢ͅ";



        public const string Hell2 = "\u00A0\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200A\u2028\u205F\u2800\u3000\u30FC\u2013";


        public static string GetFuckedString(int len)
        {
            string sta = "";
            for (int i = 0; i < len; i++)
            {
                sta += Hell[RuntimeHelper.Random.Next(Hell.Length)];
            }
            return sta;
            //#########################################################
            /*string CryptedGenerated = "";

            CryptedGenerated += Hell[0];

            if (CryptedTextAllString.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllString.Count; i++) if (CryptedTextAllString[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    CryptedGenerated += Hell[rnd.Next(0, Hell.Length)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllString.Count; i++) if (CryptedTextAllString[i] == CryptedGenerated) Exist = true;
                }
            }

            Logger.LogMessage("Generated name:", CryptedGenerated, ConsoleColor.Cyan);

            //Add to list
            CryptedTextAllString.Add(CryptedGenerated);
            return CryptedGenerated;*/
        }

        public static string GetFuckedString2(int len)
        {
            string sta = "";
            for (int i = 0; i < len; i++)
            {
                sta += Hell2[RuntimeHelper.Random.Next(Hell2.Length)];
            }
            return sta;
            //#########################################################
            /*string CryptedGenerated = "";

            CryptedGenerated += Hell2[0];

            if (CryptedTextAllString2.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllString2.Count; i++) if (CryptedTextAllString2[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    CryptedGenerated += Hell2[rnd.Next(0, Hell2.Length)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllString2.Count; i++) if (CryptedTextAllString2[i] == CryptedGenerated) Exist = true;
                }
            }

            Logger.LogMessage("Generated name:", CryptedGenerated, ConsoleColor.Cyan);

            //Add to list
            CryptedTextAllString2.Add(CryptedGenerated);
            return CryptedGenerated;*/
        }

        public static string GetFuckedString3(int len)
        {
            string sta = "";
            for (int i = 0; i < len; i++)
            {
                sta += Hell[RuntimeHelper.Random.Next(Hell.Length)];
                sta += Hell2[RuntimeHelper.Random.Next(Hell2.Length)];
            }
            return sta;
            //#########################################################
            /*string CryptedGenerated = "";

            CryptedGenerated += Hell[0] + Hell2[0];

            if (CryptedTextAllString3.Count > 0)
            {
                bool Exist = false;
                for (int i = 0; i < CryptedTextAllString3.Count; i++) if (CryptedTextAllString3[i] == CryptedGenerated) Exist = true;
                while (Exist)
                {
                    //regenerate
                    CryptedGenerated += Hell[rnd.Next(0, Hell.Length)] + Hell2[rnd.Next(0, Hell2.Length)];

                    //recheck
                    Exist = false;
                    for (int i = 0; i < CryptedTextAllString3.Count; i++) if (CryptedTextAllString3[i] == CryptedGenerated) Exist = true;
                }
            }

            //Add to list
            CryptedTextAllString3.Add(CryptedGenerated);
            return CryptedGenerated;*/
        }
    }
}
