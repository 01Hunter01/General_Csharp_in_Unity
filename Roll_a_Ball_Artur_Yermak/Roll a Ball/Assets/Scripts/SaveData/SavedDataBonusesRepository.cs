using System.Data;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{ 
    public sealed class SavedDataBonusesRepository
    {
        private readonly IData<SaveDataBonuses> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "dataBonuses.bat";
        private readonly string _path;


        public SavedDataBonusesRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new XMLDataBonuses();
            }
            else
            {
                _data = new SerializableXMLData<SaveDataBonuses>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(List<InteractiveObject> bonuses)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var saveBonuses = new SaveDataBonuses();

            foreach (var b in bonuses)
            {
                if (b is GoodBonus) 
                { 
                    bonuses.Add(b); 
                    saveBonuses.goodBonus = b.gameObject.transform; 
                }
                if (b is GoodBonusSpeedUp) 
                { 
                    bonuses.Add(b); 
                    saveBonuses.goodBonusSpeedUp = b.gameObject.transform; 
                }
                if (b is BadBonus) 
                { 
                    bonuses.Add(b); 
                    saveBonuses.badBonus = b.gameObject.transform;
                }
                if (b is BadBonusSlow) 
                { 
                    bonuses.Add(b); 
                    saveBonuses.badBonusSlow = b.gameObject.transform; 
                }
            }

            
            _data.Save(saveBonuses, Path.Combine(_path, _fileName));
            Debug.Log("<color=green>Save Bonuses</color>");
        }

        public void Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newBonuses = _data.Load(file);
            
            Debug.Log(newBonuses);
        }
    }
}