using UnityEngine;

public class Blast : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blast";
        _statusColor = Color.red;
    }
    #endregion
}