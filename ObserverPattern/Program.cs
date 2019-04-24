using System;
using System.Collections.Generic;

namespace ObserverVaja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pozdravljeni!");

            Delavnica del1 = new Delavnica("Servis Miha", 299.9);
            Delavnica del2 = new Delavnica("ServisMjask", 33.1);

            Avtodeli adel1 = new Odbijac(300);
            Avtodeli adel2 = new Guma(55);
            Avtodeli adel3 = new Guma(80);

            adel1.Pripni(del1);
            adel1.Pripni(del2);

            adel2.Pripni(del1);
            adel2.Pripni(del2);

            adel3.Pripni(del1);
            adel3.Pripni(del2);

            adel1.Cena = 286;
            adel2.Cena = 77;
            adel3.Cena = 78;

        }

        /// <summary>
        /// abstraktni razred za avtodele
        /// </summary>
        public abstract class Avtodeli
        {
            int _cena;
            List<IDelavnica> _seznamDelavnic = new List<IDelavnica>();

            public Avtodeli(int cena) {

            }

            public void Pripni(IDelavnica delavnica)
            {
                _seznamDelavnic.Add(delavnica);
            }

            public void Odpni(IDelavnica delavnica)
            {
                _seznamDelavnic.Remove(delavnica);
            }

            public void Obvesti()
            {
                foreach (IDelavnica delavnica in _seznamDelavnic)
                {
                    delavnica.Posodobi(this);
                }
            }

            public int Cena {
                get{ return _cena;}
                set
                {
                    if (value != _cena && value >= 0)
                    {
                        _cena = value;
                        Obvesti();
                    }
                }
            }
        }

        class Odbijac : Avtodeli
        {
            public Odbijac(int cena) : base(cena)
            {
            }
        }

        class Guma : Avtodeli
        {
            public Guma(int cena) : base(cena)
            {
            }
        }

        public interface IDelavnica
        {
            void Posodobi(Avtodeli avtodel);
        }

        public class Delavnica : IDelavnica
        {
            private string _name;
            private Delavnica _avtodel;
            private double _pragNakupa;

            public Delavnica(string name, double pragNakupa)
            {
                _name = name;
                _pragNakupa = pragNakupa;
            }

            public void Posodobi(Avtodeli avtodel)
            {
                Console.WriteLine("--> Obvestil {0}, da se je cena {1} spremenila. Nov cena {2:C}.", _name, avtodel.GetType().Name, avtodel.Cena);
                if (avtodel.Cena < _pragNakupa)
                {
                    Console.WriteLine("<-- "+ _name + ": kupim " + avtodel.GetType().Name + "!");
                }
                else
                {
                    Console.WriteLine($"<-- {_name}: predrago!");
                }
            }
        }
    }
}
