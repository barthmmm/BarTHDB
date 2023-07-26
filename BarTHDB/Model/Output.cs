using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB.Model
{
    internal class Output : Entry
    {
        public Output(DateTime date, Article article) : base(date, article)
        {
            Date = date;
            Article = article;
        }

        public override string ToString()
        {
            return $"Output: {Date.ToString()} - {Article.ToString()}";
        }
    }
}
