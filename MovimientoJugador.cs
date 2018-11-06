using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {


   [SerializeField] private float velocidad = 2;
   [SerializeField] private float velocidadCarrera = 7;
    private Vector3 teclas = new Vector3(0, 0, 0);
    private Vector3 movimiento = new Vector3(0, 0, 0);
    [SerializeField] private float velocidadGiro = 60; 
//    private Vector3 giroJugador = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
      // giroJugador = new Vector3(0, velocidadGiro * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Mueve normal
        DesplazamientoNormal();
      //  Rotar();
        if (Input.GetButton("Correr")) { 
        Carrera();}

    }

    public void DesplazamientoNormal()
    {
        //Para que se mueva en los dos ejes
        teclas.x = Input.GetAxis("Horizontal");
        teclas.z = Input.GetAxis("Vertical");

        //Se normalizan
        teclas = teclas.normalized;
        movimiento = teclas * velocidad * Time.deltaTime;

        //Para que se mueva
        transform.Translate(movimiento);
    }
    //Igual que desplazamiento normal pero más rapido
   public void Carrera()
    {
        teclas.x = Input.GetAxis("Horizontal");
        teclas.z = Input.GetAxis("Vertical");

        teclas = teclas.normalized;
        movimiento = teclas * velocidadCarrera * Time.deltaTime;


        transform.Translate(movimiento);
    }

}
  /*  public void Rotar()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles -= giroJugador;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.eulerAngles += giroJugador;
        }

    }*/


     

