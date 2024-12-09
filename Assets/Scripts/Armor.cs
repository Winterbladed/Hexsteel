using UnityEngine;

public class Armor : MonoBehaviour
{
    #region Variables
    private int _currentAp;
    [SerializeField] private int _ap;
    #endregion

    #region Private Functions
    private void Start()
    {
        _currentAp = _ap;
    }
    #endregion

    #region Public Functions
    public void DisableArmor()
    {
        _currentAp = 0;
    }

    public void RestoreArmor()
    {
        _currentAp = _ap;
    }

    public void DestroyArmor()
    {
        _ap = 0;
        _currentAp = 0;
    }

    public int GetAp() { return _ap; }
    public int GetCurrentAp() { return _currentAp; }
    #endregion
}