using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCC_Gizmos : MonoBehaviour
{

    [SerializeField] private bool _showGizmos;
    [SerializeField] private Color _gizmoColor;

    public static float KCC_CheckSphereRadius { get { return 0.4f; } }

    private void OnDrawGizmosSelected() {

        if( _showGizmos) {

            Gizmos.color = _gizmoColor;
            Gizmos.DrawSphere(GetComponent<PlayerMovement>().FeetTransform.position, KCC_CheckSphereRadius);

        }

    }

}
