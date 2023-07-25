using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB.Model
{
    internal class Input : Entry
    {
        public decimal Cost 
        { 
            get
            {
                return _cost;
            }set
            {
                if(value != _cost)
                {
                    if(value < 0)
                    {
                        _cost = 0;
                    }
                    _cost = value;
                }
            }
        }
        private decimal _cost;

        public Input(DateTime date, Article article, decimal cost) : base(date, article)
        {
            Date = date;
            Article = article;
            Cost = cost;
        }

        public decimal GetArticleDefaultCost()
        {
            return Article.CostByDefault;
        }
    }
}
