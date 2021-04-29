using AdasVetelServer.dbHandler;
using AdasVetelServer.logger;
using AdasVetelServer.model;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{
    class ReszvetelFinder : FinderBase<Reszvetel>
    {
        public static ReszvetelFinder Instance { get; } = new ReszvetelFinder();
        private ReszvetelFinder() { }
        public Szerzodes Szerzodes { get; set; } = null;
        public string Role { get; set; } = "";
        protected override void fillFindable()
        {

            if (findSzemely()) validValues++;
            else if (findSzervezet()) validValues++;            
            else  findable.isValid = false; 
            
            findable.Szerep = Role;
            findable.Szerzodes = Szerzodes;
            findable.SzerzodesAz = Szerzodes.Az;
        }

        private bool findSzemely() {
            findable.Szemely = SzemelyFinder.Instance.findOne(text);
            if (findable.Szemely != null) {
                findable.SzemelyAz = findable.Szemely.Az;
                findable.ResztvevoKod = findable.Szemely.ResztvevoTipus;          
                return true;
            }
            return false;
        }
        private bool findSzervezet()
        {
            findable.Szervezet = SzervezetFinder.Instance.findOne(text);
            if (findable.Szervezet != null) {
                findable.SzervezetAz = findable.Szervezet.Az;
                findable.ResztvevoKod = findable.Szervezet.ResztvevoTipus;
                return true;
            }
            return false;
        }       

        protected override void formatAttr() {  }
        protected override void validateFindable() { }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Reszvetel> reszvetek = dbh.getReszvetelek();
            bool inDb = false;
            foreach (var c in reszvetek)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) {
                dbh.insertReszvetelToDatabase(findable);
                return true;
            }
            return false;
        }

    }
}
