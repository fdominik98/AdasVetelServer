using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{
    class CimFinder : FinderBase<Cim>
    {
        public static CimFinder Instance { get; } = new CimFinder();
  
       
        private CimFinder() { }
        protected override void fillFindable()
        {
            findOrszag();
            if (findVaros()) validValues++;
            if (findIranyitoszam()) validValues++;
            if (findUtca()) validValues++;
            if (findHazszam()) validValues++;
            if (findEmelet()) validValues++;
           
          
        }
        private bool findOrszag() {
            MatchResult m = new Ner("entityPatterns/cim/orszag.xml").findMatch(text);
            if (m != null) {
                findable.Orszag = m.Value;
                return true;
            }
            return false;
        }
        private bool findIranyitoszam()
        {
            MatchResult m = new Ner("entityPatterns/cim/iranyitoszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Iranyitoszam = int.Parse(m.Value);
                return true;
            }
            return false;
        }
        private bool findVaros()
        {
            MatchResult m = new Ner("entityPatterns/cim/varos.xml").findMatch(text);
            if (m != null)
            {
                findable.Varos = m.Value;
                return true;
            }
            return false;
        }
        private bool findUtca()
        {
            MatchResult m = new Ner("entityPatterns/cim/utca.xml").findMatch(text);
            if (m != null)
            {
                findable.Utca = m.Value;
                return true;
            }
            return false;
        }

        private bool findHazszam()
        {
            MatchResult m = new Ner("entityPatterns/cim/hazszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Hazszam = m.Value;
                return true;
            }
            return false;
        }
        private bool findEmelet()
        {
            MatchResult m = new Ner("entityPatterns/cim/emelet.xml").findMatch(text);
            if (m != null)
            {
                findable.Emelet = int.Parse(m.Value);
                return true;
            }
            return false;
        }

        protected override void formatAttr()
        {
            findable.Hazszam = TextAnalyzer.firstCap(findable.Hazszam);
            findable.Orszag = TextAnalyzer.firstCap(findable.Orszag);
            findable.Varos = TextAnalyzer.firstCap(findable.Varos);
            findable.Utca = TextAnalyzer.firstCap(findable.Utca);
        }

        protected override void validateFindable()
        {
            if (validValues < 2 )
                findable.isValid = false;
        }

        protected override bool insertToDatabase()
        {            
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Cim> cimek = dbh.getCimek();            
            bool inDb = false;
            foreach (var c in cimek)
            {               
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
               dbh.insertCimToDatabase(findable);
                return true;
            }
            return false;
        }
    }
}
