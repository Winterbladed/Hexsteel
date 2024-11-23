using UnityEngine;
using TMPro;

public class Head : MonoBehaviour
{
    #region Variables
    [SerializeField] TMP_Text _text;
    [SerializeField] private Movement _movement;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Health _health;
    [Header("Strings Library")]
    [SerializeField] private string[] _strings;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (!_health.GetIsDead())
        {
            if (_movement.GetIsRunning()) _text.text = _strings[1];
            else if (_movement.GetIsAttacking() || _movement.GetIsShooting()) _text.text = _strings[2];
            else if (_movement.GetIsStrafing()) _text.text = _strings[3];
            else if (_movement.GetIsEating()) _text.text = _strings[4];
            else if (_inventory.GetIsSwitching()) _text.text = _strings[6];
            else _text.text = _strings[0];
        }
    }
    #endregion

    #region Public Functions
    public void Dead()
    {
        _text.text = _strings[5];
    }
    #endregion
}