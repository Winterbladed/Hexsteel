using UnityEngine;

public class Gas : Status
{
    #region Variables
    protected Health _health;
    protected Armor _armor;
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Gas";
        _statusColor = Color.yellow;
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
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
                if (_shield.GetCurrentSp() <= 0)
                {
                    _health.TakeHpDamage(_statusDamage - _armor.GetCurrentAp());
                    _textEvent.ShowDamage(_statusDamage - _armor.GetCurrentAp(), Color.white, gameObject.transform);
                }
                else
                {
                    _shield.TakeSpDamage(_statusDamage);
                    _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
                }
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 5.0f);
                foreach (Collider _hit in _colliders)
                {
                    if (_hit.gameObject.GetComponent<Health>() && !_hit.gameObject.GetComponent<Player>())
                    {
                        if (_hit.gameObject.GetComponent<Shield>().GetCurrentSp() <= 0)
                        {
                            _hit.gameObject.GetComponent<Health>().TakeHpDamage(_statusDamage - _hit.gameObject.GetComponent<Armor>().GetCurrentAp());
                            _textEvent.ShowDamage(_statusDamage - _hit.gameObject.GetComponent<Armor>().GetCurrentAp(), Color.white, gameObject.transform);
                        }
                        else
                        {
                            _hit.gameObject.GetComponent<Shield>().TakeSpDamage(_statusDamage);
                            _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
                        }
                    }
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