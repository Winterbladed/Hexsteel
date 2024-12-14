using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerExit : MonoBehaviour
{
    #region Variables
    private enum _ColliderDetection
    {
        Player,
        Rigidbody,
        Interactable,
        Item,
        Health,
    }
    [SerializeField] private bool _isDestructible;
    [SerializeField] private _ColliderDetection _colliderDetection;
    [SerializeField] private UnityEvent _onTriggerExitEvt;
    #endregion

    #region Unity Messages
    private void OnTriggerExit(Collider _sense)
    {
        //Player
        if (_colliderDetection == _ColliderDetection.Player && _sense.gameObject.GetComponent<Player>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject);
        }

        //Rigidbody
        else if (_colliderDetection == _ColliderDetection.Rigidbody && _sense.gameObject.GetComponent<Rigidbody>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject);
        }

        //Interactable
        else if (_colliderDetection == _ColliderDetection.Interactable && _sense.gameObject.GetComponent<Interactable>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject);
        }

        //Item
        else if (_colliderDetection == _ColliderDetection.Item && _sense.gameObject.GetComponent<Item>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject);
        }

        //Health
        else if (_colliderDetection == _ColliderDetection.Health && _sense.gameObject.GetComponent<Health>())
        {
            _onTriggerExitEvt.Invoke();
            if (_isDestructible) Destroy(gameObject);
        }
    }
    #endregion
}