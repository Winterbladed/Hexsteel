using UnityEngine;

public class Gas : Status
{
    #region Variables
    protected Health _health;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Gas";
        _statusColor = Color.yellow;
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
                _health.TakeHpDamage(_statusDamage);
                _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 5.0f);
                foreach (Collider _hit in _colliders)
                {
                    if (_hit.gameObject.GetComponent<Health>() && !_hit.gameObject.GetComponent<Player>())
                        _hit.gameObject.GetComponent<Health>().TakeHpDamage(_statusDamage);
                }
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