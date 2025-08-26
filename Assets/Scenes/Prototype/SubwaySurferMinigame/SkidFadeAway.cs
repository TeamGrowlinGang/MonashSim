using UnityEngine;

public class SkidFadeAway : MonoBehaviour
{
    public float spawnDuration = 1.0f;

    void Start()
    {
        Destroy(gameObject, spawnDuration);
    }
    
}