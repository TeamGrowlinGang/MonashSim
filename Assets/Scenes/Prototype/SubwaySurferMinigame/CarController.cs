using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float accellerationFactor;
    public float brakeFactor;
    public float turnFactor;
    public bool isBraking = false;
    
    [Header("Skid Settings")]
    public GameObject skidPrefab;       // prefab with SpriteRenderer
    public Transform wheelPosition;     // empty object at the wheel
    public float minSpeed = 2f;         // min speed to leave skid
    public float stampSpacing = 0.1f;   // time between skid stamps

    Rigidbody2D rigidBody2D;
    float accellerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float lastStampTime;

    void Start()
    {
        accellerationFactor = 10.0f;
        brakeFactor = 10.0f;
        turnFactor = 3.0f;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
        ApplyBraking();
        HandleSkidMarks();
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = accellerationInput * accellerationFactor * transform.up;
        rigidBody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;
        rigidBody2D.MoveRotation(rotationAngle);
    }
    
    void ApplyBraking()
    {
        if (!isBraking)
        {
            return;
        }
        if (rigidBody2D.linearVelocity.magnitude > 0.1f)
        {
            // add opposing force to brake
            Vector2 brakeForce = -rigidBody2D.linearVelocity.normalized * brakeFactor;
            rigidBody2D.AddForce(brakeForce, ForceMode2D.Force);
        }
    }
    
    void HandleSkidMarks()
    {
        bool isTurning = Mathf.Abs(steeringInput) > 0.1f;
        float speed = rigidBody2D.linearVelocity.magnitude;

        if ((isTurning||isBraking) && speed > minSpeed && Time.time > lastStampTime + stampSpacing)
        {
            Instantiate(skidPrefab, wheelPosition.position, wheelPosition.rotation);
            lastStampTime = Time.time;
        }
    }
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accellerationInput = inputVector.y;
    }
    
    public void SetBrakeInput(bool braking)
    {
        isBraking = braking;
    }
}
