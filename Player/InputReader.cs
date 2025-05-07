using UnityEngine;

public class InputReader : MonoBehaviour
{
    PlayerInputActions playerInputActions; // you gotta change the class name and probably variable name to whatever your input action is called. make sure to press generate c# class

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        playerInputActions.Core.Enable();
    }

    void OnDisable()
    {
        playerInputActions.Core.Disable();
    }

    public Vector2 GetNormalizedInputVector()
    {
        return playerInputActions.Core.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInputActions.Core.Look.ReadValue<Vector2>();
    }
}
