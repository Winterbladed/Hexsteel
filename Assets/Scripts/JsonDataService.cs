using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonDataService : IDataService
{
    public bool _SaveData<T>(string _RelativePath, T _Data, bool _Encrypted)
    {
        string _path = Application.persistentDataPath + _RelativePath;
        try
        {
            if (File.Exists(_path))
            {
                Debug.Log("Data exists. Deleting old file and writing a new one!");
                File.Delete(_path);
            }
            else
            {
                Debug.Log("Creating file for the first time!");
            }
            using FileStream _stream = File.Create(_path);
            _stream.Close();
            File.WriteAllText(_path, JsonConvert.SerializeObject(_Data));
            return true;
        }
        catch (Exception _e)
        {
            Debug.LogError($"Unable to save data due to: {_e.Message} {_e.StackTrace}");
            return false;
        }
        //throw new System.NotImplementedException();
    }

    public T LoadData<T> (string _RelativePath, bool _Encrypted)
    {
        throw new System.NotImplementedException ();
    }
}