using UnityEngine;

public class TextEvent : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _damageText;
    [SerializeField] private GameObject _statusText;
    [SerializeField] private Transform _ui;
    #endregion

    #region Public Functions
    public void ShowDamage(int _damage, Color _color, Transform _target)
    {
        GameObject _newDamageText = _damageText;
        _newDamageText.GetComponentInChildren<DynamicWorldUI>().SetTextString(_damage.ToString(), _color);
        Instantiate(_newDamageText, _target.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
    }

    public void ShowStatus(string _name, Transform _target)
    {
        GameObject _newElementText = _statusText;
        _newElementText.GetComponentInChildren<DynamicWorldUI>().SetTextString(_name, Color.red);
        Instantiate(_newElementText, _target.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
    }
    #endregion
}