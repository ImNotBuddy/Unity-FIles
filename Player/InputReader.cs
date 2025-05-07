using UnityEngine;

public class InputReader : MonoBehaviour
{
    PlayerInputActions playerInputActions;

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
