using System.IO;
using UnityEngine;

public class Blast : Status
{
    #region Variables
    [SerializeField] private Health _health;
    private bool _isDone = false;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blast";
        _statusColor = Color.red;
    }

    private void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            if (!_isDone)
            {
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 5.0f);
                foreach (Collider _hit in _colliders)
                {
                    if (_hit.gameObject.GetComponent<Health>() && !_hit.gameObject.GetComponent<Player>())
                        _hit.gameObject.GetComponent<Health>().TakeHpDamage(_statusDamage);
                }
                _isDone = true;
            }
            if (_statusTime > _statusTimer)
            {
                _isDone = false;
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}