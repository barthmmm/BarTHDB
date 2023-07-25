using BarTHDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB
{
    internal class Controller
    {
        private List<Article> articles;
        private List<Entry> entries;

        /// <summary>
        /// Default contructor, initialise lists
        /// </summary>
        public Controller() {
            articles = new List<Article>();
            entries = new List<Entry>();
        }

        public List<Article> GetArticles()
        {
            return articles;
        }

        public List<Entry> GetEntries()
        {
            return entries;
        }

        public void AddArticle(string name)
        {
            articles.Add(new Article(name));
        }

        public Article GetArticle(int index)
        {
            return articles[index];
        }

        public void AddArticle(string name, decimal defaultCost)
        {
            articles.Add(new Article(name, defaultCost));
        }

        public void SetArticleInactive(int index)
        {
            articles[index].Active = false;
        }

        public void SetArticleActive(int index)
        {
            articles[index].Active = true;
        }

        public void RenameArticle(int index, string name)
        {
            articles[index].Name = name;
        }

        public void SetArticleDefaultCost (int index, decimal defaultCost)
        {
            articles[index].CostByDefault = defaultCost;
        }

        public void AddInput(Article article, decimal cost)
        {
            entries.Add(new Input(DateTime.Now, article, cost));
        }

        public void AddOutput(Article article)
        {
            entries.Add(new Output(DateTime.Now, article));
        }

        public void RemoveEntry(int index) 
        {
            entries.RemoveAt(index);
        }

        public int GetArticleQuantity(int index)
        {
            int quantity = 0;
            foreach (Entry entry in entries) {
                if (entry.Article.Equals(articles[index]))
                {
                    if (entry is Input)
                    {
                        quantity++;
                    }
                    if (entry is Output)
                    {
                        quantity--;
                    }
                }
            }

            return quantity;
        }
    }
}
