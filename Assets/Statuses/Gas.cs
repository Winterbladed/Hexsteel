using UnityEngine;

public class Gas : Status
{
    #region Variables
    protected Health _health;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Gas";
        _statusColor = Color.yellow;
        _health = GetComponent<Health>();
    }
    #endregion
}