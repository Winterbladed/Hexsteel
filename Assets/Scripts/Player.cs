using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player _Player;
    private void Awake()
    {
        if (_Player != null) return;
        _Player = this;
    }
    #endregion
}