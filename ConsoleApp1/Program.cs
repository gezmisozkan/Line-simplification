using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

public class Veri
{
    public List<Cooordinate> HatKoordinatlari { get; set; }
    public class Cooordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

public class Program
{
    public static void Main()
    {
    }
}