using UnityEngine;

public class Item : Interactable
{
    #region Variables
    public GameObject _Item;
    public GameObject _ItemIcon;
    private Inventory _inventory;
    private InventoryUI _inventoryUI;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
        _inventoryUI = InventoryUI._InventoryUI;
    }
    #endregion

    #region Public Functions
    public void GetItem()
    {
        if (_inventory.GetInventorySize() < _inventory.GetInventorySlots())
        {
            GameObject _newItem = _Item;
            GameObject _newItemIcon = Instantiate(_ItemIcon, _inventoryUI.transform);
            _newItem.GetComponent<Item>()._ItemIcon = _newItemIcon;
            _inventory.AddSpecificItemToInventory(_newItem);
            Destroy(gameObject);
        }
    }
    #endregion
}