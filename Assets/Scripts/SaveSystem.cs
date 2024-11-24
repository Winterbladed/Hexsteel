using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player _Player /*, Health _Health, Inventory _Inventory*/)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string _path = Application.persistentDataPath + "/Player.rsol";
        FileStream _stream = new FileStream(_path, FileMode.Create);

        PlayerData _data = new PlayerData(_Player /*, _Health, _Inventory*/);

        _formatter.Serialize(_stream, _data);
        _stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string _path = Application.persistentDataPath + "/Player.rsol";
        if (File.Exists(_path))
        {
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _stream = new FileStream(_path, FileMode.Open);

            PlayerData _data = _formatter.Deserialize(_stream) as PlayerData;
            _stream.Close();
            return _data;
        }
        else
        {
            Debug.LogError("Save File not found in" + _path);
            return null;
        }
    }
}