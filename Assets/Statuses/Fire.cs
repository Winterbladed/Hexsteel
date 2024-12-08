using UnityEngine;

public class Fire : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Fire";
        _statusColor = new Color(1.0f, 0.5f, 0.0f);
    }
    #endregion
}