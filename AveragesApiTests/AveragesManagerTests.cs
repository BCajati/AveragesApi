using AveragesApi;
using System;
using System.Collections.Generic;
using Xunit;

namespace AveragesApiTests
{
    public class AveragesManagerTests
    {
        [Fact]
        public void _SpecExample1Test()
        {
            var mgr = new AveragesManager();
            var values = new List<double> { 0, 1, 2, 3 };

            var movingAverages = mgr.ComputeMovingAverage(3, values);

            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(0.5, movingAverages[1]);
            Assert.Equal(1, movingAverages[2]);
            Assert.Equal(2, movingAverages[3]);
        }

        [Fact]
        public void _SpecExample2Test()
        {
            var mgr = new AveragesManager();
            var values = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };

            var movingAverages = mgr.ComputeMovingAverage(5, values);

            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(0.5, movingAverages[1]);
            Assert.Equal(-0.33333, Math.Round(movingAverages[2], 5));
            Assert.Equal(0.5, movingAverages[3]);
            Assert.Equal(-0.4, movingAverages[4]);
            Assert.Equal(0.6, movingAverages[5]);
            Assert.Equal(0.6, movingAverages[5]);
            Assert.Equal(-0.8, movingAverages[6]);
            Assert.Equal(1, movingAverages[7]);
            Assert.Equal(-1.2, movingAverages[8]);
            Assert.Equal(1.4, movingAverages[9]);


        }

        [Fact]
        public void WindowsGreaterThanInputLength()
        {
            var mgr = new AveragesManager();
            var values = new List<double> { 0, 1, 2, 3, 4 };

            var movingAverages = mgr.ComputeMovingAverage(100, values);

            Assert.Equal(5, movingAverages.Count);
            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(0.5, movingAverages[1]);
            Assert.Equal(1, movingAverages[2]);
            Assert.Equal(1.5, movingAverages[3]);
            Assert.Equal(2, movingAverages[4]);
        }

        [Fact]
        public void LargerDataSet()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);

            var movingAverages = mgr.ComputeMovingAverage(5, values);

            Assert.Equal(50, movingAverages.Count);
            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(0.5, movingAverages[1]);
            Assert.Equal(-0.33333, Math.Round(movingAverages[2], 5));
            Assert.Equal(0.5, movingAverages[3]);
            Assert.Equal(-0.4, movingAverages[4]);
        }

        [Fact]
        public void HugeDataSet()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            for (var idx = 0; idx < 1000000; idx++)
            {
                values.AddRange(valuesInit);
            }

            var movingAverages = mgr.ComputeMovingAverage(10, values);

            Assert.Equal(10000000, movingAverages.Count);
        }

        [Fact]
        public void HugeDataSet2()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            for (var idx = 0; idx < 2000000; idx++)
            {
                values.AddRange(valuesInit);
            }

            var movingAverages = mgr.ComputeMovingAverage(10, values);

            Assert.Equal(20000000, movingAverages.Count);
        }

        [Fact]
        public void HugeDataSetWindow_150()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            for (var idx = 0; idx < 2000000; idx++)
            {
                values.AddRange(valuesInit);
            }

            var movingAverages = mgr.ComputeMovingAverage(150, values);

            Assert.Equal(20000000, movingAverages.Count);
        }

        [Fact]
        public void HugeDataSetWindow_300()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            for (var idx = 0; idx < 2000000; idx++)
            {
                values.AddRange(valuesInit);
            }

            var movingAverages = mgr.ComputeMovingAverage(300, values);

            Assert.Equal(20000000, movingAverages.Count);
        }

        [Fact]
        public void LargerWindowSize()
        {
            var mgr = new AveragesManager();

            var valuesInit = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
            var values = new List<double>();
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);
            values.AddRange(valuesInit);

            var movingAverages = mgr.ComputeMovingAverage(50, values);

            Assert.Equal(50, movingAverages.Count);
            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(0.5, movingAverages[1]);
            Assert.Equal(-0.33333, Math.Round(movingAverages[2], 5));
            Assert.Equal(0.5, movingAverages[3]);
            Assert.Equal(-0.4, movingAverages[4]);
        }

        [Fact]
        public void WindowSizeOne()
        {
            var mgr = new AveragesManager();
            var values = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };

            var movingAverages = mgr.ComputeMovingAverage(1, values);

            Assert.Equal(0, movingAverages[0]);
            Assert.Equal(1, movingAverages[1]);
            Assert.Equal(-2, Math.Round(movingAverages[2], 5));
            Assert.Equal(3, movingAverages[3]);
            Assert.Equal(-4, movingAverages[4]);
            Assert.Equal(5, movingAverages[5]);
            Assert.Equal(-6, movingAverages[6]);
            Assert.Equal(7, movingAverages[7]);
            Assert.Equal(-8, movingAverages[8]);
            Assert.Equal(9, movingAverages[9]);
        }

        [Fact]
        public void InvalidWindowSize()
        {
            var mgr = new AveragesManager();
            var values = new List<double> { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };

            var movingAverages = mgr.ComputeMovingAverage(0, values);

            Assert.Null(movingAverages);

        }
    }
}
