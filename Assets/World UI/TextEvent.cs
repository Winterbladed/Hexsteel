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

    public void ShowStatus(string _name, Color _color, Sprite _sprite, Transform _target)
    {
        GameObject _newElementText = _statusText;
        DynamicWorldUI _newDWUI = _newElementText.GetComponentInChildren<DynamicWorldUI>();
        _newDWUI.SetTextString(_name, _color);
        _newDWUI.SetImageSprite(_sprite, _color);
        Instantiate(_newElementText, _target.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
    }

    public void ShowState(string _name, Color _color, Transform _target)
    {
        GameObject _newElementText = _statusText;
        DynamicWorldUI _newDWUI = _newElementText.GetComponentInChildren<DynamicWorldUI>();
        _newDWUI.SetTextString(_name, _color);
        Instantiate(_newElementText, _target.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
    }
    #endregion
}