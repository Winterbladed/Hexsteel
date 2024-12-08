using UnityEngine;

public class Slash : Status
{
    #region Variables
    protected Health _health;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Slash";
        _statusColor = Color.white;
        _health = GetComponent<Health>();
    }
    #endregion
}