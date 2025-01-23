using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text _string;
    [SerializeField] private Image _image;
    [SerializeField] private Image _itemIcon;
    #endregion

    #region Private Functions
    public void SetItemIcon(string _newString, Color _newColor, Sprite _newImage, Sprite _newItemIcon, Color _iconColor)
    {
        _string.text = _newString;
        _string.color = _newColor;
        _image.sprite = _newImage;
        _itemIcon.sprite = _newItemIcon;
        _itemIcon.color = _iconColor;
    }

    public void SetItemIcon1(string _newString, Color _newColor, Sprite _newItemIcon)
    {
        _string.text = _newString;
        _string.color = _newColor;
        _image.enabled = false;
        _itemIcon.sprite = _newItemIcon;
    }
    #endregion
}