using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // time delay
    public float life = 3;

    public PlayerStats kills;

    void Awake() {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            kills = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            if (kills.checkKills())
            {   
                GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("wallToKill");
                foreach (GameObject obj in objectsToDestroy)
                {
                    Destroy(obj);
                }
            }

            
            
        }
    }
}
