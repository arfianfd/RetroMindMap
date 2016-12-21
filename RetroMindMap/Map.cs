using System;
using System.Collections.Generic;

namespace RetroMindMap
{
    /* kamu tau array di PHP? ya kayak gitu */
    public class Map : Dictionary<string, System.Object>
    {

        public override string ToString()
        {
            string ans = "";
            foreach (KeyValuePair<string, object> entry in this)
            {
                ans += "[" + entry.Key + "] = " + entry.Value + "\n";
            }
            return ans;
        }
    }
}
