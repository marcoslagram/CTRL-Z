using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombi : MonoBehaviour {
    private Transform Player; //Me da la posicion del jugador
    private Transform[] PointsPosition;//Posiciones de los puntos
    public float umbralPerseguimiento;//La distancia a partir de la cual el zombi persigue al jugador
    private int destPoint = 0;
    private NavMeshAgent agent;
    private float[] vectorProbabilidades = null; //Aquí quiero tener el valor de la variable valorProbabilidad de cada Punto

    public GameObject[] Balizas = null; //Todos los objetos Punto

    // Variables para distraccion (AUN NO IMPLEMENTADO)
    private float probabilidadDistraccion = 1.0f; //Ira disminuyendo a medida que distraigas con el objeto
    public int distancia_maxima = 40;       //Para tener en cuenta la distancia hay que saber cuál es la distancia máxima del campo
    private bool estaDistraido = false;    //Si lo distraes va al objeto distractor
    private Transform Distractor;           //La posicion del objeto distractor
    // Use this for initialization

    void Start () {

        if (agent == null) {
            agent = this.gameObject.GetComponent<NavMeshAgent>();
        }

        //Inicializo los arrays
        vectorProbabilidades = new float[Balizas.Length];
        PointsPosition = new Transform[Balizas.Length];

        //Saco las posiciones de los puntos
        for (int i = 0; i<Balizas.Length; i++)
        {
            PointsPosition[i] = Balizas[i].transform;
        }
        //Indica donde está el jugador para perseguirlo si está muy cerca
        Player = GameObject.FindWithTag("Player").transform;   

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //Inicialmente va a un punto aleatorio.
        destPoint = (int)System.Math.Ceiling(Random.value * PointsPosition.Length) - 1;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (PointsPosition.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = PointsPosition[destPoint].position;

        agent.SetDestination(agent.destination);


        destPoint = ElegirPunto();


    }

    void PersigueJugador()
    {
        agent.SetDestination(Player.position);
    }

    void distraccion()
    {
        agent.SetDestination(Distractor.position);
        estaDistraido = false;
    }

    int ElegirPunto()
    {

        print("*******Nueva ronda*******");
        for (int i = 0; i < Balizas.Length; i++) {
            vectorProbabilidades[i] = Balizas[i].GetComponent<Punto>().valorProbabilidad;
            print("VectorProbabilidades[" + i + "] = " + vectorProbabilidades[i]);
        }

        float total = 0;
        foreach(float elem in vectorProbabilidades)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < vectorProbabilidades.Length; i++)
        {
            if (randomPoint < vectorProbabilidades[i])
            {
                return i;
            } else
            {
                randomPoint -= vectorProbabilidades[i];
            }
        }

        return vectorProbabilidades.Length -1;
    }

    // Update is called once per frame
    void Update () {

        //En cuanto distraiga algo inicializar distractor
        /*
        Distractor = GameObject.FindWithTag("Distractor").transform;
        estaDistraido = true;
        */

        //Miro mi distancia con el jugador
        float distanciaJugador = Vector3.Distance(Player.position, transform.position);
        
        //Si distraen al zombi va hacia el objeto distractor
        if (estaDistraido)
        {
            distraccion();
        }

        //Si estoy cerca del jugador voy a por el
        if (distanciaJugador < umbralPerseguimiento)
        {
            PersigueJugador();
        }
        else
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }
        
}
