using UnityEngine;

public class BillboardPlayer : MonoBehaviour
{
    private Player _player;
    private void Start() { _player = Player._Player; }
    private void Update() { transform.LookAt(_player.gameObject.transform.position + new Vector3(0,1,0)); }
}