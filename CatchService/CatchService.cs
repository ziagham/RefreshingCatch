using System;
using System.Collections.Generic;

namespace RefreshingCatch.CatchService
{
    public class CatchService
    {
        private readonly IFetchService _fetchService;
        private readonly Dictionary<string, CatchItem> _catch;
        private readonly int _maxCacheSize;

        public CatchService(int maxCacheSize, IFetchService fetchService)
        {
            _maxCacheSize = maxCacheSize;
            _catch = new Dictionary<string, CatchItem>();

            if (fetchService == null)
                throw new ArgumentNullException("fetchService");

            _fetchService = fetchService;
        }

        public string Get(string key)
        {
            if (_catch.Count >= _maxSize)
            {
                var leastItem = LeastRecentItem();
                _catch.Remove(leastItem);
            }

            if (!_catch.ContainsKey(key))
            {
                var value = _fetchService.Fetch(key);
                _catch.Add(key, new CatchItem(value));
            }

            _catch[key].LastAccessTime = DateTime.Now;
            return _catch[key].Value;
        }

        public int Count()
        {
            return _catch.Count;
        }

        private string LeastRecentItem()
        {
            string resultKey = string.Empty;
            DateTime recentItem = DateTime.Now;
            foreach (var key in _catch.Keys)
            {
                if (_catch[key].LastAccessTime < recentItem)
                {
                    recentItem = _catch[key].LastAccessTime;
                    resultKey = key;
                }
            }
            return resultKey;
        }
    }
}
