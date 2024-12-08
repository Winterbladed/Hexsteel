using UnityEngine;

public class Melt : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Melt";
        _statusColor = new Color(0.0f, 0.5f, 1.0f);
    }
    #endregion
}