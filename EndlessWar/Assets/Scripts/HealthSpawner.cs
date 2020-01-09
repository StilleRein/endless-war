using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
     public GameObject HealthCell;
     public static bool getHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(HealthCell, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(getHealth == true){
            StartCoroutine(StartSpawning());
            getHealth = false;
        }
    }

    IEnumerator StartSpawning() {
       yield return new WaitForSeconds(30f);
       Instantiate(HealthCell, transform.position, Quaternion.identity);
   }
}
