using System;
using System.Collections.Generic;

namespace DecoratorDesignPatternVaja
{
    class Program
    {
        static void Main(string[] args)
        {
            Avtomobil chevy = new Avtomobil("Chevrolet","Cruze","diesel",210);
            chevy.IzpisiPodatke();

            Console.WriteLine();

            VoziloVAvtoParku avp = new VoziloVAvtoParku(chevy);
            avp.DodajRegistrskoOznacbo("GO DT-302");
            avp.DodajRegistrskoOznacbo("LJ SI-123");

            avp.IzpisiPodatke();
        }

        public abstract class Vozilo {
            private string _znamka;
            private string _model;

            public string znamka {
                get { return _znamka; }
                set { _znamka = znamka; }
            }

            public string model
            {
                get { return _model; }
                set { _model = model; }
            }

            public Vozilo()
            {
                _znamka = "UNK";
                _model = "UNK";
            }

            public Vozilo(string znamkaVozila, string modelVozila) {
                _znamka = znamkaVozila;
                _model = modelVozila;
            }

            public virtual void IzpisiPodatke() {
                Console.WriteLine($"Znamka vozila: {_znamka}");
                Console.WriteLine($"Model vozila: {_model}");
            }
        }

        public class Avtomobil : Vozilo
        {
            private string _gorivo;
            private int _najvisjaHitrost;

            public string gorivo
            {
                get { return _gorivo; }
                set { _gorivo = gorivo; }
            }

            public int najvisjaHitrost
            {
                get { return _najvisjaHitrost; }
                set { _najvisjaHitrost = najvisjaHitrost; }
            }
            public Avtomobil(string znamkaVozila,
                string modelVozila,
                string gorivoA,
                int najvisjaHitrostA) : base(znamkaVozila, modelVozila)
            {
                _gorivo = gorivoA;
                _najvisjaHitrost = najvisjaHitrostA;
            }

            public override void IzpisiPodatke()
            {
                Console.WriteLine("Tip vozial:Avtomobil");
                base.IzpisiPodatke();
                Console.WriteLine($"Gorivo: {_gorivo}");
                Console.WriteLine($"Najvisja hitrost: {_najvisjaHitrost}");
            }


        }

        public abstract class VoziloDecorator:Vozilo
        {
            protected Vozilo vozilo;
            protected int _steviloVozil = 0;

            public VoziloDecorator(Vozilo vozilo):base() {
                this.vozilo = vozilo;
            }


            public override void IzpisiPodatke()
            {
                vozilo.IzpisiPodatke();
                
            }
        }

        public class VoziloVAvtoParku : VoziloDecorator {
            protected List<string> registrskaOznacba = new List<string>();

            public VoziloVAvtoParku(Vozilo vozilo):base(vozilo) {
                
            }

            public void DodajRegistrskoOznacbo(string regOznacba) {
                registrskaOznacba.Add(regOznacba);
                _steviloVozil++;
            }

            public void OdstraniRegistrskoOznacbo(string regOznacba)
            {
                registrskaOznacba.Remove(regOznacba);
                _steviloVozil--;
            }

            public override void IzpisiPodatke()
            {
                base.IzpisiPodatke();
                Console.WriteLine($"Stevilo vozil: {_steviloVozil}");
                foreach (string regO in registrskaOznacba) {
                    Console.WriteLine(regO);
                }
            }
        }
    }
}
