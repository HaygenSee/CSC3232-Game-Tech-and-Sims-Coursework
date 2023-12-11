using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    // attack on mouse click
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    void Attack() {

    }
}
