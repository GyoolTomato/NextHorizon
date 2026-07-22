using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;

namespace Data
{
    public class TableDataLoader : Singleton<TableDataLoader>
    {
        public Dictionary<int, _100_CommonValues.Values> _dic_100_CommonValues = new Dictionary<int, _100_CommonValues.Values>();
        public List<_100_CommonValues.Values> _list_100_CommonValues = new List<_100_CommonValues.Values>();
        public Dictionary<int, _101_Items.Values> _dic_101_Items = new Dictionary<int, _101_Items.Values>();
        public List<_101_Items.Values> _list_101_Items = new List<_101_Items.Values>();
        public Dictionary<int, _102_Character.Values> _dic_102_Character = new Dictionary<int, _102_Character.Values>();
        public List<_102_Character.Values> _list_102_Character = new List<_102_Character.Values>();
        public Dictionary<int, _103_CharacterSkills.Values> _dic_103_CharacterSkills = new Dictionary<int, _103_CharacterSkills.Values>();
        public List<_103_CharacterSkills.Values> _list_103_CharacterSkills = new List<_103_CharacterSkills.Values>();
        public Dictionary<int, _104_Missions.Values> _dic_104_Missions = new Dictionary<int, _104_Missions.Values>();
        public List<_104_Missions.Values> _list_104_Missions = new List<_104_Missions.Values>();
        public Dictionary<int, _105_Armors.Values> _dic_105_Armors = new Dictionary<int, _105_Armors.Values>();
        public List<_105_Armors.Values> _list_105_Armors = new List<_105_Armors.Values>();
        public Dictionary<int, _106_Weapons.Values> _dic_106_Weapons = new Dictionary<int, _106_Weapons.Values>();
        public List<_106_Weapons.Values> _list_106_Weapons = new List<_106_Weapons.Values>();
        public Dictionary<int, _107_CharacterLevel.Values> _dic_107_CharacterLevel = new Dictionary<int, _107_CharacterLevel.Values>();
        public List<_107_CharacterLevel.Values> _list_107_CharacterLevel = new List<_107_CharacterLevel.Values>();
        public Dictionary<int, _800_Notice.Values> _dic_800_Notice = new Dictionary<int, _800_Notice.Values>();
        public List<_800_Notice.Values> _list_800_Notice = new List<_800_Notice.Values>();
        public Dictionary<int, _900_TextCommon.Values> _dic_900_TextCommon = new Dictionary<int, _900_TextCommon.Values>();
        public List<_900_TextCommon.Values> _list_900_TextCommon = new List<_900_TextCommon.Values>();
        public Dictionary<int, _901_TextCharacter.Values> _dic_901_TextCharacter = new Dictionary<int, _901_TextCharacter.Values>();
        public List<_901_TextCharacter.Values> _list_901_TextCharacter = new List<_901_TextCharacter.Values>();
        public Dictionary<int, _902_TextNotice.Values> _dic_902_TextNotice = new Dictionary<int, _902_TextNotice.Values>();
        public List<_902_TextNotice.Values> _list_902_TextNotice = new List<_902_TextNotice.Values>();
        public Dictionary<int, _903_TextMissions.Values> _dic_903_TextMissions = new Dictionary<int, _903_TextMissions.Values>();
        public List<_903_TextMissions.Values> _list_903_TextMissions = new List<_903_TextMissions.Values>();
        public Dictionary<int, _904_TextItems.Values> _dic_904_TextItems = new Dictionary<int, _904_TextItems.Values>();
        public List<_904_TextItems.Values> _list_904_TextItems = new List<_904_TextItems.Values>();
        public Dictionary<int, _905_TextSkills.Values> _dic_905_TextSkills = new Dictionary<int, _905_TextSkills.Values>();
        public List<_905_TextSkills.Values> _list_905_TextSkills = new List<_905_TextSkills.Values>();
        public Dictionary<int, _999_TextSystem.Values> _dic_999_TextSystem = new Dictionary<int, _999_TextSystem.Values>();
        public List<_999_TextSystem.Values> _list_999_TextSystem = new List<_999_TextSystem.Values>();


