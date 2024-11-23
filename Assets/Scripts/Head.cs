using UnityEngine;
using TMPro;

public class Head : MonoBehaviour
{
    #region Variables
    [SerializeField] TMP_Text _text;
    [SerializeField] private Movement _movement;
    [Header("Strings Library")]
    [SerializeField] private string[] _strings;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_movement.GetIsRunning()) _text.text = _strings[1];
        else if (_movement.GetIsAttacking() || _movement.GetIsShooting()) _text.text = _strings[2];
        else if(_movement.GetIsStrafing()) _text.text = _strings[3];
        else if (_movement.GetIsEating()) _text.text = _strings[4];
        else _text.text = _strings[0];
    }
    #endregion
}