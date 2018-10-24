using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MovimientoJugador {

    public Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector3(0, 10, 0);
        }
	}
}
