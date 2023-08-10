using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage the player movement.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IGrounded
{
    /// <summary> Default player movement speed. </summary>
    private const float DefaultMovementSpeed = 7f;

    /// <summary> Default distance from the ground to be considered "Grounded". </summary>
    private const float DefaultGroundedDistance = 0.05f;

    [SerializeField] protected virtual float _movementSpeed => DefaultMovementSpeed;
    [SerializeField] protected virtual float _groundedDistance => DefaultGroundedDistance;

    [Header("Grounded Settings")]
    [SerializeField] private Transform _feetTransform;
    [SerializeField] private LayerMask _groundLayerMask;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;
    public Transform FeetTransform { get { return _feetTransform; } }

    private InputManager _inputManager;

    private void Start() {
        // Get the reference to the Input Manager
        // (we do it in start so we are sure we assigned the instance during Awake in the InputManager script).
        _inputManager = InputManager.Instance;

        _isGrounded = true;
    }

    private void Update() {

        CheckGrounded();
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

    public void CheckGrounded() {

        if (Physics.CheckSphere(_feetTransform.position, KCC_Gizmos.KCC_CheckSphereRadius, _groundLayerMask)) {
            _isGrounded = true;
        } else {
            _isGrounded = false;
        }

    }

}
