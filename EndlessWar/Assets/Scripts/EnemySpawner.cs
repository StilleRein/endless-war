using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StartSpawning() {
       yield return new WaitForSeconds(Random.Range(15f, 20f));
       Instantiate(Enemy, transform.position, Quaternion.identity);

       StartCoroutine(StartSpawning());
   }
}
