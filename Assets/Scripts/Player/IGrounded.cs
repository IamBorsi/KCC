using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrounded
{

    [Header("Grounded Settings")]
    /// <summary> Default distance from ground to be considered grounded. </summary>
    [SerializeField] protected const float DefaultGroundedDistance = 0.05f;

    public abstract bool IsGrounded { get; }

    public abstract void CheckGrounded();

}
