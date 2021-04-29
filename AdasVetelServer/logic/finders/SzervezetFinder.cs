using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System.Collections.Generic;
using System.Linq;

namespace AdasVetelServer.logic
{
    class SzervezetFinder : FinderBase<Szervezet>
    {
        public static SzervezetFinder Instance { get; } = new SzervezetFinder();
        private SzervezetFinder() { }

        protected override void fillFindable()
        {          
            if(findNev()) validValues++;
            findTipus();
            if(findCegjegy()) validValues +=2;
            if(findAdo()) validValues += 2;
            if (findStat()) validValues++;
            if (findSzamla()) validValues ++;
            if (findSzekhely()) validValues++;           
        }
        private bool findTipus() {
            MatchResult m = new Ner("entityPatterns/resztvevo/cegtipus.xml").findMatch(findable.Nev);
            if (m != null)
            {
                findable.Tipus = m.Value;
                return true;
            }
            return false;
        }
        private bool findSzekhely()
        {
            findable.Szekhely = CimFinder.Instance.findOne(text);
            if (findable.Szekhely != null) {
                findable.SzekhelyAz = findable.Szekhely.Az;
                return true;
            }
            return false;
        }
        private bool findNev()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/cegnev.xml").findMatch(text);
            if (m != null) { 
                findable.Nev = m.Value;
                return true;
            }
            return false;
        }

        private bool findCegjegy()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/cegjegyzekszam.xml").findMatch(text);
            if (m != null) { 
                findable.Cegjegyzekszam = m.Value.Replace(" ", "");
                return true;
            }
            return false;
        }
        private bool findStat()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/statisztikaiaz.xml").findMatch(text);
            if (m != null) { 
                findable.StatAz = m.Value.Replace(" ", "");
                return true;
            }
            return false;
        }
        private bool findAdo()
        {
            MatchResult m = new Ner("entityPatterns/resztvevo/adoszam.xml").findMatch(text);
            if (m != null) { 
                findable.Adoszam = m.Value.Replace(" ", "");
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
       
        protected override void formatAttr()
        {
            findable.Nev = TextAnalyzer.firstCap(findable.Nev);
            findable.Tipus = TextAnalyzer.firstCap(findable.Tipus);           
        }

        protected override void validateFindable()
        {   
            if (validValues < 4)
                findable.isValid = false;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Szervezet> szervezetek = dbh.getSzervezetek();
            bool inDb = false;
            foreach (var c in szervezetek)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertSzervezetToDatabase(findable);
                return true;
            }
            return false;
        }
    }
    
}

