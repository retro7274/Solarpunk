using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerTransform;
    public Transform cameraTransform;

    float playerRotation = 0f;
    float cameraRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control rotation around y-axis (Look left and right)
        playerRotation += mouseX;

        // Apply rotation to the player
        playerTransform.localRotation = Quaternion.Euler(0f, playerRotation, 0f);

        // Control rotation around x-axis (Look up and down)
        cameraRotation -= mouseY;

        // Clamp the camera rotation so it doesn't over-rotate
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

        // Apply rotation to the camera
        cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
 
    }

}
