using UnityEngine;

public class Coin : MonoBehaviour
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
            _inventory.AddCoins(1);
            Destroy(gameObject);
        }
    }
    #endregion
}