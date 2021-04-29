using System.Collections.Generic;
using System.Linq;

namespace AveragesApi
{
    public class AveragesManager: IAveragesManager
    {
        public List<double> ComputeMovingAverage(int window, List<double> values)
        {
            if (window < 1)
                return null;

            var averages = new List<double>();
            var skipIdx = 0;
            for (var cnt = 1; cnt <= values.Count; cnt++)
            {
                // sum up to window # of items
                var takeCnt = cnt > window ? window : cnt; 
                if (cnt > window)
                {
                    skipIdx++;
                }
     
                var avgList = values.Skip(skipIdx).Take(takeCnt).ToList();
                var avg = avgList.Sum() / avgList.Count;
                averages.Add(avg);
            }
            return averages;
        }
         

    }
}
