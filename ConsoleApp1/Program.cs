using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

public class Veri
{
    public List<Cooordinate> HatKoordinatlari { get; set; }

    public class Cooordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

public static class ReadJson
{
    public static List<(double, double)> ReadData()
    {
        string jsonFilePath = "testVerisi2.json";

        string jsonData = File.ReadAllText(jsonFilePath);

        Veri veri = JsonConvert.DeserializeObject<Veri>(jsonData);

        List<(double x, double y)> list = new();

        foreach (var koordinat in veri.HatKoordinatlari)
        {
            list.Add((koordinat.X, koordinat.Y));
        }
        return list;
    }
}




public class Program
{
    public static List<(double x, double y)> simplyfied_list = new();
    static double tolearance = 100;
    // x0 y0 is point and x1,y1 x2,y2 are points of line
    static double Calculate_distance_to_line(double x0, double y0, double x1, double y1, double x2, double y2)
    {
        double nominaotor = Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1));

        double denominator = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

        var res = nominaotor / denominator;
        return res;
    }
    public static void Simplify_points(List<(double x, double y)> list, int first_index, int last_index)
    {
        double max = 0;
        int chech_index = 0;
        for (int i = first_index + 1; i < last_index; i++)
        {
            double distance = Calculate_distance_to_line(list[i].x, list[i].y, list[first_index].x, list[first_index].y, list[last_index].x, list[last_index].y);
            if (distance > max)
            {
                max = distance;
                chech_index = i;
            }
        }
        bool flag = false;
        if (max < tolearance)
            flag = true;
        if (!flag)
        {
            Simplify_points(list, first_index, chech_index);
            simplyfied_list.Add((list[chech_index].x, list[chech_index].y));
            Simplify_points(list, chech_index, last_index);
        }
        return;
    }
    public static void Main()
    {
        //List<(double x, double y)> newList = ReadJson.ReadData();

        //simplyfied_list.Add((newList[0].x, newList[0].y));
        //Simplify_points(newList, 0, newList.Count() - 1);
        //simplyfied_list.Add((newList[newList.Count() - 1].x, newList[newList.Count() - 1].y));
        //Console.WriteLine("SadelestirilmisHat: ");
        //foreach (var item in simplyfied_list)
        //{
        //    Console.WriteLine("X: " + item.x + ",  Y: " + item.y);
        //}
    }
}