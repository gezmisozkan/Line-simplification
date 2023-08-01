using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestPart
{
    public class UnitTest1
    {
        List<(double x, double y)> test_Simplify_List = new() {
               (337160, 4160018),
               (334872, 4158063),
               (333794, 4156647),
               (333586, 4155840),
               (333414, 4152182),
               (333533, 4151176),
               (335365, 4148516),
               (335845, 4147569),
               (337080, 4143518),
               (337095, 4141238),
               (336729, 4139223),
               (336711, 4137924),
               (336505, 4137640),
            };
        [Fact]
        public void Test1()
        {
            List<(double x, double y)> newList = ReadJson.ReadData();
            Program.simplyfied_list.Add((newList[0].x, newList[0].y));
            Program.Simplify_points(newList, 0, newList.Count - 1);

            Program.simplyfied_list.Add((newList[newList.Count() - 1].x, newList[newList.Count() - 1].y));

            Console.WriteLine("SadelestirilmisHat: ");

            //List<(double x, double y)> TestSimplifiedList = new List<(double x, double y)>();

            Assert.Equal(test_Simplify_List, Program.simplyfied_list);


        }
    }
}