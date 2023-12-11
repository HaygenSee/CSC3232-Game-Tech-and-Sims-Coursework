using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    public Transform GunTip, Camera;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50;
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            var bullet = Instantiate(bulletPrefab, Camera.position, Camera.rotation);
            bullet.GetComponent<Rigidbody>().velocity = GunTip.forward * bulletSpeed;
        }
    }
}

