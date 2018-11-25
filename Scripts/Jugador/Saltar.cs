using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MovimientoJugador {

    public Rigidbody myRigidBody;
    public BoxCollider myBoxCollider;
    public int velocidadSalto;
    private bool tocaSuelo;
    private bool salta;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Terrain"));
        tocaSuelo = true;
    }


    // Use this for initialization
    void Start () {

        myBoxCollider = GetComponent<BoxCollider>();
        tocaSuelo = true;   //porque empezamos el juego con el jugador en el suelo
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && tocaSuelo == true)
        {
            myRigidBody.velocity = new Vector3(0, 5, 0);
            tocaSuelo = false; //porque si saltas ya no estas tocando el suelo
        }

    }

}
