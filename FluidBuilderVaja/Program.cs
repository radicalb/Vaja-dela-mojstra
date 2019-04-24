using System;

namespace FluidBuilderVaja
{
    class Program
    {
        static void Main(string[] args)
        {
            PuskaBuilder izdelovalecPusk = new PuskaBuilder();

            Puska m16 = izdelovalecPusk
                .DodajPusko("M16")
                .ImaKaliber("5,56 mm")
                .ImaNabojevVOkvirju(30)
                .Build();

            Puska m92fs = izdelovalecPusk
                .DodajPusko("Berreta M92 FS")
                .ImaKaliber("9 mm")
                .ImaNabojevVOkvirju(15)
                .Build();

            m16.Izpisi();

            m92fs.Izpisi();

        }

        public class Puska {
            //private
            string _naziv;
            string _kaliber;
            int _nabojevVOkvirju;

            //konstruktor z vsemi mogočimi podatki
            public Puska(string naziv, string kaliber, int nabojevVOkvirju)
            {
                _naziv = naziv;
                _kaliber = kaliber;
                _nabojevVOkvirju = nabojevVOkvirju;
            }

            public void Izpisi() {
                Console.WriteLine("Puška {0} v kalibru {1}. V enem okvirju je {2} nabojev.",_naziv,_kaliber,_nabojevVOkvirju);
            }

        }

        //Fluid builder za razred Puska
        public class PuskaBuilder {
            //private
            string _naziv;
            string _kaliber;
            int _nabojevVOkvirju;

            public PuskaBuilder DodajPusko(string naziv) {
                _naziv = naziv;
                return this;
            }

            public PuskaBuilder ImaKaliber(string kaliber) {
                _kaliber = kaliber;
                return this;
            }

            public PuskaBuilder ImaNabojevVOkvirju(int nabojev){
                _nabojevVOkvirju = nabojev;
                return this;
            }

            public Puska Build() {
                return new Puska(_naziv,_kaliber,_nabojevVOkvirju);
            }

        }
    }
}
