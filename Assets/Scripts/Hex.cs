using UnityEngine;

public class Hex : MonoBehaviour
{
    #region Variables
    private Inventory _inventory;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
    }
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _hit)
    {
        if (_hit.gameObject.GetComponent<Player>())
        {
            GetHex();
        }
    }
    #endregion

    #region Public Functions
    public void GetHex()
    {
        _inventory.AddHex(1);
        Destroy(gameObject);
    }
    #endregion
}