using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB.Model
{
    internal class Article
    {
        public string Name { get; set; }

        public decimal CostByDefault { get
            {
                return _costByDefault;
            }
            set
            {
                if( _costByDefault != value )
                {
                    if(value < 0)
                    {
                        value = 0;
                    }
                    _costByDefault = value;
                }
            }
        }
        private decimal _costByDefault;
        public bool Active { get; set; }

        public Article(string name)
        {
            Name = name;
            Active = true;
        }

        public Article(string name, decimal cost) {
            Name = name;
            CostByDefault = cost;
            Active = true;
        }

        public override string ToString()
        {
            return $"{Name} (Default Cost: {CostByDefault})";
        }
    }
}
