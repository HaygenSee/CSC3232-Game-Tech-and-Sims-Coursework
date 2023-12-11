using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// grapple gun code by DanisTutorials
// https://www.youtube.com/watch?v=Xgh4v1w5DxU

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, Camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            StartGrapple();
        }

        if (Input.GetMouseButtonUp(1)) {
            StopGrapple();
        }
    }


    // called after update
    void LateUpdate() {
        DrawRope();
    }

    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            // distance grapple will try to keep from grapple point
            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;


        }

    }

    void DrawRope() {
        // if not grappling don't draw line
        if (!joint) return;

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    public void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);

    }

    public bool IsGrappling() {
        return joint != null;
    }
        
    
}
