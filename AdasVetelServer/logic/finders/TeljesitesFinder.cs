using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdasVetelServer.logic
{
    class TeljesitesFinder : FinderBase<Teljesites>
    {
        public static TeljesitesFinder Instance { get; } = new TeljesitesFinder();
        private TeljesitesFinder() { }
        protected override void fillFindable()
        {
            if (findAfa()) validValues++;
            if (findHatarido()) validValues++;
            if (findVetelar()) validValues++;
            if (findReszteljesites()) validValues++;
            findAtutalasE();
        }
        private bool findAtutalasE() {
            MatchResult m = new Ner("entityPatterns/teljesites/atutalas.xml").findMatch(text);
            if (m != null)
            {
                findable.BankiAtutalasE = true;
                return true;
            }
            return false;
        }
        private bool findAfa() {
            MatchResult m = new Ner("entityPatterns/teljesites/afa.xml").findMatch(text);
            if (m != null)
            {
                findable.Afa = m.Value;
                return true;
            }
            return false;
        }
        private bool findHatarido() {
            Ner ner = new Ner("entityPatterns/teljesites/hatarido.xml");
            MatchResult date = ner.findMatch(text);
            if (date != null)
            {
                MatchCollection m = Regex.Matches(date.Value, "[0-9]+");
                findable.Hatarido = new DateTime(int.Parse(m[0].Value), int.Parse(m[1].Value), int.Parse(m[2].Value));
                if (findable.Hatarido > new DateTime(1900, 01, 01) && findable.Hatarido < new DateTime(3000, 01, 01))
                    return true;
            }
            findable.Hatarido = null;
            return false;
        }
        private bool findVetelar()
        {
            MatchResult m = new Ner("entityPatterns/teljesites/vetelar.xml").findMatch(text);
            if (m != null)
            {
                string vetelar = m.Value;
                if (vetelar.Contains(",")) {
                    vetelar = vetelar.Remove(' ');                        
                }
                vetelar = vetelar.Replace(',', '.');
                findable.Vetelar = float.Parse(vetelar,NumberStyles.Currency);
                return true;
            }
            return false;
        }      
        private bool findReszteljesites() {
            return true;
        }
        protected override void formatAttr()
        {}

        protected override void validateFindable()
        {    
            if (validValues < 2)
                findable.isValid = false;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Teljesites> teljk = dbh.getTeljesitesek();
            bool inDb = false;
            foreach (var c in teljk)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertTeljesitesToDatabase(findable);
                return true;
            }
            return false;
        }
    }
}
