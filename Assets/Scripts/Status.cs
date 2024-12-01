using UnityEngine;

public class Status : MonoBehaviour
{
    #region Variables
    protected bool _isActive = false;
    [SerializeField] protected string _statusName;
    [SerializeField] protected GameObject _statusVfx;
    [SerializeField] protected TextEvent _textEvent;

    protected int _statusDamage = 0;
    protected float _statusTimer = 0.0f;
    protected float _statusTime = 0.0f;
    protected float _statusTicker = 0.0f;
    protected float _statusTick = 0.0f;
    #endregion

    #region Private Functions
    private void Start()
    {
        DisableStatus();
    }
    #endregion

    #region Public Functions
    public bool GetIsActive() { return _isActive; }
    public string GetStatusName() { return _statusName; }

    public void SetStatusDamage(int _damage)
    {
        _statusDamage = _damage;
    }
    public void SetStatusTimer(float _timer)
    {
        _statusTimer = _timer;
    }
    public void SetStatusTicker(float _ticker)
    {
        _statusTicker = _ticker;
    }

    public void EnableStatus()
    {
        _isActive = true;
        if (_statusVfx)
            _statusVfx.SetActive(true);
        _textEvent.ShowStatus(_statusName, transform);
    }

    public void DisableStatus()
    {
        _statusTime = 0.0f;
        _statusTick = 0.0f;
        _isActive = false;
        if (_statusVfx)
            _statusVfx.SetActive(false);
    }
    #endregion
}