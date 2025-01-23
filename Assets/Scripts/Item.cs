using UnityEngine;

public class Item : Interactable
{
    #region Variables
    public GameObject _Item;
    public GameObject _ItemIcon;
    public Sprite _ItemSprite;
    private Inventory _inventory;
    private InventoryUI _inventoryUI;
    private StatusVars _statusVars;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
        _inventoryUI = InventoryUI._InventoryUI;
        _statusVars = StatusVars._StatusVars;
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
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[0], _statusVars._StatusSprites[13], _ItemSprite, _statusVars._StatusColors[0]);

                //Base Physical
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Blunt)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[0], _statusVars._StatusSprites[0], _ItemSprite, _statusVars._StatusColors[0]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Pierce)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[1], _statusVars._StatusSprites[1], _ItemSprite, _statusVars._StatusColors[1]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Slash)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[2], _statusVars._StatusSprites[2], _ItemSprite, _statusVars._StatusColors[2]);

                //Base Elemental
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Toxin)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[3], _statusVars._StatusSprites[3], _ItemSprite, _statusVars._StatusColors[3]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Ice)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[4], _statusVars._StatusSprites[4], _ItemSprite, _statusVars._StatusColors[4]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Fire)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[5], _statusVars._StatusSprites[5], _ItemSprite, _statusVars._StatusColors[5]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Electric)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[6], _statusVars._StatusSprites[6], _ItemSprite, _statusVars._StatusColors[6]);

                //Advanced Elemental
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Virus)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[7], _statusVars._StatusSprites[7], _ItemSprite, _statusVars._StatusColors[7]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Gas)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[8], _statusVars._StatusSprites[8], _ItemSprite, _statusVars._StatusColors[8]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Corrode)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[9], _statusVars._StatusSprites[9], _ItemSprite, _statusVars._StatusColors[9]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Melt)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[10], _statusVars._StatusSprites[10], _ItemSprite, _statusVars._StatusColors[10]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Magnetic)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[11], _statusVars._StatusSprites[11], _ItemSprite, _statusVars._StatusColors[11]);
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Blast)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, _statusVars._StatusColors[12], _statusVars._StatusSprites[12], _ItemSprite, _statusVars._StatusColors[12]);

                //Secret
                else if (_newItem.GetComponent<Damage>()._DamageType == DamageType._Hex)
                    _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon(_Item.name, Color.white, _statusVars._StatusSprites[13], _ItemSprite, _statusVars._StatusColors[8]);
            }
            else _newItemIcon.GetComponent<ItemIconUI>().SetItemIcon1(_Item.name, Color.white, _ItemSprite);
            _inventory.AddSpecificItemToInventory(_newItem);
            Destroy(gameObject);
        }
    }
    #endregion
}