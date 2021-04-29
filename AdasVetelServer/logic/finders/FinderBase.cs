using AdasVetelServer.logger;
using AdasVetelServer.logic.ner;
using AdasVetelServer.model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdasVetelServer.logic
{
    abstract class FinderBase<T> where T : DbElement, ICheckable<T>, new()
    {

        protected List<T> history = new List<T>();
        public List<T> History
        {
            get
            {
                return history;
            }
        }

        protected string text;
        protected T findable;       
        protected int validValues;
        protected int wordCount = 0;
        public T findOne(string text)
        {
            /*while(history.Count > 10)
                history.RemoveAt(0);*/


            validValues = 0;
            this.text = text;
            wordCount = text.Split(' ').Length;
            findable = new T();


            fillFindable();
            validateFindable();
            formatAttr();


            foreach (var e in history)
            {
                if (e.equals(findable))
                {                    
                    return e;
                }
            }
            if (findable.isValid)
            {
             
                insertToDatabase();
                history.Add(findable);
                return findable;
            }
            return null;

        }
        protected abstract void fillFindable();
        protected abstract void formatAttr();
        protected abstract void validateFindable();
        protected abstract bool insertToDatabase();      


    }
}
