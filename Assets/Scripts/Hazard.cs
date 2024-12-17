using UnityEngine;
[RequireComponent (typeof(BoxCollider))]

public class Hazard : Damage
{
    #region Variables
    private BoxCollider _boxColllider;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _boxColllider = GetComponent<BoxCollider>();
        _boxColllider.isTrigger = true;
    }
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _hit)
    {
        DealDamage(_hit.gameObject);
        DealStatusEffect(_hit.gameObject);
    }

    private void OnTriggerStay(Collider _hit)
    {
        DealStatusEffect(_hit.gameObject);
    }
    #endregion
}