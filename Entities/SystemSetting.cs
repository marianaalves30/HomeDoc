using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Entities
{
    public class SystemSetting
    {
        public string iuguKey { get; set; }
        public string htmlPath { get; set; }
        public string bidsPath { get; set; }
        public string dbjsonpath { get; set; }
        public string importedSheets { get; set; }
        public Dictionary<string, string> emailList { get; set; }
        public string secret { get; set; }
    }
}
