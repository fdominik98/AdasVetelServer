using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.db
{
    abstract class RouteMapperBase
    {
        public string Route { get; set; }  
        public RouteMapperBase(string route)
        {
            Route = route;
        }

        public abstract List<byte[]> RunQuery(string route);
    }
}
