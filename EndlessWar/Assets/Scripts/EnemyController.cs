﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    public float speed;
    public float EnemyHealth;
    public static int EnemyDamage = 1;
    public static bool GiveDamage = false;
    public Image healthbar;
    public float defaultHealth = 50f;
    Animator anim;
    GameObject target;
    public AudioSource audioEnemyShot;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent.speed = speed;
        agent.updateRotation = true;
        agent.updatePosition = true;
        EnemyHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            if(anim.GetBool("isAttack") == false){
                agent.Resume();
                agent.SetDestination(target.transform.position);
                anim.SetBool("isWalk", true);
            }

            else {
                agent.Stop();
            }
        }

        if(WeaponController.isDie == true){
            anim.SetBool("isAttack", false);
            agent.Stop();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy")) {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage) {
        EnemyHealth -= damage;
        healthbar.fillAmount = EnemyHealth / defaultHealth;

        if(EnemyHealth <= 0) {
            anim.SetBool("isWalk", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isDie", true);
            UIManager.score += 10;
        }
    }

    void OnTriggerStay(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            anim.SetBool("isAttack", true);
            anim.SetBool("isWalk", false);
            GiveDamage = true;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            InvokeRepeating("delayShotDamage", 0.5f, 0.5f);
        }
    }

    void OnTriggerExit(Collider col) {
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", true);
        GiveDamage = false;
    }

    void delayShotDamage()
    {
        if (GiveDamage == true)
        {
            audioEnemyShot.Play();
        }
    }
}
