using System;

namespace BridgeVaja2jaz
{
    class Program
    {
        static void Main(string[] args)
        {
            //primer v Win uporabljaš tako
            Pot link1w = new AbsolutnaPot(new PotWin()) {Root="C:", Mapa="programiranje1", Datoteka="Kukulele.cs" };
            link1w.IzpisiPot();

            //primer v Linux
            Pot link1l = new AbsolutnaPot(new PotLinux()) { Root = "/home", Mapa = "programiranje1", Datoteka = "Kukulele.cs" };
            link1l.IzpisiPot();

            Pot link2l = new RelativnaPot(new PotLinux()) { Mapa = "programiranje1", Datoteka = "Kukulele.cs" };
            link2l.IzpisiPot();
        }

        public interface IOSBridgeFormater{
            string VrniPot(string root, string mapa, string datoteka);
        }

        public class PotWin : IOSBridgeFormater
        {
            public string VrniPot(string root, string mapa, string datoteka)
            {
                return $"{root}\\{mapa}\\{datoteka}";
            }
        }

        public class PotLinux : IOSBridgeFormater
        {
            public string VrniPot(string root, string mapa, string datoteka)
            {
                return $"{root}/{mapa}/{datoteka}";
            }
        }

        public abstract class Pot
        {
            protected IOSBridgeFormater _osbridgeformater;
            public string Root { get; set; }
            public string Mapa { get; set; }
            public string Datoteka { get; set; }
            
            public Pot(IOSBridgeFormater osbridgeformater)
            {
                _osbridgeformater = osbridgeformater;
            }

            public abstract void IzpisiPot();

        }

        public class AbsolutnaPot : Pot
        {
            public AbsolutnaPot(IOSBridgeFormater osbridgeformater) : base(osbridgeformater) {

            }
            public override void IzpisiPot()
            {
                Console.WriteLine(_osbridgeformater.VrniPot(this.Root,this.Mapa,this.Datoteka));
            }
        }

        public class RelativnaPot : Pot
        {
            public RelativnaPot(IOSBridgeFormater osbridgeformater) : base(osbridgeformater)
            {

            }
            public override void IzpisiPot()
            {
                Console.WriteLine(_osbridgeformater.VrniPot(".", this.Mapa, this.Datoteka));
            }
        }


    }
}
