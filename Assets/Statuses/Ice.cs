using UnityEngine;

public class Ice : Status
{
    #region Variables
    protected Movement _movement;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Ice";
        _statusColor = Color.cyan;
        _movement = GetComponent<Movement>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _movement.Slow();
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _movement.UnSlow();
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}