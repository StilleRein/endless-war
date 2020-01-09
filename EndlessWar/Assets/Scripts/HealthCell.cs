using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCell : MonoBehaviour
{
     public AudioSource audioGetHealth;
     
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            if(WeaponController.health >= 75){
                WeaponController.health = 100;
            }

            else {
                WeaponController.health += 25;
            }

            audioGetHealth.Play();

            HealthSpawner.getHealth = true;
            StartCoroutine(destroyGameobject());
        }
    }

    IEnumerator destroyGameobject() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
