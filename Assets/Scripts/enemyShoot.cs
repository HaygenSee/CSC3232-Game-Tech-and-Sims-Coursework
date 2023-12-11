using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    // time delay
    public float life = 3;
    public float damage = -25;

    public PlayerStats health;
    
    void Awake() {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
            health = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            health.updateHealth(damage);
        }
    }
}
