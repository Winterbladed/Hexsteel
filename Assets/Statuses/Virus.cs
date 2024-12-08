using UnityEngine;

public class Virus : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Virus";
        _statusColor = Color.magenta;
    }
    #endregion
}