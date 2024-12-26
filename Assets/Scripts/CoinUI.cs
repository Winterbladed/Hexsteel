using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text _coinText;
    private Inventory _inventory;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
    }

    private void Update()
    {
        _coinText.text = _inventory.GetHex().ToString();
    }
    #endregion
}