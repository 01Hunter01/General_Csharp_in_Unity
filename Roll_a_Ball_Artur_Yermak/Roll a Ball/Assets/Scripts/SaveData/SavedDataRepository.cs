using System.Data;
using System.IO;
using UnityEngine;

namespace MyGame
{ 
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        //private InteractiveObject bonus;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new SerializableXMLData<SavedData>();
            }
            else
            {
                _data = new XMLData();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = "ArturY",
                IsEnabled = true,
                SpeedBall = player.speed,
                //bonuse = bonus.GetComponent<GoodBonus>()
            };
            _data.Save(savePlayer, Path.Combine(_path, _fileName));
            Debug.Log("<color=green>Save</color>");
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);
            player.speed = newPlayer.SpeedBall;
            //bonus =
            Debug.Log(newPlayer);
        }
    }
}