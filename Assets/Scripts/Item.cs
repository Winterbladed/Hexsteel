using UnityEngine;

public class Item : Interactable
{
    #region Variables
    public GameObject _Item;
    public GameObject _ItemIcon;
    [Header("For Loot Item only")]
    public Sprite[] _ItemSprites;
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
            if (_newItem.GetComponent<Damage>())
            {
                if (_newItem.GetComponent<Damage>()._DamageType == DamageType._None)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _ItemSprites[13]);

                //Base Physical
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Blunt)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _ItemSprites[0]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Pierce)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _ItemSprites[1]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Slash)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _ItemSprites[2]);

                //Base Elemental
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Toxin)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.green, _ItemSprites[3]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Ice)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.cyan, _ItemSprites[4]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Fire)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, new Color(1.0f, 0.5f, 0.0f), _ItemSprites[5]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Electric)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, new Color(0.5f, 0.0f, 1.0f), _ItemSprites[6]);

                //Advanced Elemental
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Virus)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.magenta, _ItemSprites[7]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Gas)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.yellow, _ItemSprites[8]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Corrode)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.gray, _ItemSprites[9]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Melt)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, new Color(0.0f, 0.5f, 1.0f), _ItemSprites[10]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Magnetic)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.blue, _ItemSprites[11]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Blast)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.red, _ItemSprites[12]);

                //Secret
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Hex)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _ItemSprites[13]);
            }
            else _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon1(_Item.name, Color.white);
            _inventory.AddSpecificItemToInventory(_newItem);
            Destroy(gameObject);
        }
    }
    #endregion
}