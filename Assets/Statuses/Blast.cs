using UnityEngine;

public class Blast : Status
{
    #region Variables
    protected Health _health;
    protected Armor _armor;
    protected Shield _shield;
    private bool _isDone = false;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blast";
        _statusColor = Color.red;
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
        _shield = GetComponent<Shield>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            if (!_isDone)
            {
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
                _isDone = true;
            }
            if (_statusTime > _statusTimer)
            {
                _isDone = false;
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}