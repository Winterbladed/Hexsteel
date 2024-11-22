using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class TriggerExit : MonoBehaviour
{
    #region Variables
    [SerializeField] private UnityEvent _onTriggerExitEvt;
    #endregion

    #region Unity Messages
    private void OnTriggerExit(Collider _sense)
    {
        if (_sense.gameObject.GetComponent<Player>()) _onTriggerExitEvt.Invoke();
    }
    #endregion
}