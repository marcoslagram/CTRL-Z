using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DialogoNPC : Interactable {


    private MotorDialogo motorDialogo;

    private string nombreNPC;

    public bool empiezaJuego=false;
    public bool sigueJuego = false;
    private bool salio = false;
    private bool interactuo = false;

    //public static int dia=0;
    //Al empezar el juego
   [TextArea(1, 20)]
    public string[] oracionEmpezar;

    //Instruccion control
    [TextArea(1, 20)]
    public string[] oracionControl;

 /*   //Instruccion interactuar
    [TextArea(1, 20)]
    public string[] oracionInteractuar;*/

    //Instruccion inventario
    [TextArea(1, 20)]
    public string[] oracionInventario;


    
    //Conversacion dia1

    [TextArea(1, 20)]
 public string[] oracionConverNPC1;

    [TextArea(1, 20)]
    public string[] oracionConverJugadorV1;
    [TextArea(1, 20)]
    public string[] oracionConverJugadorF1;

    //Conversacion dia2

    [TextArea(1, 20)]
    public string[] oracionConverNPC2;

    [TextArea(1, 20)]
    public string[] oracionConverJugadorV2;
    [TextArea(1, 20)]
    public string[] oracionConverJugadorF2;


    //Conversacion dia3

    [TextArea(1, 20)]
    public string[] oracionConverNPC3;

    [TextArea(1, 20)]
    public string[] oracionConverJugadorV3;
    [TextArea(1, 20)]
    public string[] oracionConverJugadorF3;


    //Conversacion dia4

    [TextArea(1, 20)]
    public string[] oracionConverNPC4;

    [TextArea(1, 20)]
    public string[] oracionConverJugadorV4;
    [TextArea(1, 20)]
    public string[] oracionConverJugadorF4;


    private DebugText debugg;



    private Tiempo tiempoDia;
    private Inventory invetarioDia;
    private MovimientoJugador movePlayer;
    private CamaraCont moveCamara;
    private Saltar salto;
    private Control miControl;
    private ColliderObjetos interLata;
    private MotorSonido sonido;
    // private GestionDias dia;

    public GameObject dialogo;
    public GameObject tutorial;

    private GameObject[] zombies;

   // private Inventory tamanoInventario;

  /*  public GameObject dialogoCanvas;

    public GameObject dialogoTexto;*/

    private float tiempo;
    //private float tiempoConverso;

    public static bool salieronDialog=false;

    /* public bool pulsad;
     public Interactable pulsar;*/
     public static bool conversacionGatoTerminada=false;

    // Use this for initialization
    void Start () {
      //  zombies= GameObject.FindGameObjectsWithTag("Zombie");
        //  tiempo = 10f;
    
            tiempoDia = GameObject.Find("Player").GetComponent<Tiempo>();
       
        miControl = GameObject.Find("Player").GetComponent<Control>();
        sonido = GameObject.Find("Cube").GetComponent<MotorSonido>();
        invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
        movePlayer = GameObject.Find("Cube").GetComponent<MovimientoJugador>();
        moveCamara = GameObject.Find("Camera").GetComponent<CamaraCont>();
        salto = GameObject.Find("Cube").GetComponent<Saltar>();
        //Se encuentra el objecto
        motorDialogo = GameObject.Find("MotorDialogo").GetComponent<MotorDialogo>();
        // tamanoInventario = GameObject.Find("Inventory").GetComponent<Inventory>();
        interLata = GameObject.Find("Cube").GetComponent<ColliderObjetos>();
        //dia = GameObject.Find("Player").GetComponent<GestionDias>();
        //Le pongo el nombre del objecto
        nombreNPC = this.transform.name;
        //lo pongo de color azul
       // this.transform.GetComponent<Renderer>().material.color= Color.blue;
        //Debug fin conversacion
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
       // pulsad = pulsar.pulsado;


       
	}

    /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            pulsad = !pulsad;
        }
    }
    */

     void Update()
    {

        //Debug.Log(Menu.idiomaElegido + "Idioma");

        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        // tiempoDia.enabled = true;
        // dia++;
        // Debug.Log(empiezaJuego);
        if (GestionDias.dia == 1 && tiempoDia.tiempo >= 299.5f && tiempoDia.tiempo<=300f && !sigueJuego && !salieronDialog)
           {
               empiezaJuego = true;
           
               //Desabilitamos scripts
               tiempoDia.enabled = false;
               miControl.enabled = false;
               invetarioDia.enabled = false;
               movePlayer.enabled = false;
               moveCamara.enabled = false;
               salto.enabled = false;
               sonido.enabled = false;
         
             for (int i = 0; i < zombies.Length; i++)
             {
               
                 zombies[i].GetComponent<NavMeshAgent>().enabled = false;
                 zombies[i].GetComponent<Zombi>().enabled = false;
            }
          //  Debug.Log(zombies.Length);
            dialogo.SetActive(true);
               dialogo.transform.GetChild(3).gameObject.SetActive(false);//opcion 1
               dialogo.transform.GetChild(4).gameObject.SetActive(false);//opcion 2
              // dialogoTexto.SetActive(true);
               //GameObject.Find("Opcion1").SetActive(false);
               motorDialogo.oracionEmpezar = oracionEmpezar;
               motorDialogo.elegirConversacion = 0;
               motorDialogo.preguntaCueva = false;
               motorDialogo.InteractableWithNPC();
               motorDialogo.EntablarConversacionNPC();
            

        }
            if (empiezaJuego)
           {
               empiezaJuego = false;
              
            
                if (motorDialogo.finalConversacion == true)
                {
                   tiempoDia.enabled = true;
                   miControl.enabled = true;
                   invetarioDia.enabled = true;
                   movePlayer.enabled = true;
                   moveCamara.enabled = true;
                   salto.enabled = true;
                   sonido.enabled = true;

                for (int i = 0; i < zombies.Length; i++)
                {
                    zombies[i].GetComponent<NavMeshAgent>().enabled = true;
                    zombies[i].GetComponent<Zombi>().enabled = true;
                }
               
                sigueJuego = true;
                   dialogo.SetActive(false);
                   motorDialogo.salioTodo = false;
                   motorDialogo.i = 0;
                motorDialogo.finalConversacion = false;
                tiempo = 5f;
                 salieronDialog = true;
               
                }
            
           }
           
           else if(GestionDias.dia == 1 &&  sigueJuego) //Meter en otro texto

            {

            tiempo = tiempo - 1 * Time.deltaTime;
                if (tiempo <= 0)
                {
                   // Debug.Log("1");
                    tutorial.SetActive(true);
                    motorDialogo.oracionControl = oracionControl;
                    motorDialogo.elegirConversacion = 1;
                    motorDialogo.preguntaCueva = false;
                    motorDialogo.texto = 1;
                    motorDialogo.InteractableWithNPC();
                    motorDialogo.EntablarConversacionNPC();

                    if (motorDialogo.finalConversacion == true)
                    {
                       
                        sigueJuego = false;
                        tutorial.SetActive(false);
                        motorDialogo.salioTodo = false;
                        motorDialogo.i = 0;
                        motorDialogo.texto = 0;
                        motorDialogo.finalConversacion = false;
                        


                    }
                }

            }

            else if(invetarioDia.myInventory.Count>0 && !salio && GestionDias.dia == 1) //Meter en otro texto
        {
           
                tutorial.SetActive(true);
                motorDialogo.oracionInventario = oracionInventario;
                motorDialogo.elegirConversacion = 3;
                motorDialogo.preguntaCueva = false;
                motorDialogo.texto = 1;
                motorDialogo.InteractableWithNPC();
                motorDialogo.EntablarConversacionNPC();

                if (motorDialogo.finalConversacion == true)
                {
                    tutorial.SetActive(false);
                    motorDialogo.salioTodo = false;
                    salio = true;
                    motorDialogo.i = 0;
                    motorDialogo.texto = 0;
                    motorDialogo.finalConversacion = false;
                }
            }

           /*  if (!interLata.dentroColl)
            {
                dialogo.SetActive(false);
                interLata.dentroColl = true;
            }
            else if(interLata.colliderLata && GestionDias.dia == 1 && !interactuo)
            {
                dialogo.SetActive(true);
                motorDialogo.oracionInteractuar = oracionInteractuar;
                motorDialogo.elegirConversacion = 2;
                motorDialogo.preguntaCueva = false;
                motorDialogo.InteractableWithNPC();
                motorDialogo.EntablarConversacionNPC();


           

            //   Debug.Log(interLata.dentroColl);
            if (motorDialogo.finalConversacion == true)
                    {
                        //   Debug.Log("11");
                        
                        dialogo.SetActive(false);
                        motorDialogo.salioTodo = false;
                        interactuo = true;
                        motorDialogo.i = 0;
                        motorDialogo.finalConversacion = false;
                    }
        }*/


     

    }





    //Para interactuar al entrar
    public void OnTriggerEnter(Collider other)
    {
        debugg.DebuggingText("Pulsa E para hablar con el objecto");
    }
    public void OnTriggerStay(Collider other)
    {
        //Cuando entras en el trigger entra en la funcion
       
        motorDialogo.InteractableWithNPC();

        //Si se colisiona con el cubo y se presiona la E interactua
       if(other.gameObject.transform.name=="Cube" && Input.GetKeyDown(KeyCode.E))
        {
            conversacionGatoTerminada = false;
            //Entra en el if si nunca converso con el NPC
            if (motorDialogo.finalConversacionGato == false) {
                if (GestionDias.dia == 1)
                {
                    elegirConversacion = 10;
                }
               else if (GestionDias.dia == 2)
                {
                    elegirConversacion = 20;
                }

                else if (GestionDias.dia == 3)
                {
                    elegirConversacion = 30;
                }

                else if (GestionDias.dia == 2)
                {
                    elegirConversacion = 40;
                }

                 
                dialogo.SetActive(true);
               // dialogo.transform.GetChild(3).gameObject.SetActive(true);//opcion 1
            //    dialogo.transform.GetChild(4).gameObject.SetActive(true);//opcion 2
                //Día 1
                if (elegirConversacion == 10)
                {

                    motorDialogo.oraciones = oracionConverNPC1;
                    motorDialogo.oracionesJugadorV = oracionConverJugadorV1;
                    motorDialogo.oracionesJugadorF = oracionConverJugadorF1;
                    motorDialogo.preguntaCueva = true;
                }

                //Día 2
                if (elegirConversacion == 20)
                {
                    motorDialogo.oraciones = oracionConverNPC2;
                    motorDialogo.oracionesJugadorV = oracionConverJugadorV2;
                    motorDialogo.oracionesJugadorF = oracionConverJugadorF2;
                    motorDialogo.preguntaCueva = true;
                }

                //Día 3
                if (elegirConversacion == 30)
                {
                    motorDialogo.oraciones = oracionConverNPC3;
                    motorDialogo.oracionesJugadorV = oracionConverJugadorV3;
                    motorDialogo.oracionesJugadorF = oracionConverJugadorF3;
                    motorDialogo.preguntaCueva = true;
                }

                //Día 4
                if (elegirConversacion == 40)
                {
                    motorDialogo.oraciones = oracionConverNPC4;
                    motorDialogo.oracionesJugadorV = oracionConverJugadorV4;
                    motorDialogo.oracionesJugadorF = oracionConverJugadorF4;
                    motorDialogo.preguntaCueva = true;
                }
                //Se asignan variables
                //  motorDialogo.nameNPC = nombreNPC;

                /*motorDialogo.oraciones = oracionConverNPC;
                motorDialogo.oracionesJugadorV = oracionConverJugadorV;
                motorDialogo.oracionesJugadorF = oracionConverJugadorF;*/

                //Se llama a la funcion para entablar conversacion
                motorDialogo.EntablarConversacionNPC();
            }
            else
            {
                dialogo.SetActive(true);
                //Si acaba la conversacion se pone que ha acabado
                debugg.DebuggingDialogos("Ya has conversado con el");
                //StartCoroutine(Espera());
                //StopCoroutine(Espera());
                

            }
        }
    }
    //Cuando se no está en el trigger
    public void OnTriggerExit(Collider other)
    {   dialogo.SetActive(false);
        conversacionGatoTerminada = true;
        debugg.DebuggingText("");
        //Entra en la función cuando no es interactuable
        motorDialogo.NoInteractableWithNPC();
    }

 /*   IEnumerator Espera()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(5f);
    }*/
}
