using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Singleton
    public static InventoryUI _InventoryUI;
    private void Awake() { if (_InventoryUI != null) return; _InventoryUI = this; }
    #endregion
}