using UnityEngine;

//class initially made by ChatGPT
// thats a bit cringe innit
public class KeyboardCameraController : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float cameraRange = 3f;      
    public float angle = 0;             // The rotation angle of the camera
    private float distance = 1;         // distance?
    private float verticalPosition = 3; // Vertical position

    // Specify the focus point
    public Vector3 focusPoint = new Vector3(0, 2, 0);

    void Update()
    {
        // Get input for movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");
        float verticalMovement = (Input.GetKey(KeyCode.Space) ? 1 : 0) + (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift) ? -1 : 0);
        
        distance += forwardMovement * Time.deltaTime * cameraSpeed;
        verticalPosition = transform.position.y + verticalMovement * Time.deltaTime * cameraSpeed;

        distance = Mathf.Clamp(distance, 0, cameraRange);
        verticalPosition = Mathf.Clamp(verticalPosition, 2.1f, cameraRange);

        transform.LookAt(focusPoint, transform.position);

        angle += horizontalMovement * Time.deltaTime * cameraSpeed;

        if(angle >= 360)
        {
            angle = 0;
        }

        transform.position = new Vector3(Mathf.Cos(angle) * distance, verticalPosition, Mathf.Sin(angle) * distance) + Vector3.forward * forwardMovement;
    }
}
