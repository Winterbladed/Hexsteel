using UnityEngine;

public class Slash : Status
{
    #region Variables
    protected Health _health;
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Slash";
        _statusColor = Color.white;
        _health = GetComponent<Health>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                if (_shield)
                _health.TakeHpDamage(_statusDamage);
                _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}