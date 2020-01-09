using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //mesti di cek lagi logic nya
    public GameObject AmmoCrate;
    public static bool getBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(AmmoCrate, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(getBullet == true){
            StartCoroutine(StartSpawning());
            getBullet = false;
        }
    }

    IEnumerator StartSpawning() {
       yield return new WaitForSeconds(10f);
       Instantiate(AmmoCrate, transform.position, Quaternion.identity);
   }
}
