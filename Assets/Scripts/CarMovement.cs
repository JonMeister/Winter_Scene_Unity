using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento en Nieve")]
    public float moveSpeed = 2.5f;
    public float turnSpeed = 60f;

    void Update()
    {
        if (Keyboard.current == null) return;

        float moveInput = 0f;
        float turnInput = 0f;

        // Adelante / Atrás (W/S o Flechas Arriba/Abajo)
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveInput += 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveInput -= 1f;

        // Giro Izquierda / Derecha (A/D o Flechas Izquierda/Derecha)
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            turnInput += 1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            turnInput -= 1f;

        // Avanzar o retroceder sobre el plano de nieve
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Solo gira el volante si el coche se está moviendo (como un vehículo real)
        if (Mathf.Abs(moveInput) > 0.01f)
        {
            float direction = Mathf.Sign(moveInput);
            transform.Rotate(0f, turnInput * turnSpeed * direction * Time.deltaTime, 0f);
        }
    }
}

