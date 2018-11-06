using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MovimientoJugador
{
    public GameObject enemy, player;
  

    // Use this for initialization
    void Start()
    {
     
        player = GameObject.Find("Cube");
        enemy = GameObject.Find("Sphere");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))         //Input.GetMouseButton(0), con esto no funciona
        {
            Debug.Log("Actúo sobre el enemigo");
            Destroy(enemy);
        }

        if (Input.GetMouseButton(0)) Debug.Log("Detecto el click");  //no detecta el click

    }

}


