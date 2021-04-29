using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AveragesApi
{
    public interface IAveragesManager
    {
        List<double> ComputeMovingAverage(int window, List<double> values);

    }
}
