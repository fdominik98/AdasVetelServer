using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{
    class GepjarmuFinder : FinderBase<Gepjarmu>
    {
        public static GepjarmuFinder Instance { get; } = new GepjarmuFinder();
        private GepjarmuFinder() { }

        protected override void fillFindable()
        {
            if (findAlvazszam()) validValues++;
            if (findForgalmiszam()) validValues++;
            findExtra();            
            if (findMotorszam()) validValues++;
            if (findRendszam()) validValues++;
            if (findTipus()) validValues++;
            if (findTorzskonyv()) validValues++;
            if (findKilometer()) validValues++;
            if (findGyartasev()) validValues++;
            if (findElsoForgalom()) validValues++;
            findHasznalte();
         
        }
        private bool findHasznalte()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/hasznalte.xml").findMatch(text);
            if (m != null)
            {
                findable.HasznaltE = true;
                return true;
            }
            return false;
        }
        private bool findAlvazszam()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/alvazszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Alvazszam = m.Value;
                return true;
            }
            return false;
        }
        private bool findForgalmiszam()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/forgalmiszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Forgalmiszam = m.Value;
                return true;
            }
            return false;
        }
        private bool findExtra()
        {
            List<MatchResult> ms = new Ner("entityPatterns/gepjarmu/extrafelszereles.xml").findMatches(text);
            if (ms.Count != 0)
            {
                string extras = "";
                foreach (MatchResult item in ms)
                {
                    extras = $"{extras}, {item}";
                }
                findable.ExtraFelsz = extras;
                return true;
            }
            return false;
        }
    
        private bool findMotorszam()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/motorszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Motorszam = m.Value;
                return true;
            }
            return false;
        }
        private bool findRendszam()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/rendszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Rendszam = m.Value;
                return true;
            }
            return false;
        }
        private bool findTipus()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/tipus.xml").findMatch(text);
            if (m != null)
            {
                findable.Tipus = m.Value;
                return true;
            }
            return false;
        }
        private bool findTorzskonyv()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/torzskonyvszam.xml").findMatch(text);
            if (m != null)
            {
                findable.TorzskonyvSzam = m.Value;
                return true;
            }
            return false;
        }
        private bool findKilometer()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/kilometerszam.xml").findMatch(text);
            if (m != null)
            {
                findable.Kilometerszam = int.Parse(m.Value);
                return true;
            }
            return false;
        }
        private bool findGyartasev()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/gyartaseve.xml").findMatch(text);
            if (m != null)
            {
                findable.GyartasEve = int.Parse(m.Value);
                return true;
            }
            return false;
        }
        private bool findElsoForgalom()
        {
            MatchResult m = new Ner("entityPatterns/gepjarmu/elsoforgalom.xml").findMatch(text);
            if (m != null)
            {
                findable.ElsoForgalombaHely = int.Parse(m.Value);
                return true;
            }
            return false;
        }

        protected override void formatAttr()
        {       
            findable.Tipus = TextAnalyzer.firstCap(findable.Tipus);
            if (findable.Motorszam != "Ismeretlen")
                findable.Motorszam = findable.Motorszam.ToUpper();
            if (findable.Forgalmiszam != "Ismeretlen")
                findable.Forgalmiszam = findable.Forgalmiszam.ToUpper();
            if (findable.Alvazszam != "Ismeretlen")
                findable.Alvazszam = findable.Alvazszam.ToUpper();
            if(findable.Rendszam != "Ismeretlen")
                findable.Rendszam = findable.Rendszam.ToUpper();
        }

        protected override void validateFindable()
        {              

            if (validValues < 4)
                findable.isValid = false;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Gepjarmu> gepek = dbh.getGepjarmuvek();
            bool inDb = false;
            foreach (var c in gepek)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertGepjarmuToDatabase(findable);
                return true;
            }
            return false;
        }
    }
    
}
