using System;

namespace FactoryVaja
{
    class Program
    {
        static void Main(string[] args)
        {
            ILik kvadrat = LikFactory.Create(LikFactory.TipLika.Kvadrat);
            kvadrat.Narisi();

            ILik trikotnik = LikFactory.Create(LikFactory.TipLika.Trikotnik);
            trikotnik.Narisi();

        }

        public interface ILik
        {
            void Narisi();
        }

        class Trikotnik : ILik
        {
            public void Narisi()
            {
                Console.WriteLine(@"/\");
                Console.WriteLine("--");
            }
        }

        class Kvadrat : ILik
        {
            public void Narisi()
            {
                Console.WriteLine(@" --");
                Console.WriteLine(@"|  |");
                Console.WriteLine(@" --");
            }
        }

        public class LikFactory
        {
            public enum TipLika
            {
                Trikotnik,
                Kvadrat
            };

            public static ILik Create(TipLika tip)
            {
                switch (tip)
                {
                    case TipLika.Trikotnik:
                        return new Trikotnik();
                    case TipLika.Kvadrat:
                        return new Kvadrat();
                    default:
                        return null;
                }
            }

        }

    }


    
}
