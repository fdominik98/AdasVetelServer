using AdasVetelServer.dbHandler;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdasVetelServer.logic
{
    public class TextAnalyzer
    {
        public DbHandler dbh { get; set; }
        public static TextAnalyzer Instance { get; } = new TextAnalyzer();
        private TextAnalyzer()
        { }

       private string text;
        public string formatData(string data)
        {
            data = data.Replace(".", " ");
            data = data.Replace("-", " ");
            data = data.Replace(",", " ,");            
            data = data.Replace(":", " ");
            data = data.Replace("\"", " ");
            data = data.Replace("˝", " ");
            data = data.Replace(";", " ");
            data = data.Replace("(", " ");
            data = data.Replace(")", " ");
            data = data.Replace("[", " ");
            data = data.Replace("]", " ");          
            data = data.Replace("\t", " ");
            //data = data.Replace("\n", " ");         
            Regex regex = new Regex("[ ]{2,}", RegexOptions.None);
            data = regex.Replace(data, " ");
            data = data.Replace("\n \n", "\n\n");


            //Console.WriteLine(data);
            return data;        
        }
        public void analyzeText(string data, string filename)
        {
            using (dbh = new DbHandler())
            {  
                              
                text = formatData(data);

                Szerzodes szerzodes = findSzerzodes(Path.GetFileName(filename));

                findResztvevok(szerzodes);
                findTargyak(szerzodes);

                CimFinder.Instance.History.Clear();
                GepjarmuFinder.Instance.History.Clear();
                IngatlanFinder.Instance.History.Clear();
                IngoFinder.Instance.History.Clear();
                ReszvetelFinder.Instance.History.Clear();
                SzemelyFinder.Instance.History.Clear();
                SzervezetFinder.Instance.History.Clear();
                SzerzodesFinder.Instance.History.Clear();
                SzerzodesTargyFinder.Instance.History.Clear();
                TeljesitesFinder.Instance.History.Clear();
         

                dbh.submintChanges();

           

            }
        }
        private Szerzodes findSzerzodes(string filename) {
            SzerzodesFinder.Instance.FileName = filename;
            return SzerzodesFinder.Instance.findOne(text);
        }
        private void findTargyak(Szerzodes szerzodes)
        {
            SzerzodesTargyFinder.Instance.Szerzodes = szerzodes;
            SzerzodesTargyFinder.Instance.findOne(text);
        }
        private void findResztvevok(Szerzodes szerzodes)
        {
            MatchResult eladok = new Ner("entityPatterns/szerzodes/eladok.xml").findMatch(text);
            if (eladok != null)
            {
                foreach (var item in eladok.Value.Split(new string[] { "\n\n" }, StringSplitOptions.None))
                {
                    ReszvetelFinder.Instance.Szerzodes = szerzodes;
                    ReszvetelFinder.Instance.Role = "Eladó";
                    ReszvetelFinder.Instance.findOne(item);
                }
            }
            MatchResult vevok = new Ner("entityPatterns/szerzodes/vevok.xml").findMatch(text);
            if (vevok != null)
            {
                foreach (var item in vevok.Value.Split(new string[] { "\n\n" }, StringSplitOptions.None))
                {
                    ReszvetelFinder.Instance.Szerzodes = szerzodes;
                    ReszvetelFinder.Instance.Role = "Vevő";
                    ReszvetelFinder.Instance.findOne(item);
                }          
            }
        }
        public static string firstCap(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
     


    }
}
