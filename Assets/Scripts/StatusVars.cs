using UnityEngine;

public class StatusVars : MonoBehaviour
{
    #region Singleton
    public static StatusVars _StatusVars;
    private void Awake()
    {
        if (_StatusVars != null) return;
        _StatusVars = this;
    }
    #endregion

    #region Variables
    public Sprite[] _StatusSprites;
    public Color[] _StatusColors;
    #endregion
}