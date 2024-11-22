using UnityEngine;

public class Weaken : Status
{
    #region Variables
    [SerializeField] private Damage _damage;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _damage.CrippleDamage();
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _damage.UnCrippleDamage();
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}