using UnityEngine;
using UnityEngine.Events;

public class Throwable : MonoBehaviour
{
    #region Variables
    [Header("Throwable Extras")]
    [SerializeField] private UnityEvent _onThrowEvt;
    private Inventory _inventory;
    private Movement _movement;
    private float _throwTime;
    #endregion

    #region Private Functions
    private void Start()
    {
        _inventory = Inventory._Inventory;
        _movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_movement.GetIsThrowing())
        {
            _throwTime = 0.0f;
            _movement.SetThrowing(true);
        }
        if (_movement.GetIsThrowing())
        {
            _throwTime += Time.deltaTime;
            if (_throwTime > 1.0f)
            {
                _onThrowEvt.Invoke();
                _inventory.UseItem();
                _movement.SetThrowing(false);
                _throwTime = 0.0f;
            }
        }
    }
    #endregion
}