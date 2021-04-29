using AdasVetelServer.dbHandler;
using AdasVetelServer.logger;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{
    class IngatlanFinder : FinderBase<Ingatlan>
    {
        public static IngatlanFinder Instance { get; } = new IngatlanFinder();
        private IngatlanFinder() { }
       

        protected override void fillFindable()
        {

            if(findTipus()) validValues++;
            if(findTerulet()) validValues++;
            if(findFoldH()) validValues++;
            findBelt();
            if (findSzobak()) validValues++;
            if (findHanyad()) validValues++;
            if (findHelyrajzi()) validValues++;
            if (findCim()) validValues++;

         
        }
        protected override void validateFindable()
        {  
            if (validValues < 3)
                findable.isValid = false;
        }

        protected override void formatAttr()
        {
            findable.Foldhivatal = TextAnalyzer.firstCap(findable.Foldhivatal);      
            findable.Tipus = TextAnalyzer.firstCap(findable.Tipus);
        }
        private bool findCim() {
            findable.Cim = CimFinder.Instance.findOne(text);
            if (findable.Cim != null) {
                findable.CimAz = findable.Cim.Az;
                return true;
            }
            return false;
        }
        private bool findSzobak()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/szobakszama.xml").findMatch(text);
            if (m != null) { 
                findable.SzobakSzama = int.Parse(m.Value);
                return true;
            }
            return false;
        }
        private bool findFoldH()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/foldhivatal.xml").findMatch(text);
            if (m != null) { 
                findable.Foldhivatal = m.Value;
                return true;
            }
            return false;

        }
        private bool findBelt()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/belterulet.xml").findMatch(text);
            if (m != null) { 
                findable.Belterulet = true;
                return true;
            }
            return false;
        }
        private bool findHelyrajzi()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/helyrajziszam.xml").findMatch(text);
            if (m != null) { 
                findable.HelyrajziSzam = m.Value;
                return true;
            }
            return false;
        }
        private bool findHanyad()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/kozostulajdonihanyad.xml").findMatch(text);           
            if (m != null){
                findable.KozosTulajdoniHanyad = m.Value.Replace(" ", ".");
                return true;
            }
            return false;
        }
        private bool findTerulet()
        {
           MatchResult m= new Ner("entityPatterns/ingatlan/terulet.xml").findMatch(text);
            if (m != null){
                findable.Terulet = m.Value;
                return true;
            }
            return false;
        }

        private bool findTipus()
        {
            MatchResult m = new Ner("entityPatterns/ingatlan/ingatlantipus.xml").findMatch(text);
            if (m != null) { 
                findable.Tipus = m.Value;
                return true; 
            }
            return false;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Ingatlan> ingatlanok = dbh.getIngatlanok();
            bool inDb = false;
                  
            foreach (var c in ingatlanok)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    ServerLogger.Instance.writeLog("INDB!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertIngatlanToDatabase(findable);
                return true;
            }
            return false;
        }

    }
}
