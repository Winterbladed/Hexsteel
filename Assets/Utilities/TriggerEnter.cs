using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerEnter : MonoBehaviour
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
    [SerializeField] private _ColliderDetection _colliderDetection;
    [SerializeField] private UnityEvent _onTriggerEnterEvt;
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _sense)
    {
        //Player
        if (_colliderDetection == _ColliderDetection.Player && _sense.gameObject.GetComponent<Player>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Rigidbody
        else if (_colliderDetection == _ColliderDetection.Rigidbody && _sense.gameObject.GetComponent<Rigidbody>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Interactable
        else if (_colliderDetection == _ColliderDetection.Interactable && _sense.gameObject.GetComponent<Interactable>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Item
        else if (_colliderDetection == _ColliderDetection.Item && _sense.gameObject.GetComponent<Item>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Health
        else if (_colliderDetection == _ColliderDetection.Health && _sense.gameObject.GetComponent<Health>())
        {
            _onTriggerEnterEvt.Invoke();
        }
    }
    #endregion
}