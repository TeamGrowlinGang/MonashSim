using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 1f;
        deadZone = -7;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.down * (moveSpeed * Time.deltaTime));
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
