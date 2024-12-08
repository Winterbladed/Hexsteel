using UnityEngine;

public class Blunt : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blunt";
        _statusColor = Color.white;
    }
    #endregion
}