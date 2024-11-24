using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public int _currentHp;
    //public int _maxHp;
    public float[] _position;
    //public List<GameObject> _inventory;

    public PlayerData (Player _Player /*, Health _Health, Inventory _Inventory*/)
    {
        //_currentHp = _Health.GetCurrentHp();
        //_maxHp = _Health.GetHp();

        _position = new float[3];
        _position[0] = _Player.transform.position.x;
        _position[1] = _Player.transform.position.y;
        _position[2] = _Player.transform.position.z;

        //_inventory = _Inventory.GetInventory();
    }
}