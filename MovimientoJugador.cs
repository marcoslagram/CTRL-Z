using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {

    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float velocidadCarrera = 10f;


    private Transform myTransform;

    // Use this for initialization
    void Start () {
        
        myTransform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        DesplazamientoNormal();
        Correr();
        Saltar();
    }

    private void DesplazamientoNormal()
    {
        if (Input.GetKey(KeyCode.W))  //cuando pulsas W va hacia adelante
        {
            myTransform.Translate(new Vector3(0, 0, velocidad) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))  //cuando pulsas S va hacia atrás
        {
            myTransform.Translate(new Vector3(0, 0, -velocidad) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))  //cuando pulsas A va hacia la izquierda
        {
            myTransform.Translate(new Vector3(velocidad, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))  //cuando pulsas D va hacia la derecha
        {
            myTransform.Translate(new Vector3(-velocidad, 0, 0) * Time.deltaTime);
        }
    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))  //cuando pulsas W va hacia adelante
        {
            myTransform.Translate(new Vector3(0, 0, velocidadCarrera) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))  //cuando pulsas S va hacia atrás
        {
            myTransform.Translate(new Vector3(0, 0, -velocidadCarrera) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.A))  //cuando pulsas A va hacia la izquierda
        {
            myTransform.Translate(new Vector3(velocidadCarrera, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.D))  //cuando pulsas D va hacia la derecha
        {
            myTransform.Translate(new Vector3(-velocidadCarrera, 0, 0) * Time.deltaTime);
        }
    }

    private void Saltar()
    {

    }

}
