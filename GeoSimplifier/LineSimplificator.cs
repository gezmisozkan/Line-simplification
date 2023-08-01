namespace GeoSimplifier
{
    public static class LineSimplificator
    {

        public static double CalculateDistanceToLine(double x0, double y0, double x1, double y1, double x2, double y2)
        {
            double nominaotor = Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1));

            double denominator = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            var res = nominaotor / denominator;
            return res;
        }
        public static List<(double x, double y)> SimplifyPoints(List<(double x, double y)> list, int first_index, int last_index, double tolerance)
        {
            List<(double x, double y)> simplyfied_list = new List<(double x, double y)>();
            simplyfied_list.Add((list[first_index].x, list[first_index].y));
            double max = 0;
            

            int chech_index = 0;
            for (int i = first_index + 1; i < last_index; i++)
            {
                double distance = CalculateDistanceToLine(list[i].x, list[i].y, list[first_index].x, list[first_index].y, list[last_index].x, list[last_index].y);
                if (distance > max)
                {
                    max = distance;
                    chech_index = i;
                }
            }
            bool flag = false;
            if (max < tolerance)
                flag = true;
            if (!flag)
            {
                var first_half = SimplifyPoints(list, first_index, chech_index, tolerance);
                var second_half = SimplifyPoints(list, chech_index, last_index, tolerance);

                // İlk yarısı ve ikinci yarısı, ana simplyfied_list'e birleştirilir.
                simplyfied_list.AddRange(first_half.Skip(1)); // İlk elemanı eklememeliyiz çünkü zaten ana listede var.
                simplyfied_list.AddRange(second_half);
                //simplyfied_list.Add((list[list.Count() - 1].x, list[list.Count() - 1].y));
            }
            //simplyfied_list.Add((list[list.Count() - 1].x, list[list.Count() - 1].y));
           
            return simplyfied_list;
            
        }

    }
}