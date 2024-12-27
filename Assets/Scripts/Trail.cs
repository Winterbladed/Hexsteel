using UnityEngine;
[RequireComponent (typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(ParticleSystem))]

public class Trail : MonoBehaviour  
{
    #region Private Functions
    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    #endregion
}