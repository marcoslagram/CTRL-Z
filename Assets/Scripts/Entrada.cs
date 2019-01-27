using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entrada : MonoBehaviour {


    public Material noche;
   

    public GameObject luz;
    Inventory lista;
    public GameObject jugador;
    public bool palo = false;
    public bool piedra = false;
    public bool clavos = false;
    public bool cuerda = false;

    private DebugText debugg;

    private Tiempo tiempoDia;
    private MovimientoJugador movePlayer;
    private CamaraCont moveCamara;
    private Saltar salto;
    private Control miControl;
    private MotorSonido sonido;

    private GameObject[] zombies;

    public bool dentroCueva = false;

    public bool salirCine=false;
    // Use this for initialization
    void Start () {
        lista = GameObject.Find("Inventory").GetComponent<Inventory>();

        tiempoDia = GameObject.Find("Player").GetComponent<Tiempo>();
        miControl = GameObject.Find("Player").GetComponent<Control>();
        sonido = GameObject.Find("Cube").GetComponent<MotorSonido>();
        movePlayer = GameObject.Find("Cube").GetComponent<MovimientoJugador>();
        moveCamara = GameObject.Find("Camera").GetComponent<CamaraCont>();
        salto = GameObject.Find("Cube").GetComponent<Saltar>();

        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }

    // Update is called once per frame
    void Update() {

        

        for (int i = 0; i < lista.myInventory.Count; i++)
        {

            if (lista.myInventory[i].itemName == "Palo")
            {
                palo = true;
            }

            if (lista.myInventory[i].itemName == "Piedra")
            {
                piedra = true;
            }

            if (lista.myInventory[i].itemName == "Clavos")
            {
                clavos = true;
            }

            if (lista.myInventory[i].itemName == "Cuerda")
            {
                cuerda = true;
            }
        }
        //Si está dentro de la cueva
        if (dentroCueva)
        {
            tiempoDia.enabled = false;
            miControl.enabled = false;
        }
        //Debug.Log(dentroCueva);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" && ((palo && GestionDias.dia==1) || (piedra && GestionDias.dia == 2) || (clavos && GestionDias.dia == 3) || (cuerda && GestionDias.dia == 4)))// 
        {
            salirCine = true;
           
            Salida.cantidad = 0;
            Salida.usosMas = false;
            GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = false;
            jugador.transform.position = new Vector3(206.76f, 54.71f, 43.93f);
            GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = true;

            dentroCueva = true;
          //  movePlayer.enabled = false;
           // moveCamara.enabled = false;
          //  salto.enabled = false;
           // sonido.enabled = false;

        }


        else if(other.gameObject.transform.name == "Cube")
        {
            debugg.DebuggingText("Consigue primero el objeto para la construcción del arma");

            //Idioma elegido
            if (Menu.idiomaElegido == 0)
            {
                //debugg.DebuggingText("Pulsa E para interactuar con el objeto");
            }


            else if (Menu.idiomaElegido == 1)
            {
                //debugg.DebuggingText("Consigue primeiro o obxecto para a construcción da arma");
            }

            else if (Menu.idiomaElegido == 2)
            {
                //debugg.DebuggingText("First get the object for the construction of the weapom");
            }

        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {
            debugg.DebuggingText("");
        }
    }

  
}
