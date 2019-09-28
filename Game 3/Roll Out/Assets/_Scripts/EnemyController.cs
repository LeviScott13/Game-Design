//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<EnemyBase> enemyList;
    public Transform enemyRotation;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Spawn", 10, 10);

    }
        void Update()
    {
        foreach (EnemyBase enemy in enemyList)
        {
            enemy.MoveAndAttack();
        }
    }
    void Spawn()
    {
        if (enemyList.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, enemyList.Count);
            int spawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            enemyList[index].gameObject.SetActive(true);
            enemyList.Add((EnemyBase)Instantiate(enemyList[index], spawnPoints[spawnPoint].position, enemyRotation.rotation));
            enemyList[enemyList.Count - 1].MoveAndAttack();
        }
    }
}
