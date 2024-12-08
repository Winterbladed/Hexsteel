using UnityEngine;

public class Pierce : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Pierce";
        _statusColor = Color.white;
    }
    #endregion
}