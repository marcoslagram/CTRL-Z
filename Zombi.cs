using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour {
    private Transform Player;
    public Transform[] points;
    public float umbralPerseguimiento;
    private int destPoint = 0;
    private NavMeshAgent agent;


    // Variables para distraccion
    private float probabilidadDistraccón = 1.0f; //Ira disminuyendo a medida que distraigas con el objeto
    public int distancia_maxima = 40;       //Para tener en cuenta la distancia hay que saber cuál es la distancia máxima del campo
    private bool estaDistraido = false;    //Si lo distraes va al objeto distractor
    private Transform Distractor;
    // Use this for initialization
    void Start () {

        if (agent == null) {
            agent = this.gameObject.GetComponent<NavMeshAgent>();
        }

        //Indica donde está el jugador para perseguirlo si está muy cerca
        Player = GameObject.FindWithTag("Player").transform;

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        agent.SetDestination(agent.destination);



        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //destPoint = (destPoint + 1) % points.Length;

        destPoint = (int)System.Math.Ceiling(Random.value * points.Length) - 1;



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

    // Update is called once per frame
    void Update () {

        //En cuanto distraiga algo inicializar distractor
        /*
        Distractor = GameObject.FindWithTag("Distractor").transform;
        estaDistraido = true;
        */

        //Miro mi distancia con el jugador
        float distanciaJugador = Vector3.Distance(Player.position, transform.position);
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (estaDistraido)
        {
            distraccion();
        }

        if (distanciaJugador < umbralPerseguimiento)
        {
            PersigueJugador();
        }
        else
            //GotoNextPoint();
        {
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }
        
}
