using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.db
{
    class TwoIdRouteMapper<T> : RouteMapperBase where T : DbElement
    {
        private event TwoIdCallBack<T> CallBack;
        public TwoIdRouteMapper(string route, TwoIdCallBack<T> callback) : base(route)
        {
            CallBack = callback;
        }

        public override List<byte[]> RunQuery(string route)
        {
            throw new NotImplementedException();
        }
    }
}
