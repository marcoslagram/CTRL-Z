using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Caza : MonoBehaviour {
    //Script para que el enemigo haga daño cuando detecte al player

    public Transform objetivo;
    private NavMeshAgent navegacion;
    private int daño;   //porque no quiero que este parametro pueda cambiarse

    // Use this for initialization
    void Start () {

        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        navegacion = GetComponent<NavMeshAgent>();
        daño = 0;

	}
	
	// Update is called once per frame
	void Update () {
        //con esto simplemente lo persigue, hay que hacer que cuando colisionen los dos, el player tenga algun tipo de cambio
        navegacion.SetDestination(objetivo.position);
	}

    //Funcion para que le haga daño, sino solo lo perseguiria
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);   //asi nos dice el objeto con el que esta colisionando
        Debug.Log("Colisionando");
        daño++;
        //Ahora lo que quiero es que cuando colisione la esfera con el cubo, el cubo cambie alguna de sus propiedades
        //transform.GetComponent<Renderer>.material.color = Color.magenta;
    }
}
