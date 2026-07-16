using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class _903_TextMissions
{
    public class Values
    {
        public int key { private set; get; }
        public string korean { private set; get; }
        public string english { private set; get; }
        public string japanese { private set; get; }

        [JsonConstructor]
        public Values(int key,string korean,string english,string japanese)
        {
            this.key = key;
            this.korean = korean;
            this.english = english;
            this.japanese = japanese;
        }
    }

    public static _903_TextMissions.Values GetItem(int key)
    {
        if (Data.TableDataLoader.Instance._dic_903_TextMissions.ContainsKey(key))
            return Data.TableDataLoader.Instance._dic_903_TextMissions[key];
        else
            return null;
    }


    public static List<_903_TextMissions.Values> GetList()
    {
        return Data.TableDataLoader.Instance._list_903_TextMissions;
    }
}