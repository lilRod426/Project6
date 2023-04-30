using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.WalkingActions walking;

    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        walking = playerInput.Walking;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    
    void FixedUpdate()
    {
        motor.ProcessMove(walking.movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(walking.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        walking.Enable();
    }
    private void OnDisable()
    {
        walking.Disable();
    }
}
