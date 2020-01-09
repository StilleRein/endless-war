using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public static int ammo, health;
    int add;
    bool trigger = true;
    public static float damage = 5f;
    public float range = 100f;
    public float force = 30f;
    public float fireRate = 10f;
    private float timeFire = 0f;
    public int healthDefault = 100;
    public int ammoStock = 30;
    public static int ammoMag = 120;
    public AudioSource audioShot;
    public AudioSource audioReload;
    public static bool isDie = false;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
        InvokeRepeating("delayGetDamage", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeFire && trigger == true) {
            Shoot();
            timeFire = Time.time + 1f / fireRate;
        }

        if (Input.GetButton("Reload") && ammo < ammoStock) {
            if(ammoMag != 0) {
                trigger = false;
                audioReload.Play();
                StartCoroutine(waitReload());
            }
        }

        if(EnemyController.GiveDamage == true) {
            if (health <= 0) {
                EnemyController.GiveDamage = false;
                isDie = true;
            }
        }

        if(isDie == true){
            StartCoroutine(delayChangeEndScene());
        }
    }

    IEnumerator delayChangeEndScene(){
        yield return new WaitForSeconds(3.5f);
        Panel.SetActive(true);
        SceneManager.LoadScene("EndGameScene");
    }

    void delayGetDamage()
    {
        if (EnemyController.GiveDamage == true)
        {
            health -= EnemyController.EnemyDamage;
        }

        else
        {
            health -= 0;
        }
    }

    IEnumerator waitReload() {
        yield return new WaitForSeconds(2.5f);
        if(ammoMag <= ammoStock) {
            ammo += ammoMag;
            add = ammo - ammoStock;

            if(add < 0) {
                ammoMag = 0;
            }

            else {
                ammoMag = add;
                ammo = ammoStock;
            }
        }

        else {
            add = (ammo - ammoStock) * -1;
            ammo += add;
            ammoMag -= add;
        }

        trigger = true;
    }

    public void Shoot() {
        if (ammo != 0) {
            audioShot.Play();
            RaycastHit hit;
            Transform cam = Camera.main.transform;
            Ray ray = new Ray(cam.position, cam.forward);

            if (Physics.Raycast(ray, out hit, range)) {
                if (hit.transform.CompareTag("Enemy")) {
                    hit.transform.gameObject.SendMessage("TakeDamage", damage);
                }

                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(-hit.normal * force);
                }
            }

            ammo--;
        }
    }

    public void Restart() {
        healthDefault = 100;
        ammoMag = 120;
        UIManager.score = 0;

        health = healthDefault;
        ammo = ammoStock;

        isDie = false;
    }
}
