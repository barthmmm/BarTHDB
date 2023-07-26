using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB.Model
{
    abstract class Entry
    {
        public DateTime Date {  get; set; }
        public Article Article { get; set; }

        protected Entry(DateTime date, Article article) {
            this.Date = date;  
            this.Article = article;
        }

        public override string ToString()
        {
            return $"{Date.ToString()} - {Article.ToString()}";
        }
    }
}
