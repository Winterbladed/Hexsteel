using UnityEngine;

public class WeaponShield : Weapon
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButton(1) && !_isAttacked && Time.timeScale > 0.0f)
            _health.Block(true);
        else _health.Block(false);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    private void OnDisable()
    {
        if (_health) _health.Block(false);
    }

    private void OnDestroy()
    {
        if (_health) _health.Block(false);
    }
    #endregion
}