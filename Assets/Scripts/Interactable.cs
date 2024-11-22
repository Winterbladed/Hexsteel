using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    #region Variables
    public string _InteractMessage;
    public UnityEvent _EventOnInteraction;
    #endregion

    #region Public Functions
    public void Interact()
    {
        _EventOnInteraction.Invoke();
    }
    #endregion
}