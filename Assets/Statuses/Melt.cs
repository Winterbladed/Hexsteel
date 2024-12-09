using UnityEngine;

//Melt = Ice + Fire
//Weakens Damage sources during the effect
public class Melt : Status
{
    #region Variables
    protected Damage _damage;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Melt";
        _statusColor = new Color(0.0f, 0.5f, 1.0f);
        _damage = GetComponent<Damage>();
    }

    private void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                if (_damage) _damage.CrippleDamage();
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                if (_damage) _damage.UnCrippleDamage();
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}