class Program
{
    public static void Main()
    {
        Console.WriteLine("Masukkan tipe karyawan (Tetap/Kontrak/Magang):");
        string tipe = Console.ReadLine();

        Console.WriteLine("Masukkan nama karyawan:");
        string namaKaryawan = Console.ReadLine();

        Console.WriteLine("Masukkan ID karyawan:");
        string idKaryawan = Console.ReadLine();

        Console.WriteLine("Masukkan gaji pokok:");
        double gajiDasar = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        if (tipe.ToLower() == "tetap")
        {
            karyawan = new Karyawan_Tetap(namaKaryawan, idKaryawan, gajiDasar);
            TampilkanInformasiKaryawan(karyawan, "Karyawan Tetap");
        }
        else if (tipe.ToLower() == "kontrak")
        {
            karyawan = new Karyawan_Kontrak(namaKaryawan, idKaryawan, gajiDasar);
            TampilkanInformasiKaryawan(karyawan, "Karyawan Kontrak");
        }
        else if (tipe.ToLower() == "magang")
        {
            karyawan = new Karyawan_Magang(namaKaryawan, idKaryawan, gajiDasar);
            TampilkanInformasiKaryawan(karyawan, "Karyawan Magang");
        }
        else
        {
            Console.WriteLine("Tipe karyawan tidak dikenali.");
        }
    }

    private static void TampilkanInformasiKaryawan(Karyawan karyawan, string jenisKaryawan)
    {
        Console.WriteLine($"Nama : {karyawan.Nama}");
        Console.WriteLine($"ID Karyawan : {karyawan.ID}");
        Console.WriteLine($"Jenis Karyawan : {jenisKaryawan}");
        Console.WriteLine($"Gaji : {karyawan.Hitung_Gaji()}");
    }
}

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public double Gaji_Pokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }
    public virtual double Hitung_Gaji()
    {
        return gajiPokok;
    }
}

class Karyawan_Tetap : Karyawan
{
    private double bonusTetap = 500000;

    public Karyawan_Tetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double Hitung_Gaji()
    {
        return Gaji_Pokok + bonusTetap;
    }
}

class Karyawan_Kontrak : Karyawan
{
    private double potonganKontrak = 200000;

    public Karyawan_Kontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double Hitung_Gaji()
    {
        return Gaji_Pokok - potonganKontrak;
    }
}

class Karyawan_Magang : Karyawan
{
    public Karyawan_Magang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double Hitung_Gaji()
    {
        return base.Hitung_Gaji();
    }
}
