using UnityEngine;

public class Magnetic : Status
{
    #region Variables
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Magnetic";
        _statusColor = Color.blue;
        _shield = GetComponent<Shield>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _shield.ShieldDisable(true);
                _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _shield.ShieldDisable(false);
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}