        public void Init()
        {
            var temp_100_CommonValues = JsonConvert.DeserializeObject<List<_100_CommonValues.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_100_CommonValues.bytes").text);
            foreach (var item in temp_100_CommonValues)
            {
                _list_100_CommonValues.Add(item);
                _dic_100_CommonValues.Add(item.key, item);
            }
            var temp_101_Items = JsonConvert.DeserializeObject<List<_101_Items.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_101_Items.bytes").text);
            foreach (var item in temp_101_Items)
            {
                _list_101_Items.Add(item);
                _dic_101_Items.Add(item.key, item);
            }
            var temp_102_Character = JsonConvert.DeserializeObject<List<_102_Character.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_102_Character.bytes").text);
            foreach (var item in temp_102_Character)
            {
                _list_102_Character.Add(item);
                _dic_102_Character.Add(item.key, item);
            }
            var temp_103_CharacterSkills = JsonConvert.DeserializeObject<List<_103_CharacterSkills.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_103_CharacterSkills.bytes").text);
            foreach (var item in temp_103_CharacterSkills)
            {
                _list_103_CharacterSkills.Add(item);
                _dic_103_CharacterSkills.Add(item.key, item);
            }
            var temp_104_Missions = JsonConvert.DeserializeObject<List<_104_Missions.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_104_Missions.bytes").text);
            foreach (var item in temp_104_Missions)
            {
                _list_104_Missions.Add(item);
                _dic_104_Missions.Add(item.key, item);
            }
            var temp_105_Armors = JsonConvert.DeserializeObject<List<_105_Armors.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_105_Armors.bytes").text);
            foreach (var item in temp_105_Armors)
            {
                _list_105_Armors.Add(item);
                _dic_105_Armors.Add(item.key, item);
            }
            var temp_106_Weapons = JsonConvert.DeserializeObject<List<_106_Weapons.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_106_Weapons.bytes").text);
            foreach (var item in temp_106_Weapons)
            {
                _list_106_Weapons.Add(item);
                _dic_106_Weapons.Add(item.key, item);
            }
            var temp_107_CharacterLevel = JsonConvert.DeserializeObject<List<_107_CharacterLevel.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_107_CharacterLevel.bytes").text);
            foreach (var item in temp_107_CharacterLevel)
            {
                _list_107_CharacterLevel.Add(item);
                _dic_107_CharacterLevel.Add(item.key, item);
            }
            var temp_800_Notice = JsonConvert.DeserializeObject<List<_800_Notice.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_800_Notice.bytes").text);
            foreach (var item in temp_800_Notice)
            {
                _list_800_Notice.Add(item);
                _dic_800_Notice.Add(item.key, item);
            }
            var temp_900_TextCommon = JsonConvert.DeserializeObject<List<_900_TextCommon.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_900_TextCommon.bytes").text);
            foreach (var item in temp_900_TextCommon)
            {
                _list_900_TextCommon.Add(item);
                _dic_900_TextCommon.Add(item.key, item);
            }
            var temp_901_TextCharacter = JsonConvert.DeserializeObject<List<_901_TextCharacter.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_901_TextCharacter.bytes").text);
            foreach (var item in temp_901_TextCharacter)
            {
                _list_901_TextCharacter.Add(item);
                _dic_901_TextCharacter.Add(item.key, item);
            }
            var temp_902_TextNotice = JsonConvert.DeserializeObject<List<_902_TextNotice.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_902_TextNotice.bytes").text);
            foreach (var item in temp_902_TextNotice)
            {
                _list_902_TextNotice.Add(item);
                _dic_902_TextNotice.Add(item.key, item);
            }
            var temp_903_TextMissions = JsonConvert.DeserializeObject<List<_903_TextMissions.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_903_TextMissions.bytes").text);
            foreach (var item in temp_903_TextMissions)
            {
                _list_903_TextMissions.Add(item);
                _dic_903_TextMissions.Add(item.key, item);
            }
            var temp_904_TextItems = JsonConvert.DeserializeObject<List<_904_TextItems.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_904_TextItems.bytes").text);
            foreach (var item in temp_904_TextItems)
            {
                _list_904_TextItems.Add(item);
                _dic_904_TextItems.Add(item.key, item);
            }
            var temp_905_TextSkills = JsonConvert.DeserializeObject<List<_905_TextSkills.Values>>(Manager_Addressable.Instance.GetTable("Assets/Tables/_905_TextSkills.bytes").text);
            foreach (var item in temp_905_TextSkills)
            {
                _list_905_TextSkills.Add(item);
                _dic_905_TextSkills.Add(item.key, item);
            }
        }

    }
}