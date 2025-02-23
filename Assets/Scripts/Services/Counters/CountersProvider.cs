using System.Collections.Generic;

namespace Services.Counters
{
    public class CountersProvider
    {
        private Dictionary<string, CounterData> _allCounters = new Dictionary<string, CounterData>();
        public Dictionary<string, CounterData> AllCounters => _allCounters;

        public void CreateNewCounter(CounterData newData)
        {
            if (_allCounters.ContainsKey(newData.ID))
            {
                return;
            }
            _allCounters.Add(newData.ID, newData);
        }
 /*       
        public void AddOrUpdateCounterValue(string id, float newValue)
        {
            _allCounters[id].AddToCurrentValue(newValue);
        }
        */
    }
}