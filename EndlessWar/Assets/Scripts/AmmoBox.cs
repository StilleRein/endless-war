using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public AudioSource audioGetBullet;
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
            WeaponController.ammoMag += 60;
            audioGetBullet.Play();

            BulletSpawner.getBullet = true;
            StartCoroutine(destroyGameobject());
        }
    }

    IEnumerator destroyGameobject() {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
