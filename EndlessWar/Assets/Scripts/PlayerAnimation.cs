using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float speed = 30f;
    public float rotationSpeed = 80;
    public float rotation = 0f;
    public float gravity = 8;
    Animator anim;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    public bool isJump = false;

    //0 = idle
    //1 = run forward
    //2 = walk left
    //3 = walk  right
    //4 = walk backward
    //5 = shot running
    //6 = shot stay
    //7 = reload
    //8 = death

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if(MainSceneController.isMainScene){
            anim.Play("Rifle_idle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
        ReloadBullet();
        PlayerStatus();
    }

    void PlayerStatus(){
        if(WeaponController.isDie == true){
            anim.SetBool("Run", false);
            anim.SetBool("Shot", false);
            anim.SetBool("Reload", false);
            anim.SetBool("Death", true);
            anim.SetInteger("condition", 8);
        }
    }

    void Movement() {
        if (controller.isGrounded) {
            //input W
            if (Input.GetKey(KeyCode.W)) {
                anim.SetBool("Run", true);

                if(anim.GetBool("Shot") == false){
                    anim.SetInteger("condition", 1);
                }

                moveDir = new Vector3 (0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            //input A
            if (Input.GetKey(KeyCode.A)) {
                anim.SetBool("Run", true);

                if(anim.GetBool("Shot") == false){
                    anim.SetInteger("condition", 2);
                }

                moveDir = new Vector3 (-1, 0, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            //input S
            if (Input.GetKey(KeyCode.S)) {
                anim.SetBool("Run", true);

                if(anim.GetBool("Shot") == false){
                    anim.SetInteger("condition", 4);
                }

                moveDir = new Vector3 (0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            //input D
            if (Input.GetKey(KeyCode.D)) {
                anim.SetBool("Run", true);

                if(anim.GetBool("Shot") == false){
                    anim.SetInteger("condition", 3);
                }

                moveDir = new Vector3 (1, 0, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
                anim.SetBool("Run", false);
                anim.SetInteger("condition", 0);

                moveDir = new Vector3 (0, 0, 0);
            }

            if(anim.GetBool("Shot") == true){
                anim.SetInteger("condition", 5);
            }

            rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3 (0, rotation, 0);
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }

    void ReloadBullet(){
        if (Input.GetButton("Reload")) {
            anim.SetInteger("condition", 7);
        }
    }

    void GetInput() {
        if (Input.GetButtonDown("Fire1")) {
            anim.SetBool("Shot", true);

            if(anim.GetBool("Run") == false){
                anim.SetInteger("condition", 6);
            }
        }

        if (Input.GetButtonUp("Fire1")) {
            anim.SetBool("Shot", false);

            if(anim.GetBool("Run") == false){
                anim.SetInteger("condition", 0);
            }
        }
    }
}
