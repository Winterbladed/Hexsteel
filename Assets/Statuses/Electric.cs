using UnityEngine;

public class Electric : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Electric";
        _statusColor = new Color(0.5f, 0.0f, 1.0f);
    }
    #endregion
}