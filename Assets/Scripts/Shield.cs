using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    #region Variables
    [Header("Shield Stats")]
    private int _currentSp;
    [SerializeField] private int _sp;
    [SerializeField] private int _spRechargeAmount;
    private float _spRechargeTime = 0.0f;
    private bool _isDisabled;

    [Header("Events")]
    public UnityEvent _OnHit;
    #endregion

    #region Private Functions
    private void Start()
    {
        _currentSp = _sp;
    }

    private void Update()
    {
        if (_sp > 0 && !_isDisabled)
        {
            _spRechargeTime += Time.deltaTime;
            if (_spRechargeTime > 5.0f )
            {
                CapSp();
                if (_currentSp < _sp) _currentSp += _spRechargeAmount;
                _spRechargeTime = 0.0f;
            }
        }
    }

    private void CapSp()
    {
        if (_currentSp < 0) _currentSp = 0;
        else if (_currentSp > _sp) _currentSp = _sp;
    }
    #endregion

    #region
    public void TakeSpDamage(int _damage)
    {
        _currentSp -= _damage;
        _OnHit?.Invoke();
        CapSp();
    }

    public void Take10PercentSpDamage()
    {
        _currentSp -= _sp - (_sp / 10);
        CapSp();
    }

    public void ShieldDisable(bool _boolean)
    {
        _currentSp = 0;
        _isDisabled = _boolean;
    }

    public int GetSp() { return _sp; }
    public int GetCurrentSp() { return _currentSp; }
    #endregion
}