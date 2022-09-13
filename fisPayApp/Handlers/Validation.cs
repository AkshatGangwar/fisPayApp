using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace fisPayApp.Handlers
{
    public static class Validation
    {
        public static bool ValidatePassword(string passWord)
        {
            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '?', '+', '=' ,'*'}; // or whatever    
                if (passWord.IndexOfAny(special) == -1) return false;
            }
            return true;
        }
        public static double width()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            return (mainDisplayInfo.Width / mainDisplayInfo.Density);
        }
        public static void toastmsg(string msg, string time, int size)
        {
            var duration = ToastDuration.Short;
            if (time == "L")
            {
                duration = ToastDuration.Long;
            }
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var toast = Toast.Make(msg, duration, size);
            _ = toast.Show(cancellationTokenSource.Token);
        }
        public static string city()
        {
            return "[{\"Id\":1072,\"City\":\"Shamli\",\"State\":\"UttarPradesh\"},{\"Id\":1073,\"City\":\"Najibabad\",\"State\":\"UttarPradesh\"},{\"Id\":1074,\"City\":\"Shikohabad\",\"State\":\"UttarPradesh\"},{\"Id\":1075,\"City\":\"Sikandrabad\",\"State\":\"UttarPradesh\"},{\"Id\":1076,\"City\":\"Shahabad,Hardoi\",\"State\":\"UttarPradesh\"},{\"Id\":1077,\"City\":\"Pilkhuwa\",\"State\":\"UttarPradesh\"},{\"Id\":1078,\"City\":\"Renukoot\",\"State\":\"UttarPradesh\"},{\"Id\":1079,\"City\":\"Vrindavan\",\"State\":\"UttarPradesh\"},{\"Id\":1080,\"City\":\"Ujhani\",\"State\":\"UttarPradesh\"},{\"Id\":1081,\"City\":\"Laharpur\",\"State\":\"UttarPradesh\"},{\"Id\":1082,\"City\":\"Tilhar\",\"State\":\"UttarPradesh\"},{\"Id\":1083,\"City\":\"Sahaswan\",\"State\":\"UttarPradesh\"},{\"Id\":1084,\"City\":\"Rath\",\"State\":\"UttarPradesh\"},{\"Id\":1085,\"City\":\"Sherkot\",\"State\":\"UttarPradesh\"},{\"Id\":1086,\"City\":\"Kalpi\",\"State\":\"UttarPradesh\"},{\"Id\":1087,\"City\":\"Tundla\",\"State\":\"UttarPradesh\"},{\"Id\":1088,\"City\":\"Sandila\",\"State\":\"UttarPradesh\"},{\"Id\":1089,\"City\":\"Nanpara\",\"State\":\"UttarPradesh\"},{\"Id\":1090,\"City\":\"Sardhana\",\"State\":\"UttarPradesh\"},{\"Id\":1091,\"City\":\"Nehtaur\",\"State\":\"UttarPradesh\"},{\"Id\":1092,\"City\":\"Seohara\",\"State\":\"UttarPradesh\"},{\"Id\":1093,\"City\":\"Padrauna\",\"State\":\"UttarPradesh\"},{\"Id\":1094,\"City\":\"Mathura\",\"State\":\"UttarPradesh\"},{\"Id\":1095,\"City\":\"Thakurdwara\",\"State\":\"UttarPradesh\"},{\"Id\":1096,\"City\":\"Nawabganj\",\"State\":\"UttarPradesh\"},{\"Id\":1097,\"City\":\"Siana\",\"State\":\"UttarPradesh\"},{\"Id\":1098,\"City\":\"Noorpur\",\"State\":\"UttarPradesh\"},{\"Id\":1099,\"City\":\"SikandraRao\",\"State\":\"UttarPradesh\"},{\"Id\":1100,\"City\":\"Puranpur\",\"State\":\"UttarPradesh\"},{\"Id\":1101,\"City\":\"Rudauli\",\"State\":\"UttarPradesh\"},{\"Id\":1102,\"City\":\"ThanaBhawan\",\"State\":\"UttarPradesh\"},{\"Id\":1103,\"City\":\"PaliaKalan\",\"State\":\"UttarPradesh\"},{\"Id\":1104,\"City\":\"Zaidpur\",\"State\":\"UttarPradesh\"},{\"Id\":1105,\"City\":\"Nautanwa\",\"State\":\"UttarPradesh\"},{\"Id\":1106,\"City\":\"Zamania\",\"State\":\"UttarPradesh\"},{\"Id\":1107,\"City\":\"Shikarpur,Bulandshahr\",\"State\":\"UttarPradesh\"},{\"Id\":1108,\"City\":\"NaugawanSadat\",\"State\":\"UttarPradesh\"},{\"Id\":1109,\"City\":\"FatehpurSikri\",\"State\":\"UttarPradesh\"},{\"Id\":1110,\"City\":\"Shahabad,Rampur\",\"State\":\"UttarPradesh\"},{\"Id\":1111,\"City\":\"Robertsganj\",\"State\":\"UttarPradesh\"},{\"Id\":1112,\"City\":\"Utraula\",\"State\":\"UttarPradesh\"},{\"Id\":1113,\"City\":\"Sadabad\",\"State\":\"UttarPradesh\"},{\"Id\":1114,\"City\":\"Rasra\",\"State\":\"UttarPradesh\"},{\"Id\":1115,\"City\":\"Lar\",\"State\":\"UttarPradesh\"},{\"Id\":1116,\"City\":\"LalGopalganjNindaura\",\"State\":\"UttarPradesh\"},{\"Id\":1117,\"City\":\"Sirsaganj\",\"State\":\"UttarPradesh\"},{\"Id\":1118,\"City\":\"Pihani\",\"State\":\"UttarPradesh\"},{\"Id\":1119,\"City\":\"Shamsabad,Agra\",\"State\":\"UttarPradesh\"},{\"Id\":1120,\"City\":\"Rudrapur\",\"State\":\"UttarPradesh\"},{\"Id\":1121,\"City\":\"Soron\",\"State\":\"UttarPradesh\"},{\"Id\":1122,\"City\":\"SUrbanAgglomerationr\",\"State\":\"UttarPradesh\"},{\"Id\":1123,\"City\":\"Samdhan\",\"State\":\"UttarPradesh\"},{\"Id\":1124,\"City\":\"Sahjanwa\",\"State\":\"UttarPradesh\"},{\"Id\":1125,\"City\":\"RampurManiharan\",\"State\":\"UttarPradesh\"},{\"Id\":1126,\"City\":\"Sumerpur\",\"State\":\"UttarPradesh\"},{\"Id\":1127,\"City\":\"Shahganj\",\"State\":\"UttarPradesh\"},{\"Id\":1128,\"City\":\"Tulsipur\",\"State\":\"UttarPradesh\"},{\"Id\":1129,\"City\":\"Tirwaganj\",\"State\":\"UttarPradesh\"},{\"Id\":1130,\"City\":\"PurqUrbanAgglomerationzi\",\"State\":\"UttarPradesh\"},{\"Id\":1131,\"City\":\"Shamsabad,Farrukhabad\",\"State\":\"UttarPradesh\"},{\"Id\":1132,\"City\":\"Warhapur\",\"State\":\"UttarPradesh\"},{\"Id\":1133,\"City\":\"Powayan\",\"State\":\"UttarPradesh\"},{\"Id\":1134,\"City\":\"Sandi\",\"State\":\"UttarPradesh\"},{\"Id\":1135,\"City\":\"Achhnera\",\"State\":\"UttarPradesh\"},{\"Id\":1136,\"City\":\"Naraura\",\"State\":\"UttarPradesh\"},{\"Id\":1137,\"City\":\"Nakur\",\"State\":\"UttarPradesh\"},{\"Id\":1138,\"City\":\"Sahaspur\",\"State\":\"UttarPradesh\"},{\"Id\":1139,\"City\":\"Safipur\",\"State\":\"UttarPradesh\"},{\"Id\":1140,\"City\":\"Reoti\",\"State\":\"UttarPradesh\"},{\"Id\":1141,\"City\":\"Sikanderpur\",\"State\":\"UttarPradesh\"},{\"Id\":1142,\"City\":\"Saidpur\",\"State\":\"UttarPradesh\"},{\"Id\":1143,\"City\":\"Sirsi\",\"State\":\"UttarPradesh\"},{\"Id\":1144,\"City\":\"Purwa\",\"State\":\"UttarPradesh\"},{\"Id\":1145,\"City\":\"Parasi\",\"State\":\"UttarPradesh\"},{\"Id\":1146,\"City\":\"Lalganj\",\"State\":\"UttarPradesh\"},{\"Id\":1147,\"City\":\"Phulpur\",\"State\":\"UttarPradesh\"},{\"Id\":1148,\"City\":\"Shishgarh\",\"State\":\"UttarPradesh\"},{\"Id\":1149,\"City\":\"Sahawar\",\"State\":\"UttarPradesh\"},{\"Id\":1150,\"City\":\"Samthar\",\"State\":\"UttarPradesh\"},{\"Id\":1151,\"City\":\"Pukhrayan\",\"State\":\"UttarPradesh\"},{\"Id\":1152,\"City\":\"Obra\",\"State\":\"UttarPradesh\"},{\"Id\":1153,\"City\":\"Niwai\",\"State\":\"UttarPradesh\"},{\"Id\":1154,\"City\":\"Dehradun\",\"State\":\"Uttarakhand\"},{\"Id\":1155,\"City\":\"Hardwar\",\"State\":\"Uttarakhand\"},{\"Id\":1156,\"City\":\"Haldwani-cum-Kathgodam\",\"State\":\"Uttarakhand\"},{\"Id\":1157,\"City\":\"Srinagar\",\"State\":\"Uttarakhand\"},{\"Id\":1158,\"City\":\"Kashipur\",\"State\":\"Uttarakhand\"},{\"Id\":1159,\"City\":\"Roorkee\",\"State\":\"Uttarakhand\"},{\"Id\":1160,\"City\":\"Rudrapur\",\"State\":\"Uttarakhand\"},{\"Id\":1161,\"City\":\"Rishikesh\",\"State\":\"Uttarakhand\"},{\"Id\":1162,\"City\":\"Ramnagar\",\"State\":\"Uttarakhand\"},{\"Id\":1163,\"City\":\"Pithoragarh\",\"State\":\"Uttarakhand\"},{\"Id\":1164,\"City\":\"Manglaur\",\"State\":\"Uttarakhand\"},{\"Id\":1165,\"City\":\"Nainital\",\"State\":\"Uttarakhand\"},{\"Id\":1166,\"City\":\"Mussoorie\",\"State\":\"Uttarakhand\"},{\"Id\":1167,\"City\":\"Tehri\",\"State\":\"Uttarakhand\"},{\"Id\":1168,\"City\":\"Pauri\",\"State\":\"Uttarakhand\"},{\"Id\":1169,\"City\":\"Nagla\",\"State\":\"Uttarakhand\"},{\"Id\":1170,\"City\":\"Sitarganj\",\"State\":\"Uttarakhand\"},{\"Id\":1171,\"City\":\"Bageshwar\",\"State\":\"Uttarakhand\"},{\"Id\":1172,\"City\":\"Kolkata\",\"State\":\"WestBengal\"},{\"Id\":1173,\"City\":\"Siliguri\",\"State\":\"WestBengal\"},{\"Id\":1174,\"City\":\"Asansol\",\"State\":\"WestBengal\"},{\"Id\":1175,\"City\":\"Raghunathganj\",\"State\":\"WestBengal\"},{\"Id\":1176,\"City\":\"Kharagpur\",\"State\":\"WestBengal\"},{\"Id\":1177,\"City\":\"Naihati\",\"State\":\"WestBengal\"},{\"Id\":1178,\"City\":\"EnglishBazar\",\"State\":\"WestBengal\"},{\"Id\":1179,\"City\":\"Baharampur\",\"State\":\"WestBengal\"},{\"Id\":1180,\"City\":\"Hugli-Chinsurah\",\"State\":\"WestBengal\"},{\"Id\":1181,\"City\":\"Raiganj\",\"State\":\"WestBengal\"},{\"Id\":1182,\"City\":\"Jalpaiguri\",\"State\":\"WestBengal\"},{\"Id\":1183,\"City\":\"Santipur\",\"State\":\"WestBengal\"},{\"Id\":1184,\"City\":\"Balurghat\",\"State\":\"WestBengal\"},{\"Id\":1185,\"City\":\"Medinipur\",\"State\":\"WestBengal\"},{\"Id\":1186,\"City\":\"Habra\",\"State\":\"WestBengal\"},{\"Id\":1187,\"City\":\"Ranaghat\",\"State\":\"WestBengal\"},{\"Id\":1188,\"City\":\"Bankura\",\"State\":\"WestBengal\"},{\"Id\":1189,\"City\":\"Nabadwip\",\"State\":\"WestBengal\"},{\"Id\":1190,\"City\":\"Darjiling\",\"State\":\"WestBengal\"},{\"Id\":1191,\"City\":\"Purulia\",\"State\":\"WestBengal\"},{\"Id\":1192,\"City\":\"Arambagh\",\"State\":\"WestBengal\"},{\"Id\":1193,\"City\":\"Tamluk\",\"State\":\"WestBengal\"},{\"Id\":1194,\"City\":\"AlipurdUrbanAgglomerationr\",\"State\":\"WestBengal\"},{\"Id\":1195,\"City\":\"Suri\",\"State\":\"WestBengal\"},{\"Id\":1196,\"City\":\"Jhargram\",\"State\":\"WestBengal\"},{\"Id\":1197,\"City\":\"Gangarampur\",\"State\":\"WestBengal\"},{\"Id\":1198,\"City\":\"Rampurhat\",\"State\":\"WestBengal\"},{\"Id\":1199,\"City\":\"Kalimpong\",\"State\":\"WestBengal\"},{\"Id\":1200,\"City\":\"Sainthia\",\"State\":\"WestBengal\"},{\"Id\":1201,\"City\":\"Taki\",\"State\":\"WestBengal\"},{\"Id\":1202,\"City\":\"Murshidabad\",\"State\":\"WestBengal\"},{\"Id\":1203,\"City\":\"Memari\",\"State\":\"WestBengal\"},{\"Id\":1204,\"City\":\"PaschimPunropara\",\"State\":\"WestBengal\"},{\"Id\":1205,\"City\":\"Tarakeswar\",\"State\":\"WestBengal\"},{\"Id\":1206,\"City\":\"Sonamukhi\",\"State\":\"WestBengal\"},{\"Id\":1207,\"City\":\"PandUrbanAgglomeration\",\"State\":\"WestBengal\"},{\"Id\":1208,\"City\":\"Mainaguri\",\"State\":\"WestBengal\"},{\"Id\":1209,\"City\":\"Malda\",\"State\":\"WestBengal\"},{\"Id\":1210,\"City\":\"Panchla\",\"State\":\"WestBengal\"},{\"Id\":1211,\"City\":\"Raghunathpur\",\"State\":\"WestBengal\"},{\"Id\":1212,\"City\":\"Mathabhanga\",\"State\":\"WestBengal\"},{\"Id\":1213,\"City\":\"Monoharpur\",\"State\":\"WestBengal\"},{\"Id\":1214,\"City\":\"Srirampore\",\"State\":\"WestBengal\"},{\"Id\":1215,\"City\":\"Adra\",\"State\":\"WestBengal\"},{\"Id\":1216,\"City\":\"Fatehgarh\",\"State\":\"UttarPradesh\"}]";
        }
    }
}
