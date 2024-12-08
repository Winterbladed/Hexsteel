using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _timer;
    #endregion

    #region Private Functions
    private void Start()
    {
        Destroy(gameObject, _timer);
    }
    #endregion
}