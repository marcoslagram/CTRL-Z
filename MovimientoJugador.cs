using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {


   [SerializeField] private float velocidad = 2;
   [SerializeField] private float velocidadCarrera = 10;
    private Vector3 teclas = new Vector3(0, 0, 0);
    private Vector3 movimiento = new Vector3(0, 0, 0);
    [SerializeField] private float velocidadGiro = 60; //degrees
    private Vector3 giroJugador = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
       giroJugador = new Vector3(0, velocidadGiro * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {

        DesplazamientoNormal();
        Rotar();
        if (Input.GetButton("Correr")) { 
        Carrera();}

    }

    public void DesplazamientoNormal()
    {
        teclas.x = Input.GetAxis("Horizontal");
        teclas.z = Input.GetAxis("Vertical");

        teclas = teclas.normalized;
        movimiento = teclas * velocidad * Time.deltaTime;


        transform.Translate(movimiento);
    }

    public void Rotar()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles -= giroJugador;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.eulerAngles += giroJugador;
        }

    }


        public void Carrera()
    {
        teclas.x = Input.GetAxis("Horizontal");
        teclas.z = Input.GetAxis("Vertical");

        teclas = teclas.normalized;
        movimiento = teclas * velocidadCarrera * Time.deltaTime;


        transform.Translate(movimiento);
    }
}
