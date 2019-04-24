using System;
using System.Linq;
using System.Collections.Generic;

public class Misija
{
    public string Naziv;
    public int idKontrolorja_FK;
    public Misija(string Naziv = "", int idKontrolorja_FK = 0)
    {
        this.Naziv = Naziv;
        this.idKontrolorja_FK = idKontrolorja_FK;
    }
}

public class Kontrolor
{
    public string Ime;
    public string Priimek;
    public int idKontrolorja_PK;
    public Kontrolor(string Ime = "Brez", string Priimek = "Brez", int idKontrolorja_PK = 0)
    {
        this.Ime = Ime;
        this.Priimek = Priimek;
        this.idKontrolorja_PK = idKontrolorja_PK;
    }
}

public class MisijaKontrolor
{
    public string nazivMisije { get; set; }
    public string kontrolorMisije { get; set; }
}

public class Program
{
    static void IzpisiMisijeKontrolorja(List<MisijaKontrolor> kontrolorjiMisij, string kontrolorIme)
    {
        Console.WriteLine("Izpiši misije kontrolorja: " + kontrolorIme);
        var misijeUK = kontrolorjiMisij.Where(x => x.kontrolorMisije == kontrolorIme);
        foreach (var misa in misijeUK)
        {
            Console.WriteLine(misa.nazivMisije);
        }
    }


    public static void Main()
    {

        Kontrolor[] listaKontrolorjev = new[] { new Kontrolor { Ime = "Urban", Priimek = "Kravos", idKontrolorja_PK = 1 }, new Kontrolor { Ime = "Miha", Priimek = "Rdecko", idKontrolorja_PK = 2 }, new Kontrolor { Ime = "Iztok", Priimek = "Mlakar", idKontrolorja_PK = 3 } };
        Misija[] seznamMisij = new[] { new Misija { Naziv = "NATO TSCR 01APR19", idKontrolorja_FK = 1 }, new Misija { Naziv = "SVN TSCR 01APR19", idKontrolorja_FK = 1 }, new Misija { Naziv = "SKUNK 09APR19", idKontrolorja_FK = 2 }, new Misija { Naziv = "SKUNK 09APR19", idKontrolorja_FK = 3 }, new Misija { Naziv = "NATO TSCR 15APR19", idKontrolorja_FK = 1 }, };

        var kontrolorjiMisij =
            from kontr in listaKontrolorjev
            join mis in seznamMisij on kontr.idKontrolorja_PK equals mis.idKontrolorja_FK
            select new MisijaKontrolor
            {
                kontrolorMisije = kontr.Ime + " " + kontr.Priimek,
                nazivMisije = mis.Naziv
            };

        foreach (var zap in kontrolorjiMisij)
        {
            Console.WriteLine("Misijo " + zap.nazivMisije + " kontroliral " + zap.kontrolorMisije);
        }

        IzpisiMisijeKontrolorja(kontrolorjiMisij.ToList(), "Urban Kravos");

    }
     
}