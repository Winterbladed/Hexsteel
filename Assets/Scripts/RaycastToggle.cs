using UnityEngine;

public class RaycastToggle : MonoBehaviour
{
    #region Variables
    public bool _IsActive;
    public GameObject _GameObject;
    public float _Time;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_IsActive)
        {
            _Time += Time.deltaTime; ;
            if (_Time > 3.0f)
            {
                _GameObject.SetActive(false);
                _IsActive = false;
            }
        }
    }
    #endregion
}