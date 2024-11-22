using UnityEngine;

public class Billboard1 : MonoBehaviour
{
    #region Variables
    private Player _player;
    #endregion

    #region Private Functions
    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        transform.LookAt(_player.gameObject.transform.position + new Vector3(0,1,0));
    }
    #endregion
}