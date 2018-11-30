using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public  class Zombi : MonoBehaviour {
    private Transform Player; //Me da la posicion del jugador
    private Transform[] PointsPosition;//Posiciones de los puntos
    public float umbralPerseguimiento;//La distancia a partir de la cual el zombi persigue al jugador
    private int destPoint_fila;
    private int destPoint_columna;
    private int destPoint_fila_anterior = -1;    //Guarda el dato de la posicion anterior para en caso de ser beneficioso...
    private int destPoint_columna_anterior = 0; //... poder modificar las probabilidades
    private int eleccion_anterior;
    int eleccion = 3;                           //Tambien recuerda la eleccion para aumentar su probabilidad
    private NavMeshAgent agent;
    private float[] vectorProbabilidades = null; //Aquí quiero tener el valor de la variable valorProbabilidad de cada Punto
    private static float[,,] decisiones_Baliza = null;//Mirar esto
    public GameObject[] Balizas = null; //Todos los objetos Punto
    public int filas_Balizas = 6;   //Variables necesarias para tener en memoria una matriz en lugar de un array
    public int columnas_Balizas = 3;//de Balizas, para mas sencilla implementacion
    private GameObject[,] matriz_Balizas = null;
    private bool repetido = false;

    // Variables para distraccion (AUN NO IMPLEMENTADO)
    private float probabilidadDistraccion = 1.0f; //Ira disminuyendo a medida que distraigas con el objeto
    public int distancia_maxima = 40;       //Para tener en cuenta la distancia hay que saber cuál es la distancia máxima del campo
    private bool estaDistraido = false;    //Si lo distraes va al objeto distractor
    private Transform Distractor;           //La posicion del objeto distractor


    // Use this for initialization

    void Start()
    {

        if (agent == null)
        {
            agent = this.gameObject.GetComponent<NavMeshAgent>();
        }

        //Inicializo los arrays
        vectorProbabilidades = new float[Balizas.Length];
        PointsPosition = new Transform[Balizas.Length];

        //matriz_Balizas = new GameObject[filas_Balizas][];
        //Hago una matriz en memoria con la distribucion de balizas a partir del array de entrada
        matriz_Balizas = new GameObject[filas_Balizas, columnas_Balizas];
        //for (int j = 0; j < filas_Balizas; j++)
        //{
        //    matriz_Balizas[j] = new GameObject[columnas_Balizas];
        //}
        int indice_array_Balizas = 0;


        for (int z = 0; z < filas_Balizas; z++)
        {

            for (int x = 0; x < columnas_Balizas; x++)
            {

                matriz_Balizas[z, x] = Balizas[indice_array_Balizas];
                indice_array_Balizas++;

            }
        }

        //Hago otra matriz con los valores de las decisiones en cada baliza
        decisiones_Baliza = new float[filas_Balizas, columnas_Balizas, 4];

        //Establezco por defecto un valor inicial equiprobable en las salidas validas
        /*
         * Baliza[fila][columna][0] Probabilidad de ir al norte
         * Baliza[fila][columna][1] Probabilidad de ir al sur
         * Baliza[fila][columna][2] Probabilidad de ir al este
         * Baliza[fila][columna][3] Probabilidad de ir al oeste
         */
        if (GestionDias.dia == 1)
        {
            for (int f = 0; f < filas_Balizas; f++)
            {
                for (int c = 0; c < columnas_Balizas; c++)
                {
                    //float numero_salidas = 0f;
                    //if (matriz_Balizas[f,c].GetComponent<Punto>().Norte)
                    //{
                    //    numero_salidas++;
                    //}
                    //if (matriz_Balizas[f,c].GetComponent<Punto>().Sur)
                    //{
                    //    numero_salidas++;
                    //}
                    //if (matriz_Balizas[f,c].GetComponent<Punto>().Este)
                    //{
                    //    numero_salidas++;
                    //}
                    //if (matriz_Balizas[f,c].GetComponent<Punto>().Oeste)
                    //{
                    //    numero_salidas++;
                    //}
                    //float probabilidad_salida = 1.0f / numero_salidas;
                    float probabilidad_salida = 1.0f;
                    if (matriz_Balizas[f, c].GetComponent<Punto>().Norte)
                    {
                        decisiones_Baliza[f, c, 0] = probabilidad_salida;
                    }
                    else
                    {
                        decisiones_Baliza[f, c, 0] = 0f;
                    }

                    if (matriz_Balizas[f, c].GetComponent<Punto>().Sur)
                    {
                        decisiones_Baliza[f, c, 1] = probabilidad_salida;
                    }
                    else
                    {
                        decisiones_Baliza[f, c, 1] = 0f;
                    }
                    if (matriz_Balizas[f, c].GetComponent<Punto>().Este)
                    {
                        decisiones_Baliza[f, c, 2] = probabilidad_salida;
                    }
                    else
                    {
                        decisiones_Baliza[f, c, 2] = 0f;
                    }
                    if (matriz_Balizas[f, c].GetComponent<Punto>().Oeste)
                    {
                        decisiones_Baliza[f, c, 3] = probabilidad_salida;
                    }
                    else
                    {
                        decisiones_Baliza[f, c, 3] = 0f;
                    }
                    //   print("Baliza[" + f + "][" + c + "] Norte: " + decisiones_Baliza[f, c, 0] + " Sur:" + decisiones_Baliza[f, c, 1] + " Este:" + decisiones_Baliza[f, c, 2] + " Oeste: " + decisiones_Baliza[f, c, 3]);
                }
            }
        }

        //Indica donde está el jugador para perseguirlo si está muy cerca
        Player = GameObject.FindWithTag("Player").transform;
        GameObject[] PlayerArray = GameObject.FindGameObjectsWithTag("Player");
        // print("array size... tag" + PlayerArray.Length);
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //Inicialmente va al punto (1,1).
        destPoint_columna = 1;
        destPoint_fila = 1;
        //destPoint_fila = (int)System.Math.Ceiling(Random.value * filas_Balizas) - 1;
        //destPoint_columna = (int)System.Math.Ceiling(Random.value * columnas_Balizas) - 1;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (matriz_Balizas.Length == 0)
        {
            //  print("ERROR EN LAS LONGITUDES DE LA MATRIZ_BALIZAS_POSICION");
            return;
        }

        // Set the agent to go to the currently selected destination.
        //print("Valor destPoint_columna: " + destPoint_columna);
       // print("Valor destPoint_fila: " + destPoint_fila);
        //print("NUEVA Baliza[" + destPoint_fila + "][" + destPoint_columna + "] Norte: " + decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + " Sur:" + decisiones_Baliza[destPoint_fila, destPoint_columna, 1] + " Este:" + decisiones_Baliza[destPoint_fila, destPoint_columna, 2] + " Oeste: " + decisiones_Baliza[destPoint_fila, destPoint_columna, 3]);
        //agent.destination = matriz_Balizas[destPoint_fila,destPoint_columna].transform.position;
        // print("MatrizBalizasDestino: " + matriz_Balizas[destPoint_fila, destPoint_columna].transform.position);
        //NavMeshPath aux_path = new NavMeshPath();
        //agent.CalculatePath(matriz_Balizas[destPoint_fila, destPoint_columna].transform.position, aux_path);

        //Corrige un posible fallo
        if (destPoint_fila == -1)
        {
            destPoint_fila = 1;
        }

        if (destPoint_columna == -1)
        {
            destPoint_columna = 1;
        }

        agent.SetDestination(matriz_Balizas[destPoint_fila, destPoint_columna].transform.position); //Me devuelve la posicion del propio zombi???!!!
        //print("Agent.Destination: " + agent.destination); //Me está dando la posición del propio zombi
        //print("Path: " + agent.path.corners[0]);
        //agent.SetDestination(agent.destination);
        //print("Agent.Distance: " + agent.remainingDistance);

        ElegirPunto();


    }

    void PersigueJugador()
    {
        //Si es la primera iteraccion, al no haber elecion anterior no hace nada
        //print("DestPointFila" + destPoint_fila);
        //print("DestPoitnFilaANTERIOR: " + destPoint_fila_anterior);
        //print("DestPointCol: " + destPoint_columna);
        //print("DestPoitnColANTEROIR: " + destPoint_columna_anterior);
        //if ((destPoint_fila_anterior != -1) && (destPoint_fila != destPoint_fila_anterior) || (destPoint_columna != destPoint_columna_anterior))
        if ((destPoint_fila_anterior != -1) && !repetido)
        {
            //Si puede perseguir al jugador beneficia la eleccion anterior
            //print("Actualiza las probabilidades");
            decisiones_Baliza[destPoint_fila_anterior, destPoint_columna_anterior, eleccion_anterior] = (decisiones_Baliza[destPoint_fila_anterior, destPoint_columna_anterior, eleccion_anterior] * 1.20f);
            //print("Nuevas probabilidades" + decisiones_Baliza[destPoint_fila_anterior, destPoint_columna_anterior, eleccion_anterior]);
        }
        repetido = true;


        //Las actuales pasan a ser las anteriores
        destPoint_fila_anterior = destPoint_fila;
        destPoint_columna_anterior = destPoint_columna;
        eleccion_anterior = eleccion;


        agent.SetDestination(Player.position);
    }

    void distraccion()
    {
        agent.SetDestination(Distractor.position);
        estaDistraido = false;
    }

    void ElegirPunto()
    {
        //
        float randomPoint;

        //Como las probabilidades no suman 1 clculo la suma para normalizar las probabilidades
        float valor_sin_ponderar = (decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + decisiones_Baliza[destPoint_fila, destPoint_columna, 1] + decisiones_Baliza[destPoint_fila, destPoint_columna, 2] + decisiones_Baliza[destPoint_fila, destPoint_columna, 3]);

        randomPoint = Random.value * valor_sin_ponderar;


        float suma2 = decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + decisiones_Baliza[destPoint_fila, destPoint_columna, 1];
        float suma3 = decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + decisiones_Baliza[destPoint_fila, destPoint_columna, 1] + decisiones_Baliza[destPoint_fila, destPoint_columna, 2];
        //Elijo una de las posibles elecciones
        if (randomPoint < decisiones_Baliza[destPoint_fila, destPoint_columna, 0])
        {
            eleccion = 0;
        }
        else if (randomPoint < suma2)
        {
            eleccion = 1;
        }
        else if (randomPoint < suma3)
        {
            eleccion = 2;
        }
        else
        {
            eleccion = 3;
        }
        //  print("Eleccion: " + eleccion);
        //Si 0 va al Norte, si 1 va a Sur, si 2 va al Este y si 3 va al Oeste
        switch (eleccion)
        {
            case 0:
                //print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                //print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_fila--;
                //print("Valor destPoint_fila: " + destPoint_fila);
                break;
            case 1:
                //print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                //print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_fila++;
                //print("Valor destPoint_fila: " + destPoint_fila);
                break;
            case 2:
                //print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                //print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_columna++;
                //print("Valor destPoint_columna: " + destPoint_columna);
                break;
            case 3:
                //print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                //print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_columna--;
                //print("Valor destPoint_columna: " + destPoint_columna);
                break;
            default:
                destPoint_columna = 0;
                destPoint_fila = 0;
                break;
        }

        return;
    }

    // Update is called once per frame
    void Update()
    {

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
            repetido = false;
            if (agent.remainingDistance < 1.0f)
            {
                //print("Distancia restancte: " + agent.remainingDistance);
                //print("Cumple!!!!");
                // print("RemainigDistance: " + agent.remainingDistance);
                GotoNextPoint();
            }
        }
    }

}
