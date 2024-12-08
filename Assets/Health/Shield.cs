using UnityEngine;

public class Shield : MonoBehaviour
{
    #region Variables
    private int _currentSp;
    [SerializeField] private int _sp;
    [SerializeField] private int _spRechargeAmount;
    private float _spRechargeTime = 0.0f;
    private bool _isDisabled;
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
            if (_spRechargeTime > 2.0f )
            {
                _currentSp += _spRechargeAmount;
                _spRechargeTime = 0.0f;
            }
        }
    }
    #endregion

    #region
    public void ShieldDisable(bool _boolean)
    {
        _currentSp = 0;
        _isDisabled = _boolean;
    }

    public int GetSp() { return _sp; }
    public int GetCurrentSp() { return _currentSp; }
    #endregion
}