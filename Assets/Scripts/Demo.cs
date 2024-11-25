using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI _sourceDataText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _saveTimeText;
    [SerializeField] private TextMeshProUGUI _loadTimeText;

    private Player _player = new Player();
    private IDataService _dataService = new JsonDataService();
    private bool _encryptionEnabled;
    #endregion

    #region Public Functions
    public void ToggleEncryption(bool _isEncrypted)
    {
        this._encryptionEnabled = _isEncrypted;
    }

    public void SerializeJson()
    {
        if (_dataService._SaveData("/_PlayerStats.json", _player, _encryptionEnabled))
        {
            
        }
        else
        {
            Debug.LogError("Could not save file!");
            _inputField.text = "<color=#ff0000>Error saving!";
        }
    }
    #endregion

    #region Private Functions
    private void Awake()
    {
        
    }
    #endregion
}