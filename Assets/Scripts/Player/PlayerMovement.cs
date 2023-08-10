using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage the player movement.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary> Default player movement speed. </summary>
    private const float DefaultMovementSpeed = 7f;

    /// <summary> Default distance from the ground to be considered "Grounded". </summary>
    private const float DefaultGroundedDistance = 0.05f;

    [SerializeField] protected virtual float _movementSpeed => DefaultMovementSpeed;
    [SerializeField] protected virtual float _groundedDistance => DefaultGroundedDistance;
    private InputManager _inputManager;

    private CharacterController characterController;

    private void Start() {
        // Get the reference to the Input Manager
        // (we do it in start so we are sure we assigned the instance during Awake in the InputManager script).
        _inputManager = InputManager.Instance;
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {

        HandleMovement();

    }

    /// <summary>
    /// Function to handle player movement. It takes the input vector and moves the player accordingly.
    /// </summary>
    private void HandleMovement() {

        Vector2 inputVector = _inputManager.GetPlayerMovementNormalized();

        // Handle player rotation based on camera rotation
        Vector3 currentRotation = GetComponent<CameraController>().CameraTransform.eulerAngles;
        transform.eulerAngles = new Vector3(0f, currentRotation.y, 0f);

        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += (transform.rotation * movementVector) * _movementSpeed * Time.deltaTime;

    }


}
