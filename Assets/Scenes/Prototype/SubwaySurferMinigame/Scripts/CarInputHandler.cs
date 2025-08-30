using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarInputHandler : MonoBehaviour
{

    CarController carController;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        carController.SetInputVector(inputVector);
        
        bool isBraking = Input.GetKey(KeyCode.LeftShift);
        carController.SetBrakeInput(isBraking);
    }
}
