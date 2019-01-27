using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Caza : MonoBehaviour {
    //Script para que el enemigo haga daño cuando detecte al player

    public Image saludH;
    

    public Transform objetivo;
    private NavMeshAgent navegacion;
    [HideInInspector] public int damage;   //quiero que lo usen en otra clase, pero no que pueda cambiarse por el diseñador
    public int dano = 0;
  //  public int salud;
    private DebugText debugg;

    private Economia salud;

    public bool dentro = false;
    public bool entrado = false;
    public bool perdiendo = false;

    private float tiempoMatar;

    public static bool muerto = false;


    //public bool ataco = false ;


    //private NavMeshSurface[] surfaces;

    /* public bool pulsad;
     public Interactable pulsar;*/
    // Use this for initialization
    void Start()
    {
        //salud = 100;
        //  objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        navegacion = this.transform.GetComponent<NavMeshAgent>();
        damage = 0;
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
        salud= GameObject.Find("Enemigo").GetComponent<Economia>();
        // pulsad = pulsar.pulsado;


     /*   for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }*/
       
    }

    /* void Update()
    {
        navegacion.destination = objetivo.position;
    }*/
    // Update is called once per frame
    /*	void Update () {
           float distancia = Vector3.Distance(this.transform.position, GameObject.Find("Cube").transform.position);
            if (distancia <= 7)
            {
                navegacion.destination = objetivo.position;
            }
        }*/
    /* if (Input.GetKeyDown(KeyCode.M))
     {
         pulsad = !pulsad;
     }
     */
    //con esto simplemente lo persigue, hay que hacer que cuando colisionen los dos, el player tenga algun tipo de cambio
    // navegacion.SetDestination(objetivo.position);


    /*  void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.transform.name == "Cube")
         {
             dentro = true;
         }
     }*/

    void Update()
    {
    //   navegacion.b
           if (salud.salud == 0)
        {
            muerto = true;
            debugg.DebuggingText("Se acabo el juego");
            GameObject.Find("Cube").SetActive(false);
        }

        
        // tiempoMatar = tiempoMatar + 1 * Time.deltaTime;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {
            tiempoMatar = tiempoMatar + 1 * Time.deltaTime;
          
            if (tiempoMatar > 1f)
            {
                perdiendo = true;
                salud.salud = salud.salud - 10;
                tiempoMatar = 0f;
            }
            
            // entrado = false;

        }

      /*  if (salud.salud == 0)
        {
            debugg.DebuggingText("Se acabo el juego");
            GameObject.Find("Cube").SetActive(false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {
            
            salud.salud = salud.salud - 10;

            Debug.Log("AAAAAAAAAAAA111111111");

            // entrado = false;

        }

     
    }


   /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.transform.name == "Cube")
        {
            Debug.Log("AAAAAAAAAAAA111111111");
        }
            
    }*/

    //Funcion para que le haga daño, sino solo lo perseguiria
  /*  void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.transform.name == "Cube")
        {
            Debug.Log("AAAAAAAAAAAA111111111");
            salud.salud = salud.salud - 10;
            //Debug.Log("1");
        }
        //Debug.Log("aaaa");

        //   salud.salud = Sabersalud.salud(salud);


      //  saludH.fillAmount = salud.salud / 100;


        if (salud.salud == 0)
        {
            debugg.DebuggingText("Se acabo el juego");
            GameObject.Find("Cube").SetActive(false);
        }

        //Debug.Log(collision.gameObject.name);   //asi nos dice el objeto con el que esta colisionando
        //Debug.Log("Colisionando");
        // damage++;
         //Debug.Log("Daño es igual a " + damage);
         //return damage;
        //Ahora lo que quiero es que cuando colisione la esfera con el cubo, el cubo cambie alguna de sus propiedades
        //transform.GetComponent<Renderer>.material.color = Color.magenta; //para esto necesitamos un método Interact();
    }*/

    public int SaberSalud(int salud)
    {
        return salud;
    }


}




  
