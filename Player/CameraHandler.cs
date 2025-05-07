using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] Transform cameraHolder; // your camera should be inside an empty game object with both transforms reset to prevent the camera jittering
    [SerializeField] Transform cameraTargetPosition; // where you want the camera to snap to each frame
    [SerializeField] Transform playerModelHolder; // empty game object that containes the players model to allow for rotation. useful if you have arms or whatever idk
    [SerializeField] InputReader inputReader;

    [Header("Settings")]
    [Range(0.01f, 3f)] public float xSensitivity = 1f;
    [Range(0.01f, 3f)] public float ySensitivity = 1f;
    readonly float sensitivityMultiplier = 0.05f;

    Vector2 mouseDelta;
    float xRotation, yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotations();
        transform.position = cameraTargetPosition.position;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerModelHolder.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void UpdateRotations()
    {
        mouseDelta = inputReader.GetMouseDelta();

        xRotation -= mouseDelta.y * ySensitivity * sensitivityMultiplier;
        yRotation += mouseDelta.x * xSensitivity * sensitivityMultiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
