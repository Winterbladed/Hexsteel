using UnityEngine;

//Blast = Fire + Electric
//Deals instant Area Of Effect Damage on effect
public class Blast : Status
{
    #region Variables
    private bool _isDone = false;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blast";
        _statusColor = Color.red;
        _statusMaterial = _statusVars._StatusMaterial[12];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            if (!_isDone)
            {
                DamageEventHealthArmorShield();
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 5.0f);
                foreach (Collider _hit in _colliders)
                {
                    if (_hit.gameObject.GetComponent<Health>())
                    {
                        if (_hit.gameObject.GetComponent<Shield>().GetCurrentSp() <= 0)
                        {
                            int _damage2 = ((_statusDamage * _hit.gameObject.GetComponent<Health>().GetHpDamageMultiplier()) - _hit.gameObject.GetComponent<Armor>().GetCurrentAp()) / 2;
                            if (_damage2 <= 0) _damage2 = 0;
                            _hit.gameObject.GetComponent<Health>().TakeHpDamage(_damage2);
                            _textEvent.ShowDamage(_damage2, _statusColor, _hit.gameObject.transform);
                        }
                        else
                        {
                            _hit.gameObject.GetComponent<Shield>().TakeSpDamage(_statusDamage / 2);
                            _textEvent.ShowDamage(_statusDamage / 2, _statusColor, _hit.gameObject.transform);
                        }
                    }
                }
                _isDone = true;
            }
            if (_statusTime > _statusTimer)
            {
                _isDone = false;
                DisableStatus();
            }
        }
    }
    #endregion
}