using AdasVetelServer.dbHandler;
using AdasVetelServer.logic;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdasVetelServer.db
{
    class RouteContainer
    {       
        public static RouteContainer Instance { get; } = new RouteContainer();
        List<RouteMapperBase> routeMaps = new List<RouteMapperBase>();
        private DbHandler dbh;
        private RouteContainer(){
            dbh = new DbHandler();


            routeMaps.Add(new NoIdRouteMapper<Cim>("^/cimek$", dbh.getCimek));
            routeMaps.Add(new NoIdRouteMapper<Gepjarmu>("^/gepjarmuvek$", dbh.getGepjarmuvek));
            routeMaps.Add(new NoIdRouteMapper<Ingatlan>("^/ingatlanok$", dbh.getIngatlanok));
            routeMaps.Add(new NoIdRouteMapper<Ingo>("^/ingok$", dbh.getIngosagok));
            routeMaps.Add(new NoIdRouteMapper<Reszvetel>("^/reszvetelek$", dbh.getReszvetelek));
            routeMaps.Add(new NoIdRouteMapper<Szemely>("^/szemelyek$", dbh.getSzemelyek));
            routeMaps.Add(new NoIdRouteMapper<Szervezet>("^/szervezetek$", dbh.getSzervezetek));
            routeMaps.Add(new NoIdRouteMapper<Szerzodes>("^/szerzodesek$", dbh.getSzerzodesek));
            routeMaps.Add(new NoIdRouteMapper<SzerzodesTargy>("^/szerzodestargyak$", dbh.getSzerzodesTargyak));
            routeMaps.Add(new NoIdRouteMapper<Teljesites>("^/teljesitesek$", dbh.getTeljesitesek));

            routeMaps.Add(new OneIdRouteMapper<Szerzodes>("^/szemelyek/[0-9]+/szerzodesek$", dbh.getSzerzodesekBySzemely));
            routeMaps.Add(new OneIdRouteMapper<Reszvetel>("^/szemelyek/[0-9]+/reszvetelek$", dbh.getReszvetelekBySzemely));
            routeMaps.Add(new OneIdRouteMapper<Cim>("^/szemelyek/[0-9]+/cimek$", dbh.getCimekBySzemely));

            routeMaps.Add(new OneIdRouteMapper<Szerzodes>("^/szervezetek/[0-9]+/szerzodesek$", dbh.getSzerzodesekBySzervezet));
            routeMaps.Add(new OneIdRouteMapper<Reszvetel>("^/szervezetek/[0-9]+/reszvetelek$", dbh.getReszvetelekBySzervezet));
            routeMaps.Add(new OneIdRouteMapper<Cim>("^/szervezetek/[0-9]+/cimek$", dbh.getCimekBySzervezet));

            routeMaps.Add(new OneIdRouteMapper<Szemely>("^/szerzodesek/[0-9]+/szemelyek$", dbh.getSzemelyekBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Szervezet>("^/szerzodesek/[0-9]+/szervezetek$", dbh.getSzervezetekBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Reszvetel>("^/szerzodesek/[0-9]+/reszvetelek$", dbh.getReszvetelekBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Ingatlan>("^/szerzodesek/[0-9]+/ingatlanok$", dbh.getIngatlanokBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Gepjarmu>("^/szerzodesek/[0-9]+/gepjarmuvek$", dbh.getGepjarmuvekBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Ingo>("^/szerzodesek/[0-9]+/ingok$", dbh.getIngosagokBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<Teljesites>("^/szerzodesek/[0-9]+/teljesitesek$", dbh.getTeljesitesekBySzerzodes));
            routeMaps.Add(new OneIdRouteMapper<SzerzodesTargy>("^/szerzodesek/[0-9]+/szerzodestargyak$", dbh.getSzerzodesTargyakBySzerzodes));



            dbh.closeConnection();
        
        }
        public List<byte[]> getDataByRoute(string route)
        {
            dbh.openConnection();

            List<byte[]> res = null; 
                foreach (var item in routeMaps)
                {
                    if (Regex.IsMatch(route, item.Route))                    
                       res =  item.RunQuery(route);                    
                }

            dbh.closeConnection();

            if (res != null)
                return res;
            throw new Exception("Invalid route");
        }
    }
}
