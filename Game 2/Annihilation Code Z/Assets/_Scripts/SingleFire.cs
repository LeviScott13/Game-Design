﻿//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFire : WeaponBase
{
    public Transform shotSpawn;
    public GameObject shot;

    private float nextFire;
    public float fireRate;

    // Update is called once per frame
    public override void Fire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
    public override void Positioning()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
