using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    Image healthBar;
    public static float health;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        health = 0.91f;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health;
	}
}
