using UnityEngine;
[RequireComponent (typeof(TextEvent))]

public class Status : MonoBehaviour
{
    #region Variables
    protected bool _isActive = false;
    protected string _statusName;
    [SerializeField] protected Sprite _statusSprite;
    [SerializeField] protected GameObject _statusImage;
    [SerializeField] protected GameObject _statusVfx;
    [SerializeField] protected bool _isStatusInfused = false;
    [SerializeField] protected bool _isStatusImmune = false;
    protected TextEvent _textEvent;
    protected Color _statusColor;

    protected int _statusDamage = 0;
    protected float _statusTimer = 0.0f;
    protected float _statusTime = 0.0f;
    protected float _statusTicker = 0.0f;
    protected float _statusTick = 0.0f;
    #endregion

    #region Private Functions
    protected virtual void Start() { if (!_isStatusInfused) DisableStatus(); else if (_isStatusInfused) EnableStatus(); _textEvent = GetComponent<TextEvent>(); }
    #endregion

    #region Public Functions
    public bool GetIsActive() { return _isActive; }
    public string GetStatusName() { return _statusName; }
    public Color GetStatusColor() { return _statusColor; }
    public Sprite GetStatusSprite() { return _statusSprite; }
    public void SetStatusDamage(int _damage) { _statusDamage = _damage; }
    public void SetStatusTimer(float _timer) { _statusTimer = _timer; }
    public void SetStatusTicker(float _ticker) { _statusTicker = _ticker; }

    public void EnableStatus()
    {
        if (!_isStatusImmune)
        {
            _isActive = true;
            if (_statusVfx) _statusVfx.SetActive(true);
            if (_statusImage) _statusImage.SetActive(true);
            _textEvent.ShowStatus(_statusName, _statusColor, _statusSprite, transform);
        }
    }

    public void DisableStatus()
    {
        _statusTime = 0.0f;
        _statusTick = 0.0f;
        if (!_isStatusInfused)
        {
            _statusTime = 0.0f;
            _statusTick = 0.0f;
            _isActive = false;
            if (_statusVfx) _statusVfx.SetActive(false);
            if (_statusImage) _statusImage.SetActive(false);
        }
    }
    #endregion
}