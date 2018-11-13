using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombi : MonoBehaviour {
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
    private float[,,] decisiones_Baliza = null;
    public GameObject[] Balizas = null; //Todos los objetos Punto
    public int filas_Balizas = 0;   //Variables necesarias para tener en memoria una matriz en lugar de un array
    public int columnas_Balizas = 0;//de Balizas, para mas sencilla implementacion
    private GameObject[][] matriz_Balizas = null;


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

        matriz_Balizas = new GameObject[filas_Balizas][];
        //Hago una matriz en memoria con la distribucion de balizas a partir del array de entrada
        for (int j = 0; j < filas_Balizas; j++)
        {
            matriz_Balizas[j] = new GameObject[columnas_Balizas];
        }

        int indice_array_Balizas = 0;
        for (int z = 0; z < columnas_Balizas; z++)
        {
            for (int x = 0; x < filas_Balizas; x++)
            {
                matriz_Balizas[z][x] = Balizas[indice_array_Balizas];
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
        for (int f = 0; f < filas_Balizas; f++)
        {
            for (int c = 0; c < columnas_Balizas; c++)
            {
                float numero_salidas = 0f;
                if (matriz_Balizas[f][c].GetComponent<Punto>().Norte)
                {
                    numero_salidas++;
                }
                if (matriz_Balizas[f][c].GetComponent<Punto>().Sur)
                {
                    numero_salidas++;
                }
                if (matriz_Balizas[f][c].GetComponent<Punto>().Este)
                {
                    numero_salidas++;
                }
                if (matriz_Balizas[f][c].GetComponent<Punto>().Oeste)
                {
                    numero_salidas++;
                }
                float probabilidad_salida = 1.0f / numero_salidas;
                if (matriz_Balizas[f][c].GetComponent<Punto>().Norte)
                {
                    decisiones_Baliza[f,c,0] = probabilidad_salida;
                } else
                {
                    decisiones_Baliza[f,c,0] = 0f;
                }
                
                if (matriz_Balizas[f][c].GetComponent<Punto>().Sur)
                {
                    decisiones_Baliza[f,c,1] = probabilidad_salida;
                } else
                {
                    decisiones_Baliza[f,c,1] = 0f;
                }
                if (matriz_Balizas[f][c].GetComponent<Punto>().Este)
                {
                    decisiones_Baliza[f,c,2] = probabilidad_salida;
                } else
                {
                    decisiones_Baliza[f,c,2] = 0f;
                }
                if (matriz_Balizas[f][c].GetComponent<Punto>().Oeste)
                {
                    decisiones_Baliza[f,c,3] = probabilidad_salida;
                } else
                {
                    decisiones_Baliza[f,c,3] = 0f;
                }
                print("Baliza[" + f + "][" + c + "] Norte: "+ decisiones_Baliza[f,c,0] + " Sur:" + decisiones_Baliza[f, c, 1] + " Este:" + decisiones_Baliza[f, c, 2] + " Oeste: " + decisiones_Baliza[f, c, 3]);
            }
        }

        //Indica donde está el jugador para perseguirlo si está muy cerca
        Player = GameObject.FindWithTag("Player").transform;   

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //Inicialmente va a un punto aleatorio.
        destPoint_fila = (int)System.Math.Ceiling(Random.value * filas_Balizas) - 1;
        destPoint_columna = (int)System.Math.Ceiling(Random.value * columnas_Balizas) - 1;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (matriz_Balizas.Length == 0)
        {
            print("ERROR EN LAS LONGITUDES DE LA MATRIZ_BALIZAS_POSICION");
            return;
        }

        // Set the agent to go to the currently selected destination.
        //print("GotoNextPoint");
        //print("Valor destPoint_columna: " + destPoint_columna);
        //print("Valor destPoint_fila: " + destPoint_fila);
        agent.destination = matriz_Balizas[destPoint_fila][destPoint_columna].transform.position;

        agent.SetDestination(agent.destination);

        ElegirPunto();


    }

    void PersigueJugador()
    {
        //Si es la primera iteraccion, al no haber elecion anterior no hace nada
        if (destPoint_fila_anterior != -1)
        {
            //Si puede perseguir al jugador beneficia la eleccion anterior
            decisiones_Baliza[destPoint_fila_anterior, destPoint_columna_anterior, eleccion_anterior] = (decisiones_Baliza[destPoint_fila_anterior, destPoint_columna_anterior, eleccion_anterior] * 1.2f);
        }
        
       
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
        
        //Elijo una de las posibles elecciones
        if (randomPoint < decisiones_Baliza[destPoint_fila,destPoint_columna, 0])
        {
            eleccion = 0;
        } else if (randomPoint < (decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + decisiones_Baliza[destPoint_fila, destPoint_columna, 1]))
        {
            eleccion = 1;
        } else if (randomPoint < (decisiones_Baliza[destPoint_fila, destPoint_columna, 0] + decisiones_Baliza[destPoint_fila, destPoint_columna, 1] + decisiones_Baliza[destPoint_fila, destPoint_columna, 2]))
        {
            eleccion = 2;
        } else
        {
            eleccion = 3;
        }

            //Si 0 va al Norte, si 1 va a Sur, si 2 va al Este y si 3 va al Oeste
            switch (eleccion)
        {
            case 0:
                print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_fila--;
                print("Valor destPoint_fila: " + destPoint_fila);
                break;
            case 1:
                print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_fila++;
                print("Valor destPoint_fila: " + destPoint_fila);
                break;
            case 2:
                print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_columna++;
                print("Valor destPoint_columna: " + destPoint_columna);
                break;
            case 3:
                print("Valor destPoint_fila(anterior)" + destPoint_fila + "Eleccion: " + eleccion);
                print("Valor destPoint_columna(anterior)" + destPoint_columna + "Eleccion: " + eleccion);
                destPoint_columna--;
                print("Valor destPoint_columna: " + destPoint_columna);
                break;
            default:
                destPoint_columna = 0;
                destPoint_fila = 0;
                break;
        }
        return;
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
