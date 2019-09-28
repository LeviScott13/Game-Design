//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<EnemyBase> enemyList;
    public float minX, maxX;
    public float minZ, maxZ;

    Vector3 spawn;
    public Transform enemyRotation;

    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 3f);
    }

    void Spawn()
    {
        spawn = new Vector3(Random.Range(minX, maxX), 3.216954f, Random.Range(minZ, maxZ));
        
        if (enemyList.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, enemyList.Count);
            enemyList[index].gameObject.SetActive(true);
            enemyList.Add((EnemyBase)Instantiate(enemyList[index], spawn, enemyRotation.rotation));
            enemyList[enemyList.Count - 1].MoveAndAttack();
        }
    }
}
