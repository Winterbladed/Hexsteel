using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region Variables
    [SerializeField] private LayerMask _interactionLayerMask;
    [SerializeField] private float _interactionReach;
    [SerializeField] private Transform _interactionRay;
    [SerializeField] private InteractionUI _interactionUI;
    [SerializeField] private LayerMask _enemyLayerMask;
    private Inventory _inventory;
    #endregion

    #region Private Functions
    private void Start() { _inventory = Inventory._Inventory; }

    private void Update()
    {
        RaycastHit _hit; Ray _ray = new Ray(_interactionRay.position, transform.forward);
        if (Physics.Raycast(_ray, out _hit, _interactionReach, _interactionLayerMask))
        {
            //Debug.Log("I see " + _hit.collider.name);
            if (_hit.collider.GetComponent<Interactable>())
            {
                Interactable _currentInteractable = _hit.collider.GetComponent<Interactable>();
                _interactionUI.EnableText(_currentInteractable._InteractMessage);
                if (Input.GetKeyDown(KeyCode.E)) _currentInteractable.Interact();
            }
            else _interactionUI.DisableText();
        }
        else _interactionUI.DisableText();
        RaycastHit _hit2; Ray _ray2 = new Ray(_interactionRay.position, transform.forward);
        if (Physics.Raycast(_ray2, out _hit2, 30, _enemyLayerMask))
        {
            if (_hit2.collider.GetComponentInChildren<RaycastToggle>())
            {
                RaycastToggle _currentHealthUI = _hit2.collider.GetComponentInChildren<RaycastToggle>();
                _currentHealthUI._IsActive = true;
                _currentHealthUI._GameObject.SetActive(true);
                _currentHealthUI._Time = 0.0f;
            }
        }
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + _interactionReach));
    }
    #endregion

    #region Public Functions
    public void SetInteractionReach(float _reach) { _interactionReach = _reach; }
    #endregion
}