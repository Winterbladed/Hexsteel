using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerEnter : MonoBehaviour
{
    #region Variables
    [SerializeField] private UnityEvent _onTriggerEnterEvt;
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _sense)
    {
        if (_sense.gameObject.GetComponent<Player>()) _onTriggerEnterEvt.Invoke();
    }
    #endregion
}