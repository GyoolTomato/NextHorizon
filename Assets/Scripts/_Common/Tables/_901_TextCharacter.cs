using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class _901_TextCharacter
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

    public static _901_TextCharacter.Values GetItem(int key)
    {
        if (Data.TableDataLoader.Instance._dic_901_TextCharacter.ContainsKey(key))
            return Data.TableDataLoader.Instance._dic_901_TextCharacter[key];
        else
            return null;
    }


    public static List<_901_TextCharacter.Values> GetList()
    {
        return Data.TableDataLoader.Instance._list_901_TextCharacter;
    }
}