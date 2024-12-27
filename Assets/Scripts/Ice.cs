using UnityEngine;

//Ice
//Slows down Movement Speed during the effect
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
            if (!_isStatusInfused) _movement.Slow();
            if (_statusTime > _statusTimer)
            {
                _movement.UnSlow();
                DisableStatus();
            }
        }
    }
    #endregion
}