using BarTHDB.Model;

namespace BarTHDB
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Controller controller = new Controller();

            CreateFakeDB(controller);

            Console.WriteLine($"Quantité de suze: {controller.GetArticleQuantity(0)}");
        }

        static void CreateFakeDB(Controller controller)
        {
            controller.AddArticle("Suze", 29.90m);
            controller.AddArticle("Coca", 5.20m);
            controller.AddArticle("McCallan", 59.90m);
            controller.AddArticle("Gordon 750ml", 49.90m);
            controller.AddArticle("JaegerMaster", 39.90m);

            Article suze = controller.GetArticle(0);
            Article coca = controller.GetArticle(1);
            Article mcCallan = controller.GetArticle(2);
            Article gordon750ml = controller.GetArticle(3);
            Article jaegerMaster = controller.GetArticle(4);

            //Ajout de 5 suzes
            for (int i = 0; i < 5; i++) {
                controller.AddInput(suze, suze.CostByDefault);
            }

            //Ajout de 3 coca
            for (int i = 0; i < 3; i++)
            {
                controller.AddInput(coca, coca.CostByDefault);
            }

            //Deux suze entrée il y a 2 mois
            controller.GetEntries()[0].Date = DateTime.Now.AddMonths(-2);
            controller.GetEntries()[1].Date = DateTime.Now.AddMonths(-2);

            //Une suze entrée il y a 1 mois
            controller.GetEntries()[2].Date = DateTime.Now.AddMonths(-1);

            //Ajout de 1 McCallan
            controller.AddInput(mcCallan, mcCallan.CostByDefault);

            //Retrait de 2 suzes
            for (int i = 0; i < 2; i++)
            {
                controller.AddOutput(suze);
            }

            //Test pour GIT, ajout d'un GIN
            controller.AddInput(gordon750ml, gordon750ml.CostByDefault);
        }
    }
}