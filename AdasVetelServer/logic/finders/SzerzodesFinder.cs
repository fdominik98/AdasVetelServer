using AdasVetelServer.dbHandler;
using AdasVetelServer.logger;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdasVetelServer.logic
{
    class SzerzodesFinder : FinderBase<Szerzodes>
    {
           
      
        public string FileName { get; set; } = "Ismeretlen";
        public static SzerzodesFinder Instance { get; } = new SzerzodesFinder();
        private SzerzodesFinder() { }


        protected override void fillFindable()
        {          
            if (wordCount < 50)
            {
                findable.isValid = false;
                return;
            }

            findable.FajlNev = FileName;
            findTipus();
            findKelt();
            findJegyzo();

        }

        private void findTipus()
        {         
            MatchResult type = new Ner("entityPatterns/szerzodes/szerzodestipus.xml").findMatch(text.Substring(0,500));
            if(type != null)
             findable.Tipus = type.Value + " adásvételi szerződés";
        }
        private void findKelt()
        {
            MatchResult date = new Ner("entityPatterns/szerzodes/keltdatum.xml").findMatch(text);
            if(date != null)
            {
                MatchCollection m = Regex.Matches(date.Value, "[0-9]+");
                findable.KeltDatum = new DateTime(int.Parse(m[0].Value), int.Parse(m[1].Value), int.Parse(m[2].Value));
            }
        }
      
        private void findJegyzo()
        {
            MatchResult kozjegyzo = new Ner("entityPatterns/szerzodes/kozjegyzo.xml").findMatch(text.Substring(text.Length/2));
            if(kozjegyzo != null)
             findable.EllenjegyzoIroda = kozjegyzo.Value + " Ügyvédi iroda";
        }
             
        protected override void formatAttr()
        {
           
            findable.Tipus = TextAnalyzer.firstCap(findable.Tipus);
            findable.EllenjegyzoIroda = TextAnalyzer.firstCap(findable.EllenjegyzoIroda);
           
        }

        protected override void validateFindable()
        {
            if (findable.KeltDatum <= new DateTime(1900, 01, 01) || findable.KeltDatum >= new DateTime(3000, 01, 01))
                findable.KeltDatum = null;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Szerzodes> szerzodesek = dbh.getSzerzodesek();
            bool inDb = false;           
            foreach (var c in szerzodesek)
            {
               
                if (c.equals(findable))
                {

                    findable = c;                    
                    inDb = true;
                    break;
                }
            }
            if (!inDb) {
                dbh.insertSzerzodesToDatabase(findable);
                return true;
            }
            return false;
        }
    }
}
