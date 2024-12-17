using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerExit : MonoBehaviour
{
    #region Variables
    [SerializeField] private bool _isDestructible = false;
    [SerializeField] private float _destroyTime = 0.0f;
    [SerializeField] private _TargetData _colliderDetection;
    [SerializeField] private UnityEvent _onTriggerExitEvt;
    private BoxCollider _boxCollider;
    #endregion

    #region Private Functions
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
    }
    #endregion

    #region Unity Messages
    private void OnTriggerExit(Collider _sense)
    {
        //Player
        if (_colliderDetection == _TargetData._Player && _sense.gameObject.GetComponent<Player>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //Rigidbody
        else if (_colliderDetection == _TargetData._Rigidbody && _sense.gameObject.GetComponent<Rigidbody>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //Interactable
        else if (_colliderDetection == _TargetData._Interactable && _sense.gameObject.GetComponent<Interactable>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //Item
        else if (_colliderDetection == _TargetData._Item && _sense.gameObject.GetComponent<Item>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //Health
        else if (_colliderDetection == _TargetData._Health && _sense.gameObject.GetComponent<Health>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //Movement
        else if (_colliderDetection == global::_TargetData._Movement && _sense.gameObject.GetComponent<Movement>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //NavMeshMovement
        else if (_colliderDetection == global::_TargetData._NavmeshMovement && _sense.gameObject.GetComponent<NavmeshMovement>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //AI_Passive
        else if (_colliderDetection == global::_TargetData._AI_Passive && _sense.gameObject.GetComponent<AI_Passive>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //AI_Aggressive
        else if (_colliderDetection == global::_TargetData._AI_Aggressive && _sense.gameObject.GetComponent<AI_AggressiveMelee>() ||
            _colliderDetection == global::_TargetData._AI_Aggressive && _sense.gameObject.GetComponent<AI_AggressiveRanged>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }

        //AI_Neutral
        else if (_colliderDetection == global::_TargetData._AI_Neutral && _sense.gameObject.GetComponent<AI_AggressiveMelee>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject, _destroyTime);
        }
    }
    #endregion
}