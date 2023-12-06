namespace EncapsulationExercise
{
    internal class StartUp
    {

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleTokes = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleTokes.Length; i++)
            {
                string[] personInfo = peopleTokes[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Person person = new(personInfo[0], decimal.Parse(personInfo[1]));
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsTokens.Length; i++)
            {
                string[] productInfo = productsTokens[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Product product = new(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = people.FirstOrDefault(p => p.Name == tokens[0]);

                if (person != null)
                {
                    var product = products.FirstOrDefault(p => p.Name == tokens[1]);

                    if (product != null)
                    {
                        if (person.Money >= product.Cost)
                        {
                            person.BagOfProducts.Add(product);
                            person.Money -= product.Cost;

                            Console.WriteLine($"{person.Name} bought {product.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        }
                    }
                }
            }
            foreach (var person in people)
            {
                if (person.BagOfProducts == null || person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    break;
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
            }
        }
    }
}