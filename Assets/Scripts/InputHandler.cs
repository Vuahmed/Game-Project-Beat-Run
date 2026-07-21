using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : IDisposable
{
    public event Action<int> OnMove;

    private GameInput input;

    public InputHandler()
    {
        input = new GameInput();
        
        input.Enable();
        input.Player.Move.performed += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        var direction = Mathf.RoundToInt(context.ReadValue<Vector2>().x);

        if (direction != 0)
            OnMove?.Invoke(direction);
    }

    public void Dispose()
    {
        input.Player.Move.performed -= OnMovePerformed;
        input.Disable();
        input?.Dispose();
    }
}