namespace EncapsulationExercise
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            Pizza pizza = null;
            List<Topping> toppings = new List<Topping>();

            string[] pizzaType = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            string[] doughType = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Dough dough = new(doughType[1], doughType[2], double.Parse(doughType[3]));
                    pizza = new(pizzaType[1], dough);

                    Topping topping = new(tokens[1], double.Parse(tokens[2]));

                    toppings.Add(topping);                   

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            try
            {
                pizza.AddTopping(toppings);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (pizza != null)
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.\r\n");
        }
    }
}