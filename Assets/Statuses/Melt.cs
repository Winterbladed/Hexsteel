using UnityEngine;

public class Melt : Status
{
    #region Variables
    [SerializeField] private Damage _damage;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Melt";
        _statusColor = new Color(0.0f, 0.5f, 1.0f);
        if (!_damage) _damage = gameObject.GetComponentInChildren<Damage>();
    }

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