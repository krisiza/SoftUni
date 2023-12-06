using _3.Raiding.Core.Interfaces;
using _3.Raiding.Factories.Interfaces;
using _3.Raiding.IO.Interfaces;
using _3.Raiding.Models.Interfaces;

namespace _3.Raiding.Core
{
    public class Engine : IEngine
    {
        IWriter writer;
        IReader reader;
        IHeroFactory heroFactory;

        ICollection<IBaseHero> baseHeros;
        public Engine(IWriter writer, IReader reader, IHeroFactory heroFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.heroFactory = heroFactory;

            baseHeros= new List<IBaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            while(n > 0)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();

                try
                {
                    IBaseHero baseHero = heroFactory.CreateHero(type, name);
                    baseHeros.Add(baseHero);
                    n--;
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            int sumPower = 0;
            foreach(var hero in baseHeros) 
            {
                writer.WriteLine(hero.CastAbility());
                sumPower += hero.Power;
            }

            if(sumPower >= bossPower) 
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
