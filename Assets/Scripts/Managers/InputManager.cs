using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton Class to manage Player's inputs.
/// /// </summary>
public class InputManager : MonoBehaviour
{
    
    public static InputManager Instance { get; private set; }
    private PlayerActions _playerActions;

    private void Awake() {

        if(Instance != null && Instance != this) {
            // There is an instance and it is not the current one, destroy the newly created instance and return
            Destroy(this);
            return;
        } else {
            // There is no instance
            Instance = this;
        }

    }

    private void Start() {

        _playerActions = new PlayerActions();

        if(_playerActions != null) {
            // There have been no errors and the PlayerActions instance has been created correctly.
            EnablePlayerActions();
        }

    }

    /// <summary>
    /// Function to enable player actions from the new input system.
    /// </summary>
    private void EnablePlayerActions() {
        _playerActions.Gameplay.Enable();
    }

    /// <summary>
    /// Function to get the normalized Vector2 for the player movement input.
    /// </summary>
    /// <returns>Vector2</returns>
    public Vector2 GetPlayerMovementNormalized() {
        // The Vector2 is already normalized through processors instructions in the PlayerActions input actions.
        return _playerActions.Gameplay.Move.ReadValue<Vector2>();
    }

    /// <summary>
    /// Function to get the normalized Vector2 for the mouse delta.
    /// </summary>
    /// <returns>Vector2</returns>
    public Vector2 GetMouseDeltaNormalized() {
        // The Vector2 is already normalized through processors instructions in the PlayerActions input actions.
        return _playerActions.Gameplay.Look.ReadValue<Vector2>();
    }

}
