using BarTHDB.Exceptions;
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

            try
            {
                Console.WriteLine($"Liste des movements du dernier mois:");
                ShowItemInEntryList(controller.GetEntryInPeriod(DateTime.Now.AddMonths(-1), DateTime.Now));
                
                Console.WriteLine($"Liste des movements des deux derniers mois:");
                ShowItemInEntryList(controller.GetEntryInPeriod(DateTime.Now.AddMonths(-2), DateTime.Now));

                Console.WriteLine($"Liste des movements du mois dernier:");
                ShowItemInEntryList(controller.GetEntryInPeriod(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(-1)));

                Console.WriteLine($"Liste des entrées du dernier mois:");
                ShowItemInEntryList(ConvertListInputInEntry(controller.GetInputsInPeriod(DateTime.Now.AddMonths(-1), DateTime.Now)));

                Console.WriteLine($"Liste des entrées des deux derniers mois:");
                ShowItemInEntryList(ConvertListInputInEntry(controller.GetInputsInPeriod(DateTime.Now.AddMonths(-2), DateTime.Now)));

                Console.WriteLine($"Liste des sorties du dernier mois:");
                ShowItemInEntryList(ConvertListOutputInEntry(controller.GetOutputsInPeriod(DateTime.Now.AddMonths(-1), DateTime.Now)));

                Console.WriteLine($"Liste des sorties des deux derniers mois:");
                ShowItemInEntryList(ConvertListOutputInEntry(controller.GetOutputsInPeriod(DateTime.Now.AddMonths(-2), DateTime.Now)));
            }
            catch( InvalidPeriodException ex )
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void ShowItemInEntryList(List<Entry> entries) 
        {
            foreach(Entry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
        static List<Entry> ConvertListInputInEntry(List<Input> inputs)
        {
            List<Entry> entries = new List<Entry>();
            foreach (Input input in inputs)
            {
                entries.Add((Entry)input);
            }
            return entries;
        }

        static List<Entry> ConvertListOutputInEntry(List<Output> outputs)
        {
            List<Entry> entries = new List<Entry>();
            foreach (Output output in outputs)
            {
                entries.Add((Entry)output);
            }
            return entries;
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
            controller.GetEntries()[0].Date = DateTime.Now.AddMonths(-2).AddDays(1);
            controller.GetEntries()[1].Date = DateTime.Now.AddMonths(-2).AddDays(1);

            //Une suze entrée il y a 1 mois
            controller.GetEntries()[2].Date = DateTime.Now.AddMonths(-1).AddDays(1);

            //Ajout de 1 McCallan
            controller.AddInput(mcCallan, mcCallan.CostByDefault);

            //Retrait de 2 suzes
            for (int i = 0; i < 2; i++)
            {
                controller.AddOutput(suze);
            }
        }
    }
}