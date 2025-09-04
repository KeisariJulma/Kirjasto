class Kirja
{
    public string Nimi { get; set; }
    public string Kirjoittaja { get; set; }
    public int Julkaisuvuosi { get; set; }
    public string Genre { get; set; }

    public Kirja(string nimi, string kirjoittaja, int julkaisuvuosi, string genre)
    {
        Nimi = nimi;
        Kirjoittaja = kirjoittaja;
        Julkaisuvuosi = julkaisuvuosi;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Nimi}, {Kirjoittaja}, {Julkaisuvuosi}, {Genre}";
    }
}

class Kirjasto
{
    static List<Kirja> kirjat = new List<Kirja>();
    
    static void Main()
    {
        Console.WriteLine("Tervetuloa kirjastoon!");
        Console.WriteLine("1. Lisää kirja\n2. Poista kirja\n3. Näytä kirjat\n4. Näytä kirjat genren mukaan\n5. Etsi kirjoja kirjoittajan tai nimen perusteella\n6. Tallenna kirjat tiedostoon\n7. Poistu.");
        int valinta = int.Parse(Console.ReadLine());
        switch (valinta)
        {
            case 1:
                Console.WriteLine("Lisää kirja");
                string[] tiedot = Tiedot();

                Kirja uusiKirja = new Kirja(tiedot[0], tiedot[1], int.Parse(tiedot[2]), tiedot[3]);
                kirjat.Add(uusiKirja);
                Console.WriteLine("Kirja lisätty.");
                break;
            case 2:
                PoistaKirja();
                break;
            case 3:
                Console.WriteLine("Näytä kirjat");
                foreach (var kirja in kirjat)
                {
                    Console.WriteLine(kirja);
                }

                break;
            case 4:
                Console.WriteLine("Etsi kirjat genren mukaan");
                Console.WriteLine("Anna genre:");
                string genre = Console.ReadLine();
                var genreKirjat = kirjat.Where(k => k.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var kirja in genreKirjat)
                {
                    Console.WriteLine(kirja);
                }

                break;
            case 5:
                EtsiKirjaNimellaTaiKirjoittajalla();
                break;
            case 6:
                Console.WriteLine("Tallenna kirjat tiedostoon");
                using (StreamWriter sw = new StreamWriter("kirjat.txt"))
                {
                    foreach (var kirja in kirjat)
                    {
                        sw.WriteLine(kirja);
                    }
                }

                break;
        }

    }
    
    
    static void PoistaKirja()
    {
        Console.WriteLine("Poista kirja");
        foreach (var kirja in kirjat)
        {
            Console.WriteLine(kirja);
        }

        Console.WriteLine("Anna poistettavan kirjan nimi:");
        string poistettavaNimi = Console.ReadLine();
        Kirja poistettavaKirja = kirjat.Find(k => k.Nimi == poistettavaNimi);
        if (poistettavaKirja != null)
        {
            kirjat.Remove(poistettavaKirja);
            Console.WriteLine("Kirja poistettu.");
        }
    }

    static string[] Tiedot()
    {
        while (true)
        {
            Console.WriteLine("Anna nimi, kirjoittaja, julkaisuvuosi ja genre.");
            string kirjan_tiedot = Console.ReadLine();
        
            string[] tiedot = kirjan_tiedot.Split(',');
            if (tiedot.Length != 4)
            {
                Console.WriteLine("Virhe: Anna tiedot muodossa 'nimi, kirjoittaja, julkaisuvuosi, genre'.");
                continue;
            }
            return tiedot;
        }
    }
    
    
    static void EtsiKirjaNimellaTaiKirjoittajalla()
    {
        Console.WriteLine("Etsi kirjoja kirjoittajan tai nimen perusteella");
        Console.WriteLine("Anna hakusana:");
        string hakusana = Console.ReadLine();
        var hakutulokset = kirjat.Where(k =>
            k.Nimi.Contains(hakusana, StringComparison.OrdinalIgnoreCase) ||
            k.Kirjoittaja.Contains(hakusana, StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var kirja in hakutulokset)
        {
            Console.WriteLine(kirja);
        }
    }
}