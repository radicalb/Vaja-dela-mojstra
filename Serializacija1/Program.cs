using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections;

namespace Serializacija1
{ 
    [Serializable()]
    public class Uporabnik : ISerializable
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Eposta { get; set; }
        public NaslovUporabnika Naslov;

        //konstruktor
        public Uporabnik()
        {
            Ime = "Ni podatka";
            Priimek = "Ni podatka";
            Eposta = "Ni podatka";
            NaslovUporabnika Naslov = new NaslovUporabnika();
        }

        public Uporabnik(string ime, string priimek, string eposta, NaslovUporabnika naslov1)
        {
            Ime = ime;
            Priimek = priimek;
            Eposta = eposta;
            Naslov = naslov1;
        }

        public Uporabnik(string ime, string priimek, string eposta, string naslov, string posta, string drzava)
        {
            Ime = ime;
            Priimek = priimek;
            Eposta = eposta;
            NaslovUporabnika Naslov = new NaslovUporabnika(naslov, posta, drzava);
        }

        //serilizacija
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ime", Ime);
            info.AddValue("Priimek", Priimek);
            info.AddValue("Eposta", Eposta);
            info.AddValue("Naslov1", Naslov.UlicaInHST);
            info.AddValue("Naslov2", Naslov.PSTinPosta);
            info.AddValue("Naslov3", Naslov.Drzava);
        }
        //deserilizacija
        public Uporabnik(SerializationInfo info, StreamingContext context)
        {
            Ime = (string)info.GetValue("Ime", typeof(string));
            Priimek = (string)info.GetValue("Priimek", typeof(string));
            Eposta = (string)info.GetValue("Eposta", typeof(string));
            Naslov = new NaslovUporabnika(
                (string)info.GetValue("Naslov1", typeof(string)),
                (string)info.GetValue("Naslov2", typeof(string)),
                (string)info.GetValue("Naslov3", typeof(string))
                );
        }

        //izpis
        public override string ToString()
        {
            return this.Ime+" "+this.Priimek+"\n" + this.Eposta+"\n"+ Naslov.ToString();
            //return this.Ime + " " + this.Priimek + "\n" + this.Eposta + "\n";
        }

    }

    public class NaslovUporabnika
    {
        //properties
        public string UlicaInHST { get; set; }
        public string PSTinPosta { get; set; }
        public string Drzava { get; set; }

        //konstruktorji
        public NaslovUporabnika()
        {
            UlicaInHST = "Ni podatka";
            PSTinPosta = "Ni podatka";
            Drzava = "Ni podatka";
        }
        public NaslovUporabnika(string naslov, string posta, string drzava)
        {
            UlicaInHST = naslov;
            PSTinPosta = posta;
            Drzava = drzava;
        }

        public override string ToString()
        {
            return this.UlicaInHST + ", " + this.PSTinPosta + ", " + this.Drzava;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Uporabnik bowser = new Uporabnik("Urban", "Kravos", "urban.k@kukulele.si",new NaslovUporabnika("Brdovo 65", "5555 Brdovo pri Zmrdovem", "SVN"));

            // Serialize the object data to a file
            Stream stream = File.Open(@"C:\Programiranje1\AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            // Send the object data to the file
            bf.Serialize(stream, bowser);
            stream.Close();

            // Delete the bowser data
            bowser = null;

            // Read object data from the file
            stream = File.Open(@"C:\Programiranje1\AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();

            bowser = (Uporabnik)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine(bowser.ToString());

            // XmlSerializer writes object data as XML
            XmlSerializer serializer = new XmlSerializer(typeof(Uporabnik));
            using (TextWriter tw = new StreamWriter(@"C:\Programiranje1\bowser.xml"))
            {
                serializer.Serialize(tw, bowser);
            }

            // Delete bowser data
            bowser = null;

            // Deserialize from XML to the object
            XmlSerializer deserializer = new XmlSerializer(typeof(Uporabnik));
            TextReader reader = new StreamReader(@"C:\Programiranje1\bowser.xml");
            object obj = deserializer.Deserialize(reader);
            bowser = (Uporabnik)obj;
            reader.Close();

            Console.WriteLine(bowser.ToString());

        }
    }
}
