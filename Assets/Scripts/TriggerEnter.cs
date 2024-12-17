using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerEnter : MonoBehaviour
{
    #region Variables
    [SerializeField] private _TargetData _colliderDetection;
    [SerializeField] private UnityEvent _onTriggerEnterEvt;
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _sense)
    {
        //Player
        if (_colliderDetection == _TargetData._Player && _sense.gameObject.GetComponent<Player>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Rigidbody
        else if (_colliderDetection == _TargetData._Rigidbody && _sense.gameObject.GetComponent<Rigidbody>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //AudioSource
        else if (_colliderDetection == _TargetData._AudioSource && _sense.gameObject.GetComponent<AudioSource>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Interactable
        else if (_colliderDetection == _TargetData._Interactable && _sense.gameObject.GetComponent<Interactable>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Item
        else if (_colliderDetection == _TargetData._Item && _sense.gameObject.GetComponent<Item>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Health
        else if (_colliderDetection == _TargetData._Health && _sense.gameObject.GetComponent<Health>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //Movement
        else if (_colliderDetection == _TargetData._Movement && _sense.gameObject.GetComponent<Movement>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //NavMeshMovement
        else if (_colliderDetection == _TargetData._NavmeshMovement && _sense.gameObject.GetComponent<NavmeshMovement>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //AI_Passive
        else if (_colliderDetection == _TargetData._AI_Passive && _sense.gameObject.GetComponent<AI_Passive>())
        {
            _onTriggerEnterEvt.Invoke();
        }

        //AI_Aggressive
        else if (_colliderDetection == _TargetData._AI_Aggressive && _sense.gameObject.GetComponent<AI_AggressiveMeleeGroup>())
        {
            _onTriggerEnterEvt.Invoke();
        }
    }
    #endregion
}