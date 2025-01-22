using UnityEngine;
[RequireComponent (typeof(TrailRenderer))]
[RequireComponent(typeof(ParticleSystem))]

public class Trail : MonoBehaviour  
{
    #region Private Functions
    private void Start()
    {
        GetComponent<TrailRenderer>().emitting = false;
        GetComponent<ParticleSystem>().Stop();
    }
    #endregion
}