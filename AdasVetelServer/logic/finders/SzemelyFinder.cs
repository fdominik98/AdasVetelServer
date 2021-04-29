using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdasVetelServer.logic
{
    class SzemelyFinder : FinderBase<Szemely>
    {
        public static SzemelyFinder Instance { get; } = new SzemelyFinder();
        private SzemelyFinder() { }

        protected override void fillFindable()
        {
           
            if(findCsaladiNev()) validValues++;
            if (findUtoNev()) validValues++;
            if(findAnyja()) validValues++;
            if (findSzemelyi()) validValues += 2;
            if(findAdo()) validValues+=2;
            if (findSzulIdo())validValues ++;
            if (findSzulHely()) validValues++;
            if (findSzamla()) validValues++;
            if (findCim()) validValues++;

        }
        private bool findCim()
        {
            findable.Lakcim = CimFinder.Instance.findOne(text);
            if (findable.Lakcim != null) {
                findable.LakcimAz = findable.Lakcim.Az;
                return true;
            }
            return false;
        }
        private bool findAdo()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/adoszam.xml").findMatch(text);
            if (m != null) { 
                findable.Adoazonosito = m.Value.Replace(" ", "");
                return true;
            }
            return false;
        }
        private bool findSzemelyi()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/szemelyiszam.xml").findMatch(text);
            if (m != null) { 
                findable.SzemelyiSzam = m.Value.Replace(" ", "");
                return true;
            }
            return false;
        }
        private bool findSzamla()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/szamlaszam.xml").findMatch(text);
            if (m != null) { 
                findable.Szamlaszam = m.Value.Replace(" ", "-");
                return true;
            }
            return false;
        }
        private bool findAnyja()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/anyjaneve.xml").findMatch(text);
            if (m != null)
            {
                findable.AnyjaCsaladiNeve = m.Value.Split(' ')[0];
                findable.AnyjaUtoNeve = m.Value.Split(' ')[1];
                return true;
            }
            return false;
        }
        private bool findSzulIdo()
        {
            Ner ner = new Ner("entityPatterns/resztvevo/szuletesidatum.xml");
            MatchResult date = ner.findMatch(text);
            if (date != null)
            {
                MatchCollection m = Regex.Matches(date.Value, "[0-9]+");
                findable.SzulIdo = new DateTime(int.Parse(m[0].Value), int.Parse(m[1].Value), int.Parse(m[2].Value));
                if (findable.SzulIdo > new DateTime(1900, 01, 01) && findable.SzulIdo < new DateTime(3000, 01, 01))
                    return true;
            }
            findable.SzulIdo = null;
            return false;
            
        }
        private bool findSzulHely() {
            MatchResult place = new Ner("entityPatterns/cim/szuletesihely.xml").findMatch(text);
            if (place != null) { 
                findable.SzulHely = place.Value;
                return true;
            }
            return false;
        }
        private bool findCsaladiNev()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/csaladinev.xml").findMatch(text);
            if (m != null) { 
                findable.CsaladiNev = m.Value;
                return true;
            }
            return false;            
        }
        private bool findUtoNev() {
            MatchResult m = new Ner("entityPatterns/resztvevo/utonev.xml").findMatch(text);
            if (m != null)
            {
                findable.UtoNev = m.Value;
                return true;
            }
            return false;
        }
        protected override void formatAttr()
        {
            findable.CsaladiNev = TextAnalyzer.firstCap(findable.CsaladiNev);
            findable.UtoNev = TextAnalyzer.firstCap(findable.UtoNev);
            findable.AnyjaCsaladiNeve = TextAnalyzer.firstCap(findable.AnyjaCsaladiNeve);
            findable.AnyjaUtoNeve = TextAnalyzer.firstCap(findable.AnyjaUtoNeve);      
            findable.SzulHely = TextAnalyzer.firstCap(findable.SzulHely);
        }

        protected override void validateFindable()
        {
            if (validValues < 6)
                findable.isValid = false;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Szemely> szemelyek = dbh.getSzemelyek();
            bool inDb = false;
            foreach (var c in szemelyek)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertSzemelyToDatabase(findable);
                return true;
            }
            return false;
        }
    }
}
