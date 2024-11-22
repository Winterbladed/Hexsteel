using UnityEngine;

public class Slow : Status
{
    #region Variables
    [SerializeField] private Enemy _enemy;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _enemy.Slow();
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _enemy.UnSlow();
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}