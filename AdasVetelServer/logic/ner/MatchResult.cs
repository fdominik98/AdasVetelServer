using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.logic.ner
{
    class MatchResult
    {
        public string Value { get; set; }
        public int EndIndex { get; set; }
        public int BeginIndex { get; set; }
        public int Weight { get; set; } = 0;

        public MatchResult(string value, int beginIndex,int endIndex, int weight = 0)
        {
            Value = value;
            BeginIndex = beginIndex;
            EndIndex = endIndex;
            Weight = weight;
        }
    }
}
