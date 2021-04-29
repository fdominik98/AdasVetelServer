using AdasVetelServer.dbHandler;
using AdasVetelServer.model;
using System.Collections.Generic;

namespace AdasVetelServer.logic
{
    class IngoFinder : FinderBase<Ingo>
    {
        public static IngoFinder Instance { get; } = new IngoFinder();
        private IngoFinder() { }

        protected override void fillFindable()
        {
            ;
        }

        protected override void formatAttr()
        {
            ;
        }
        protected override void validateFindable()
        {
            ;
        }
        protected override bool insertToDatabase()
        {
            DbHandler dbh = TextAnalyzer.Instance.dbh;
            List<Ingo> ingok = dbh.getIngosagok();
            bool inDb = false;
            foreach (var c in ingok)
            {
                if (c.equals(findable))
                {
                    findable = c;
                    inDb = true;
                    break;
                }
            }
            if (!inDb) { 
                dbh.insertIngoToDatabase(findable);
                return true;
            }
            return false ;
        }

    }
}
