using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int CameraMode;
    public GameObject CameraFPS, CameraTPS, CameraEnd;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Camera")) {
            if (CameraMode == 1) {
                CameraMode = 0;
            }

            else {
                CameraMode += 1;
            }
            StartCoroutine (SwitchCamera());
        }

        if(WeaponController.isDie == true){
            CameraMode = 2;
            StartCoroutine (SwitchCamera());
        }
    }

    IEnumerator SwitchCamera () {
        yield return new WaitForSeconds (0.01f);

        if (CameraMode == 0) {
            CameraFPS.SetActive(true);
            CameraTPS.SetActive(false);
            CameraEnd.SetActive(false);
        }

        if (CameraMode == 1) {
            CameraFPS.SetActive(false);
            CameraTPS.SetActive(true);
            CameraEnd.SetActive(false);
        }

        if(CameraMode == 2){
            CameraFPS.SetActive(false);
            CameraTPS.SetActive(false);
            CameraEnd.SetActive(true);
        }
    }
}
