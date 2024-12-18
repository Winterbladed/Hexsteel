using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory _Inventory;
    private void Awake()
    {
        if (_Inventory != null) return;
        _Inventory = this;
    }
    #endregion

    #region Variables
    [Header("Inventory Stats")]
    [SerializeField] private List<GameObject> _inventory;
    [SerializeField] private List<GameObject> _inventory1;
    [SerializeField] private Transform _hands;
    [SerializeField] private int _inventorySlots = 9;
    [SerializeField] private int _coins;

    private float _switchTime = 0.0f;
    private bool _isSwitching = false;
    private float _getTime = 0.0f;
    private bool _isGetting = false;

    private GameObject _itemToDrop;
    private GameObject _currentHeldItem;
    private int _currentHeldItemID;
    private int _inventoryIndex = 0;

    private PlayerMovement _movement;
    private InventoryUI _inventoryUI;
    #endregion

    #region Private Functions
    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _inventoryUI = InventoryUI._InventoryUI;
        if (_inventory1.Count > 0)
            foreach (GameObject _item in _inventory1)
            {
                GameObject _newItem = Instantiate(_item, _hands);
                GameObject _newItemIcon = Instantiate(_newItem.GetComponent<Item>()._ItemIcon, _inventoryUI.transform);
                _newItem.GetComponent<Item>()._ItemIcon = _newItemIcon;
                _inventory.Add(_newItem);
                _newItem.SetActive(false);
            }
    }

    private void Update()
    {
        Get();
        Switch();
        InventorySlotSwitching();
        DropItem();
    }

    private void Get()
    {
        if (_isGetting) _getTime += Time.deltaTime;
        else _getTime = 0.0f;
        if (_getTime > 0.5f)
        {
            _getTime = 0.0f;
            _isGetting = false;
        }
    }

    private void Switch()
    {
        if (_isSwitching) _switchTime += Time.deltaTime;
        else _switchTime = 0.0f;
        if (_switchTime > 0.25f)
        {
            SwitchToItem(_inventory[_inventoryIndex]);
            _switchTime = 0.0f;
            _isSwitching = false;
        }
    }

    private void InventorySlotSwitching()
    {
        if (_currentHeldItem) _currentHeldItemID = _currentHeldItem.GetInstanceID();
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()) && !_isSwitching && !_movement.GetIsDodging() && Time.timeScale > 0.0f)
            {
                _inventoryIndex = i;
                _isSwitching = true;
            }
        }
    }

    private void SwitchToItem(GameObject _item)
    {
        foreach (GameObject _item2 in _inventory)
            _item2.SetActive(false);
        _currentHeldItem = _item;
        _item.SetActive(true);
        ResetBool();
    }

    private void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !_isSwitching && Time.timeScale > 0.0f)
            DropCurrentHeldItemFromInventory();
    }
    #endregion

    #region Public Functions
    public int GetInventorySize()
    {
        return _inventory.Count;
    }

    public int GetInventorySlots()
    {
        return _inventorySlots;
    }

    public void AddSpecificItemToInventory(GameObject _item)
    {
        if (_inventory.Count < _inventorySlots && !_isSwitching)
        {
            _isGetting = true;
            _getTime = 0.0f;
            GameObject _newItem = Instantiate(_item, _hands);
            _inventory.Add(_newItem);
            SwitchToItem(_newItem);
            ResetBool();
        }
    }

    public void DropCurrentHeldItemFromInventory()
    {
        if (!_currentHeldItem) return;
        foreach (GameObject _item2 in _inventory)
        {
            if (_item2.name == _currentHeldItem.name && _item2.GetInstanceID() == _currentHeldItem.GetInstanceID() && !_isSwitching)
            {
                if (_item2.GetInstanceID() == _currentHeldItem.GetInstanceID()) _itemToDrop = _item2;
            }
        }
        _inventory.Remove(_itemToDrop);
        Instantiate(_currentHeldItem.GetComponent<Item>()._Item, _hands.position, _hands.rotation);
        if (_currentHeldItem) Destroy(_currentHeldItem);
        Destroy(_currentHeldItem.GetComponent<Item>()._ItemIcon);
        ResetBool();
    }

    public void UseItem()
    {
        if (!_currentHeldItem) return;
        foreach (GameObject _item2 in _inventory)
        {
            if (_item2.name == _currentHeldItem.name && _item2.GetInstanceID() == _currentHeldItem.GetInstanceID() && !_isSwitching)
            {
                if (_item2.GetInstanceID() == _currentHeldItem.GetInstanceID()) _itemToDrop = _item2;
            }
        }
        _inventory.Remove(_itemToDrop);
        if (_currentHeldItem) Destroy(_currentHeldItem);
        Destroy(_currentHeldItem.GetComponent<Item>()._ItemIcon);
        ResetBool();
    }

    public bool GetIsSwitching() { return _isSwitching; }
    public bool GetIsGetting() { return _isGetting; }
    public List<GameObject> GetInventory() { return _inventory; }
    public List<GameObject> GetInventory1() { return _inventory1; }
    public void SetInventory1(List<GameObject> _savedInventory) {  _inventory1 = _savedInventory; } 
    public void ResetBool()
    {
        _movement.SetAttacking(false);
        _movement.SetShooting(false);
        _movement.SetShootingTwo(false);
        _movement.SetEating(false);
        _movement.SetThrowing(false);
    }

    public int GetCoins() { return _coins; }
    public void AddCoins(int _newCoins) { _coins += _newCoins; }
    #endregion
}