using GeoSimplifier;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void IsFileEmpty()
        {
            // Act and Assert
            Assert.True(LineSimplificator.IsFileEmpty("testVerisi2.json"));
        }
        [Fact]
        public void ExistenceOfEmptyValues()
        {
            // Act and Assert
            Assert.True(LineSimplificator.IsNullValue("testVerisi2.json"));
        }
        [Fact]
        public void ExistenceOfNegativeValue()
        {
            // Act and Assert
            Assert.True(LineSimplificator.IsNegative("testVerisi2.json"));

        }
        [Fact]
        public void HasDuplicateCoordinates()
        {
            // Act and Assert
            Assert.True(LineSimplificator.HasDuplicateCoordinates("testVerisi2.json"));
        }
        [Fact]
        public void SimplificationSucceed()
        {

            List<(double x, double y)> newList = LineSimplificator.ReadData("testVerisi2.json");
            List<(double x, double y)> pureList = LineSimplificator.SimplifyPoints(newList, 0, newList.Count - 1, 100);
            pureList.Add((newList[newList.Count() - 1].x, newList[newList.Count() - 1].y));
            Assert.Equal(test_Simplify_List, pureList);

        }
    }

}