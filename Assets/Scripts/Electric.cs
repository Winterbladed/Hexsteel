using UnityEngine;

//Electric
//Deals Damage overtime during the effect
public class Electric : Status
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
        _statusName = "Electric";
        _statusColor = new Color(0.5f, 0.0f, 1.0f);
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
                    _textEvent.ShowDamage(_statusDamage - _armor.GetCurrentAp(), _statusColor, gameObject.transform);
                }
                else
                {
                    _shield.TakeSpDamage(_statusDamage);
                    _textEvent.ShowDamage(_statusDamage, _statusColor, gameObject.transform);
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