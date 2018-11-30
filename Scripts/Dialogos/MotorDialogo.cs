using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotorDialogo : MonoBehaviour
{

    public GameObject dialogo;

    public string nameNPC;
   
    public string[] oraciones;

    public string[] oracionesJugadorV;

    public string[] oracionesJugadorF;

   // public string[] oracionesEmpezar;

    //Al empezar el juego "0"

    public string[] oracionEmpezar;

    //Instruccion control "1"

    public string[] oracionControl;

    //Instruccion interactuar "2"

    public string[] oracionInteractuar;

    //Instruccion inventario "3"

    public string[] oracionInventario;


    public int elegirConversacion;

    public int texto = 0;

    //sustituir 
    public string[] conversacion;

    public string[] conversacionV;

    public string[] conversacionF;

    public bool preguntaCueva;

    public bool enConversacion = false;

    public bool finalConversacion = false;

    public bool finalConversacionGato = false;
    //dentro del rango
    public bool noInteractuable=true;

    //que se mantega pulsado v o f
    private bool pulsado = false;
    //Cuando se acaba se pone true porque se emprimio la conversacion jugador
    private bool impreso = false;
    //para saber quien hablan true=jugador falso=gato
    public bool jugador;
    //Cuando se acaba se pone true porque se emprimio la conversacion gato
    private bool impreso1 = false;

    public bool salioTodo = false;

    public bool botonPuls=false;
    public bool verdadPuls = false;
    public bool falsoPuls = false;

    //  private bool preguntaGato=false;

    private DebugText debugg;

   public int i = 0;
  

    void Start()
    {
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            pulsado = !pulsado;
        }
    }
    */

        public void BotonPulsado()
        {
        botonPuls = true;
        }

        public void VerdaderoPulsado()
        {
            verdadPuls = true;
        }

        public void FalsoPulsado()
        {
            falsoPuls = true;
        }



    //Si se no se puede interactuar es false
    public void InteractableWithNPC()
        {
            noInteractuable = false;
            
       
           // preguntaCueva = false;
         //Empiezo
        if (elegirConversacion == 0) 
        {
            conversacion = oracionEmpezar;
        }

        //Control
        if (elegirConversacion == 1) 
        {
            //Debug.Log("AAAAA");
            conversacion = oracionControl;
            preguntaCueva = false;
        }

        //Interactuar
        if (elegirConversacion == 2)
        {
            conversacion = oracionInteractuar;
            preguntaCueva = false;
        }

        //Inventario
        if (elegirConversacion == 3)
        {
            conversacion = oracionInventario;
            preguntaCueva = false;
        }

       /* //Día 1
        if (elegirConversacion == 10)
        {
            conversacion = oracionConverNPC1;
            conversacionV = oracionConverJugadorV1;
            conversacionF = oracionConverJugadorF1;
            preguntaCueva = true;
        }

        //Día 2
        if (elegirConversacion == 20)
        {
            conversacion = oracionConverNPC2;
            conversacionV = oracionConverJugadorV2;
            conversacionF = oracionConverJugadorF2;
            preguntaCueva = true;
        }

        //Día 3
        if (elegirConversacion == 30)
        {
            conversacion = oracionConverNPC3;
            conversacionV = oracionConverJugadorV3;
            conversacionF = oracionConverJugadorF3;
            preguntaCueva = true;
        }

        //Día 4
        if (elegirConversacion == 40)
        {
            conversacion = oracionConverNPC4;
            conversacionV = oracionConverJugadorV4;
            conversacionF = oracionConverJugadorF4;
            preguntaCueva = true;
        }*/


        

    }


    //Si aun no se empezo la conversacion se empieza, y si ya está empezada sigue
    public void EntablarConversacionNPC()
    {
       // Debug.Log(oracionEmpezar[0]);


        if (!enConversacion)
            {
                enConversacion = true;

                if (!preguntaCueva)
                {
                    StartCoroutine(EmpiezaConversacion(conversacion));
                }

                else
                {
                StartCoroutine(EmpiezaConversacion());
                }
                
            }
        //Sigue la conversacion
        if (!preguntaCueva)
        {
            EmpiezaConversacion(conversacion);
        }

        else
        {
            EmpiezaConversacion();
        }
        

    }


    private IEnumerator EmpiezaConversacion(string[] conversacion)
    {
       
        if (!noInteractuable)
        {
            //int i = 0;
           // Debug.Log("2");
            
            //para sacar oraciones iniciales
            while (i <= conversacion.Length)
            {



                //Debug.Log("Aqui");
                //Debug.Log(i + "AAA");
                // jugador = false;
                //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                  if ( (botonPuls || i == 0) && (i<conversacion.Length) && salioTodo==false) //Boton
                  {
                      StartCoroutine(SaleConversacion(conversacion[i]));
                      botonPuls = false;
                      i++;
                  }

                  else if(i==conversacion.Length && botonPuls)
                  {
                     finalConversacion = true;
                     enConversacion = false;
                     salioTodo = true;
                     debugg.DebuggingDialogos("Final conversación");
                    StopAllCoroutines();
                   }



                yield return 0;

            }
        }
    }

    //Se hace la conversación cueva
    private IEnumerator EmpiezaConversacion()
    {
        if (!noInteractuable)
        { 
        int w = 0;
        int x = 0;
            //para sacar oraciones iniciales
            while (w <= oraciones.Length)
            {

                


                if (w == oraciones.Length)
                {
                //Si se acabaron las frases del gato se comprueba si se sigue la conversacion con el jugador ono
                   // if (oraciones[i - 1].Contains("?") && impreso == false)//&& preguntaGato
                //    {
                        //Si se pulsa V o ya se pulso anteriormente entre en la contestacion afirmativa
                        if ((verdadPuls || pulsado) && impreso==false)//Boton
                        {
                        dialogo.transform.GetChild(2).gameObject.SetActive(true);//siguiente
                        dialogo.transform.GetChild(3).gameObject.SetActive(false);//opcion 1
                        dialogo.transform.GetChild(4).gameObject.SetActive(false);//opcion 2

                        GestionDias.respuesta = true;

                     //Si se acabron todas las frases del jugador se acaba la conversación
                        if (x == oracionesJugadorV.Length && botonPuls)
                                {   //debugg("verdad");
                            botonPuls = false;
                                    finalConversacionGato = true;
                                    enConversacion = false;
                                    impreso=true;
                            
                                debugg.DebuggingDialogos("Final conversación");
                            dialogo.SetActive(false);
                            //dialogo.transform.GetChild(3).gameObject.SetActive(false);//opcion 1
                           // dialogo.transform.GetChild(4).gameObject.SetActive(false);//opcion 2
                        }
                         
                           //En caso contrario se pasan las frases a la funcion para que salgan las frases 
                           else
                            {

                             
                                jugador = true;
                                //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                                if (botonPuls || x==0) {
                                botonPuls = false;
                                StartCoroutine(SaleConversacion(oracionesJugadorV[x])); 
                                x++;
                                pulsado = true;
                                }
                            }


                        }

                        //Si se pulsa F o ya se pulso anteriormente entre en la contestacion negativa
                        else if (falsoPuls || pulsado)
                        {
                        dialogo.transform.GetChild(2).gameObject.SetActive(true);//siguiente
                        dialogo.transform.GetChild(3).gameObject.SetActive(false);//opcion 1
                        dialogo.transform.GetChild(4).gameObject.SetActive(false);//opcion 2

                        GestionDias.respuesta = false;


                        //Si se acabaron todas las frases del jugador se acaba la conversación
                        if (x == oracionesJugadorF.Length && botonPuls)
                            {
                            botonPuls = false;
                            finalConversacionGato = true;
                                enConversacion = false;
                                impreso = true;
                                debugg.DebuggingDialogos("Final conversación");
                            
                            dialogo.SetActive(false);
                           // dialogo.transform.GetChild(3).gameObject.SetActive(false);//opcion 1
                          //  dialogo.transform.GetChild(4).gameObject.SetActive(false);//opcion 2
                        }

                            //En caso contrario se pasan las frases a la funcion para que salgan las frases 
                            else
                            {


                                jugador = true;
                                //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                                if (botonPuls || x==0)
                                {
                                botonPuls = false;
                                StartCoroutine(SaleConversacion(oracionesJugadorF[x]));
                                    x++;
                                    pulsado = true;
                                }
                            }

                        }
                        
                   //}
                   /* //En el caso de que solo hable el gato se acaba la conversacion
                    else if(!oraciones[i - 1].Contains("?") && impreso1 == false && Input.GetKeyDown(KeyCode.L))
                    {
                        finalConversacion = true;
                        enConversacion = false;
                        impreso1 = true;
                        debugg.DebuggingDialogos("Final conversación");
                    }*/

                    
                }


                else if (w == oraciones.Length-2)
                {
                    dialogo.transform.GetChild(3).gameObject.GetComponentInChildren<Text>().text= oraciones[w];//opcion 1
                    w++;
                }

                else if (w == oraciones.Length - 1)
                {
                    dialogo.transform.GetChild(4).gameObject.GetComponentInChildren<Text>().text = oraciones[w];//opcion 2
                    w++;
                }



                else
                {
                     jugador = false;
                    //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                    if (botonPuls || w==0)//Boton
                    {

                        if (w == oraciones.Length - 3)
                        {
                            dialogo.transform.GetChild(2).gameObject.SetActive(false);//siguiente
                            dialogo.transform.GetChild(3).gameObject.SetActive(true);//opcion 1
                            dialogo.transform.GetChild(4).gameObject.SetActive(true);//opcion 2

                        }
                        botonPuls = false;
                        StartCoroutine(SaleConversacion(oraciones[w]));
                        w++;
                    }
                
                }
               
                yield return 0;     

            }
        }
    }
            
    
    //Sale la conversación
    private IEnumerator SaleConversacion(string oracionSale)
    {
        //Si se puede interactuar
        if (!noInteractuable)
        {
            if (texto == 1)
            {
                debugg.DebuggingTutorial(oracionSale);
            }

            else
            {
                /*f(oracionSale.Contains("Sabela") || oracionSale.Contains("Gato Mistico"))
                {

                }*/
                debugg.DebuggingDialogos(oracionSale);
            }
            

            /*  if (!jugador) { 
              debugg.DebuggingDialogos(oracionSale + "  [" + nameNPC + "]");
              }
              //Si habla el jugador
              else
              {
                  debugg.DebuggingDialogos(oracionSale + "  [" + GameObject.Find("Cube").name + "]");
              }*/

            finalConversacion = false;

          
                yield return 0;
         
         //   finalConversacion = false;
        }

    }

    //Si es no interactable se paran todas las coroutines
    public void NoInteractableWithNPC()
    {
        noInteractuable = true;
        if (noInteractuable == true)
        {
           
            enConversacion= false;
            debugg.DebuggingDialogos("");
            StopAllCoroutines();
          
        }
    }

}