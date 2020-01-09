using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static int score;
    public Text ScoreText, AmmoText, HealthText;
    public GameObject ScoreTemplate, HealthTemplate, AmmoTemplate, Crosshair;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score + "";
        AmmoText.text = WeaponController.ammo + "/" + WeaponController.ammoMag;
        HealthText.text = WeaponController.health + "";

        if(WeaponController.isDie == true){
            ScoreTemplate.SetActive(false);
            HealthTemplate.SetActive(false);
            AmmoTemplate.SetActive(false);
            Crosshair.SetActive(false);
        }
    }

    public void ResetScore() {
        score = 0;
    }
}
