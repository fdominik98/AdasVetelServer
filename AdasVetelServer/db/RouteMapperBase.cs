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
        public delegate List<T> NoIdCallBack<T>();
        public delegate List<T> OneIdCallBack<T>(int? id);
        public delegate List<T> TwoIdCallBack<T>(int? id, int? id2);
        public string Route { get; set; }  
        public RouteMapperBase(string route)
        {
            Route = route;
        }

        public abstract List<byte[]> RunQuery(string route);
    }
}
