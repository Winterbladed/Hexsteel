using UnityEngine;

public class Armor : MonoBehaviour
{
    #region Variables
    private int _currentAp;
    [SerializeField] private int _ap;
    private bool _isDisabled;
    private bool _isDisfunctioned;
    #endregion

    #region Private Functions
    private void Start()
    {
        _currentAp = _ap;
    }
    #endregion

    #region Public Functions
    public void RestoreArmor() //Restor Armor to 100%
    {
        _currentAp = _ap;
        _isDisabled = false;
        _isDisfunctioned = false;
    }

    public void RestoreArmor1() //Restor Armor to 100%
    {
        _currentAp = _ap;
        _isDisfunctioned = false;
    }

    public void RestoreArmor2() //Restor Armor to 100%
    {
        _currentAp = _ap;
    }

    public void DebilitateArmor() //Reduce Armor to 10% temporarily
    {
        if (!_isDisabled && !_isDisfunctioned) _currentAp = _ap - (_ap / 10);
    }

    public void DisfunctionArmor() //Reduce Armor to 50% temporarily
    {
        if (!_isDisabled) _currentAp = _ap / 2;
    }

    public void DisableArmor() //Reduce Armor to 100% temporarily
    {
        _currentAp = 0;
        _isDisabled = true;
    }

    public void DestroyArmor() //Reduce Armor to 100% permanently
    {
        _ap = 0;
        _currentAp = 0;
    }

    public int GetAp() { return _ap; }
    public int GetCurrentAp() { return _currentAp; }
    #endregion
}