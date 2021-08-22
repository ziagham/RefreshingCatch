using System;
using System.Collections.Generic;

namespace RefreshingCatch.CatchService
{
    public class CatchItem
    {
        public CatchItem(string value)
        {
            Value = value;
            LastAccessTime = DateTime.Now;
        }
        
        public string Value { get; set; }
        public DateTime LastAccessTime { get; set; }
    }
}
