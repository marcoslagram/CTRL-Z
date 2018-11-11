using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour {

	[SerializeField]  public float valorProbabilidad = 1f; //Cada punto tiene una probabilidad
	[SerializeField] readonly int interval = 1; //La funcion se actualiza cada segundo
    [SerializeField] public int distancia_maxima = 40; //Para tener en cuenta la distancia hay que saber cuál es la distancia máxima del campo
	float nextTime = 0;
    private Transform Player;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTime)
		{
            //Cada segundo va incrementado el valor de la probabilidad de ese punto 
            //inversamente proporcional a la distancia a la que se encuentre el jugador
			valorProbabilidad = valorProbabilidad + ProximityCheck();
			nextTime += interval;
            //print("Valor probabilidad = " + valorProbabilidad);
		}
	}

	
	float ProximityCheck()
	{
		float distancia = 0;
        float lejania = 0;
		distancia = Vector3.Distance(transform.position, Player.transform.position);
        lejania = distancia_maxima - distancia;
        //print("Lejania: " + lejania);
		return lejania;
	}
}
