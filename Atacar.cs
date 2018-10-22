using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MovimientoJugador{

    public GameObject enemy;

   /* void Awake()
    {
        GameObject clone = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(clone, 1.0f);
    }*/

    // Use this for initialization
    void Start () {
        //Instantiate(enemy); //creo que esta es la linea que lo duplica pero si la quitas no hace nada
        enemy = GameObject.Find("Sphere");
      
    }

    // Update is called once per frame
    void Update(){
       if (Input.GetMouseButton(0))  //cuando haces click con el boton izquierdo del raton se va a la linea siguiente
        {
            Debug.Log("Click");      //esto es para detectar el click del mouse pero tampoco me muestra nada en Console
            GameObject.Destroy(enemy);         //aqui lo destruye, en teoria
        }
        
    }

}
