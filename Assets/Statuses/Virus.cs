using UnityEngine;

public class Virus : Status
{
    #region Variables
    protected Health _health;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Virus";
        _statusColor = Color.magenta;
        _health = GetComponent<Health>();
    }
    #endregion
}