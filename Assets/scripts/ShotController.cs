using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate = 2;
    private float nextShot;
	// Use this for initialization


    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {     
            Shot();
            nextShot = Time.time + fireRate;
        }
    }

    void Shot()
    {
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
    }
}
