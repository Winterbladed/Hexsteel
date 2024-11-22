using UnityEngine;

public class Floaty : MonoBehaviour
{
    #region Variables
    private Player _player;
    private Rigidbody _rigidbody;
    private float _velocity = 1.0f;
    private float _delay = 0.0f;
    #endregion

    #region Private Functions
    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1f, 1), Random.Range(-1.5f, 1.5f)) * Time.deltaTime * 80.0f;
    }

    private void Update()
    {
        _delay += Time.deltaTime;
        if (_delay > Random.Range(1.0f, 1.5f))
        {
            if (_player) transform.position = Vector3.MoveTowards(transform.position, _player.transform.position - new Vector3(0.0f, 1.0f, 0.0f) + new Vector3(0.0f, 1.3f, 0.0f), Time.deltaTime * _velocity);
            _velocity += 0.05f;
        }
    }
    #endregion

    #region Unity Messages
    private void OnTriggerEnter(Collider _hit)
    {
        if (_hit.gameObject.GetComponent<Player>())
        {
            _hit.gameObject.GetComponent<Health>().GiveHpHeal(5);
            Destroy(gameObject);
        }
    }
    #endregion
}