using AdasVetelServer.logger;
using AdasVetelServer.logic.ner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdasVetelServer.logic.ner
{
    class Ner
    {
        private EntityPattern ep;
        private string fileName;
        private RegexOptions patternOption = RegexOptions.None;
       

        public Ner(string contextFile)
        {
            ep = EntityPattern.load(contextFile);
            fileName = contextFile;
            if (ep.PatternCaseInsensitive)
                patternOption = RegexOptions.IgnoreCase;
        }
       public List<MatchResult> findMatches(string plaintext)
        {
            //find matches in words to patterns
            List<MatchResult> matches = new List<MatchResult>();  

            foreach (string pattern in ep.Patterns)
            {
                foreach (Match m in Regex.Matches(plaintext, pattern,patternOption)) {
                    if (!matches.Exists(v => v.Value.Equals(m.Value))) { 
                        matches.Add(new MatchResult(m.Value, m.Index, m.Index+m.Length-1));                                       
                    }                  
                }
            }
      

            if (!ep.OnlyPattern) {
                // add weight to remaining matches depending on their context
                foreach (MatchResult cMatch in matches)
                {

                    foreach (string context in ep.ContextsAfter)
                    {
                        if (Regex.IsMatch(plaintext, $"{cMatch.Value} {context}", RegexOptions.IgnoreCase))
                            cMatch.Weight++;
                    }
                    foreach (string context in ep.ContextsBefore)
                    {
                        if (Regex.IsMatch(plaintext, $"{context} {cMatch.Value}", RegexOptions.IgnoreCase))
                            cMatch.Weight++;
                    }              
                }
                // take weight to remaining matches depending on their context
                foreach (MatchResult cMatch in matches)
                {
                    foreach (string context in ep.InvalidsBefore)
                    {
                        if (Regex.IsMatch(plaintext, $"{context} {cMatch.Value}", RegexOptions.IgnoreCase))
                            cMatch.Weight = 0;
                    }
                    foreach (string context in ep.InvalidsAfter)
                    {
                        if (Regex.IsMatch(plaintext, $"{cMatch.Value} {context}", RegexOptions.IgnoreCase))
                            cMatch.Weight = 0;
                    }
                }
            }
            ServerLogger.Instance.writeLog($"Found pattern based on {fileName}:");
            //ServerLogger.Instance.writeLog("{");
            //foreach (MatchResult item in matches)
            //{
            //    ServerLogger.Instance.writeLog("\t" + item.Value + " || " + item.Weight);
            //}
            //ServerLogger.Instance.writeLog("}");

            // sorts first by index then by weigth            

            if (ep.PatternLargestIndex)
                matches.Sort(delegate (MatchResult m1, MatchResult m2) { return m1.BeginIndex.CompareTo(m2.BeginIndex)*-1; });
            else
                matches.Sort(delegate (MatchResult m1, MatchResult m2) { return m1.BeginIndex.CompareTo(m2.BeginIndex); });
            matches.Sort(delegate (MatchResult m2, MatchResult m1) { return m1.Weight.CompareTo(m2.Weight); });
            return matches;
        }
        public List<string> findMatchesValue(string plaintext)
        {
            List<string> matches = new List<string>();
            foreach (var match in findMatches(plaintext))
               matches.Add(match.Value);
            return matches;
            
        }
        public MatchResult findMatch(string plaintext)
        {        
            List<MatchResult> matches = findMatches(plaintext);
            int minWeight = ep.OnlyPattern ? -1 : 0;
            if (matches.Count > 0 && matches[0].Weight > minWeight) {               
                return matches[0];                   
            }
            return null;
        }
        public string findMatchValue(string plaintext)
        {
            MatchResult res = findMatch(plaintext);
            if (res != null)
                return res.Value;
            return "";
        }


    }
}
