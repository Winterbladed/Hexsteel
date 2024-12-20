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
            if (_damage) _damage.CrippleDamage();
            if (_statusTime > _statusTimer)
            {
                if (_damage) _damage.UnCrippleDamage();
                DisableStatus();
            }
        }
    }
    #endregion
}