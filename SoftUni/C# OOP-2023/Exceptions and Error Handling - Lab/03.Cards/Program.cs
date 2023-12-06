namespace _03.Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardsList = new();

            string[] cards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string c in cards) 
            {
                string[] splittedCard = c.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string face = splittedCard[0];
                string suit = splittedCard[1];

                try
                {
                    Card card = new(face, suit);
                    cardsList.Add(card);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cardsList));
        }
    }
    public class Card
    {
        private string face;
        private string suit;
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face 
        {
            get => face;

            private set
            {
                if(value.Any(char.IsLower))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }
        public string Suit 
        {
            get => suit;

            private set
            {
                if(value.Length > 1 || value.Any(char.IsLower))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = value;
            }
        }

        public override string ToString()
        {
            if (this.Suit == "S")
                return $"[{this.Face}\u2660]";
            if (this.Suit == "H")
                return $"[{this.Face}\u2665]";
            if (this.Suit == "D")
                return $"[{this.Face}\u2666]";
            if (this.Suit == "C")
                return $"[{this.Face}\u2663]";

            return null;
        }
    }
}