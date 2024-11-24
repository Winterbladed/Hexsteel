using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Player _player;
    //[SerializeField] protected Health _health;
    //[SerializeField] protected Inventory _inventory;
    #endregion

    #region Public Functions
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(_player /*, _health, _inventory*/);
    }

    public void LoadPlayer()
    {
        PlayerData _data = SaveSystem.LoadPlayer();

        //_health.SetCurrentHp(_data._currentHp);
        //_health.SetHp(_data._maxHp);

        Vector3 _newPosition;
        _newPosition.x = _data._position[0];
        _newPosition.y = _data._position[1];
        _newPosition.z = _data._position[2];

        _player.transform.position = _newPosition;

        //_inventory.SetInventory1(_data._inventory);
    }
    #endregion
}