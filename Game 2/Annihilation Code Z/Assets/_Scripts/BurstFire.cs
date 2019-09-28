//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : WeaponBase
{
    public Transform shotSpawn;
    public GameObject shot;


    // Update is called once per frame
    public override void Fire()
    {
        StartCoroutine(FireBurst());
    }
    public IEnumerator FireBurst()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override void Positioning()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
