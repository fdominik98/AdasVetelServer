using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{

    class SzerzodesTargyFinder : FinderBase<SzerzodesTargy>
    {
        public static SzerzodesTargyFinder Instance { get; } = new SzerzodesTargyFinder();
        private SzerzodesTargyFinder() { }
        public Szerzodes Szerzodes { get; set; } = null;

        protected override void fillFindable()
        {  

            if (findIngatlan()) validValues++;
            else if (findGepjarmu()) validValues++;
            else  findable.isValid = false;            
               
            if(findArany()) validValues++;
            if (findteljesites()) validValues++;
           
            findable.Szerzodes = Szerzodes;
            findable.SzerzodesAz = Szerzodes.Az;
        }
        private bool findIngatlan() {
            MatchResult ingatlanMatch = new Ner("entityPatterns/szerzodes/ingatlan.xml").findMatch(text);
            if (ingatlanMatch != null) { 
                findable.Ingatlan = IngatlanFinder.Instance.findOne(ingatlanMatch.Value);
                if (findable.Ingatlan != null) {
                    findable.IngatlanAz = findable.Ingatlan.Az;
                    findable.TargyKod = findable.Ingatlan.TargyTipus;
                    return true;
                }
            }
            return false;
        }
        private bool findGepjarmu() {
            MatchResult gepjarmuMatch = new Ner("entityPatterns/szerzodes/gepjarmu.xml").findMatch(text);
            if (gepjarmuMatch != null)
            {
                findable.Gepjarmu = GepjarmuFinder.Instance.findOne(gepjarmuMatch.Value);
                if (findable.Gepjarmu != null)
                {
                    findable.GepjarmuAz = findable.Gepjarmu.Az;
                    findable.TargyKod = findable.Gepjarmu.TargyTipus;
                    return true;
                }
            }
            return false;
        }
        private bool findteljesites()
        {
            findable.Teljesites = TeljesitesFinder.Instance.findOne(text);
            if (findable.Teljesites != null) {
                findable.TeljesitesAz = findable.Teljesites.Az;
                return true;            
            }
            return false;
        }
        protected override void formatAttr()
        {
            findable.TargyKod = TextAnalyzer.firstCap(findable.TargyKod);
        }
        private bool findArany()
        {
            MatchResult arany = new Ner("entityPatterns/szerzodes/eladotulajdonarany.xml").findMatch(text);
            if (arany != null) {
                findable.EladoTulajdonArany = arany.Value.Replace(" ",".");
                return true;
            }
            return false;
        }    
        protected override void validateFindable() { }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<SzerzodesTargy> sztk = dbh.getSzerzodesTargyak();
            bool inDb = false;
            foreach (var c in sztk)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertSzerzodesTargyToDatabase(findable);
                return true;
            }
            return false;
        }
    }
}
