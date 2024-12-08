using UnityEngine;

public class Magnetic : Status
{
    #region Variables
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Magnetic";
        _statusColor = Color.blue;
        _shield = GetComponent<Shield>();
    }
    #endregion
}