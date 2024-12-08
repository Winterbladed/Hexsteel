using UnityEngine;

public class Npc : Interactable
{
    #region Variables
    [Header("Npc Talk")]
    [SerializeField] protected GameObject[] _text;
    [SerializeField] protected float _talkDuration;
    protected float _talkTime;
    protected int _talkIndex = 0;
    private bool _isTalking;
    private bool _isTalked;
    #endregion

    #region Private Functions
    protected virtual void Start()
    {
        _talkIndex = 0;
    }

    protected virtual void Update()
    {
        Talking();
    }

    protected void Talking()
    {
        if (_isTalking)
        {
            _talkTime += Time.deltaTime;
            if (_talkTime > _talkDuration)
            {
                _isTalking = false;
                _talkTime = 0.0f;
                foreach (GameObject _t in _text) _t.SetActive(false);
            }
        }
    }
    #endregion

    #region Public Functions
    public void Talk()
    {
        foreach (GameObject _t in _text) _t.SetActive(false);
        if (_isTalked)
        {
            if (_talkIndex < _text.Length) _talkIndex++;
            else if (_talkIndex >= _text.Length) _talkIndex = 0;
        }
        _text[_talkIndex].SetActive(true);
        _isTalking = true;
        _talkTime = 0.0f;
        _isTalked = true;
    }
    #endregion
}