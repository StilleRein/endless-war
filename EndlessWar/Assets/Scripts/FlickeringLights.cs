using UnityEngine;
using System.Collections;

public class FlickeringLights : MonoBehaviour {

	public GameObject flashingLight;
	private float randomNumber;
	public float speed = 0.95f;

	void Start(){
		flashingLight.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		randomNumber = Random.value;

		if (randomNumber <= speed) {
			flashingLight.SetActive(true);
		}

		else {
			flashingLight.SetActive(false);
		}
	}
}﻿