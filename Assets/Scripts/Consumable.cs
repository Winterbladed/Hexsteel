using UnityEngine;
using UnityEngine.Events;

public class Consumable : MonoBehaviour
{
    #region Variables
    [SerializeField] private int _healAmount;
    [SerializeField] private UnityEvent _onConsumeEvt;
    private Inventory _inventory;
    private PlayerMovement _movement;
    private Health _health;
    private float _time;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
        _movement = GetComponentInParent<PlayerMovement>();
        _health = GetComponentInParent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_movement.GetIsEating())
        {
            _time = 0.0f;
            _movement.SetEating(true);
        }
        if (_movement.GetIsEating())
        {
            _time += Time.deltaTime;
            if (_time > 0.5f)
            {
                _onConsumeEvt.Invoke();
                _health.GiveHpHeal(_healAmount);
                _inventory.UseItem();
                _movement.SetEating(false);
                _time = 0.0f;
            }
        }
    }
    #endregion
}