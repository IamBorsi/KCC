using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage the camera movement given a mouse movement.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float _sensitivity = 0.9f;
    [SerializeField] private bool _invertedX = false;
    [SerializeField] private bool _invertedY = true;
    [SerializeField] private Transform _cameraTransform;

    public Transform CameraTransform { get { return _cameraTransform; } }

    private float _pitchChange;
    private float _yawChange;

    private const float _MAX_PITCH = 90f;
    private const float _MIN_PITCH = -90f;

    //private const float _MAX_YAW = 95f;
    //private const float _MIN_YAW = -95f;

    private float _rotationRate = 180f;

    private InputManager _inputManager;
    private GameObject _mainCamera;

    private void Start() {
        
        _inputManager = InputManager.Instance;
        _mainCamera = Camera.main.gameObject;

        Cursor.visible = false;

    }

    private void LateUpdate() {

        HandleCameraPosition();
        HandleCameraRotation();

    }

    /// <summary>
    /// Function to handle player camera rotation movement using the current mouse movement.
    /// </summary>
    private void HandleCameraRotation() {

        Vector2 mouseInputVector = _inputManager.GetMouseDeltaNormalized();
        mouseInputVector = mouseInputVector * _sensitivity * _rotationRate;

        _yawChange += mouseInputVector.x * Time.deltaTime * (_invertedX ? -1 : 1);

        _pitchChange += mouseInputVector.y * Time.deltaTime * (_invertedY ? -1 : 1);
        _pitchChange = Mathf.Clamp(_pitchChange, _MIN_PITCH, _MAX_PITCH);

        Vector3 rotationVector = new Vector3(_pitchChange, _yawChange, 0f);
        _cameraTransform.rotation = Quaternion.Euler(rotationVector);

        // Apply all the movement logic to the camera object
        _mainCamera.transform.rotation = _cameraTransform.rotation;

    }

    /// <summary>
    /// Function to handle player camera position (attached to a camera transform empty).
    /// </summary>
    private void HandleCameraPosition() {

        _mainCamera.transform.position = _cameraTransform.position;

    }

}
