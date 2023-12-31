using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// movable boxes tutorial by Online Code Coaching
// https://www.youtube.com/watch?v=4g483XSnuoA

public class moveableObject : MonoBehaviour
{
    public float pushForce = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        Rigidbody _rigg = hit.collider.attachedRigidbody;

        if(_rigg != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            _rigg.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }
    }
}
