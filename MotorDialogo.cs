using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorDialogo : Interactable
{


    public string nameNPC;
   
    public string[] oraciones;

    public string[] oracionesJugadorV;

    public string[] oracionesJugadorF;
    
    public bool enConversacion = false;

    public bool finalConversacion = false;
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

    private DebugText debugg;
    

    void Start()
    {
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }

  

    //Si se no se puede interactuar es false
 public void InteractableWithNPC()
        {
            noInteractuable = false;
           
        }


    //Si aun no se empezo la conversacion se empieza, y si ya está empezada sigue
    public void EntablarConversacionNPC()
    {
       
            if (!enConversacion)
            {
                enConversacion = true;
                StartCoroutine(EmpiezaConversacion());
            }
        //Sigue la conversacion
        EmpiezaConversacion();

    }


    //Se hace la conversación
    private IEnumerator EmpiezaConversacion()
    {
        if (!noInteractuable)
        { 
        int i = 0;
        int x = 0;
            //para sacar oraciones iniciales
            while (i <= oraciones.Length)
            {
             
                if (i == oraciones.Length)
                {
                //Si se acabaron las frases del gato se comprueba si se sigue la conversacion con el jugador ono
                    if (oraciones[i - 1].Contains("?") && impreso == false)
                    {
                        //Si se pulsa V o ya se pulso anteriormente entre en la contestacion afirmativa
                        if (Input.GetKeyDown(KeyCode.V) || pulsado)
                        {
                            //Si se acabron todas las frases del jugador se acaba la conversación
                            if (x == oracionesJugadorV.Length)
                                {   //debugg("verdad");
                                    finalConversacion = true;
                                    enConversacion = false;
                                    impreso=true;
                                debugg.DebuggingText("Final conversación");
                            }
                         
                           //En caso contrario se pasan las frases a la funcion para que salgan las frases 
                           else
                            {
                                jugador = true;
                                //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                                if (Input.GetKeyDown(KeyCode.L) || x==0) { 
                                StartCoroutine(SaleConversacion(oracionesJugadorV[x])); 
                                x++;
                                pulsado = true;
                                }
                            }


                        }

                        //Si se pulsa F o ya se pulso anteriormente entre en la contestacion negativa
                        else if (Input.GetKeyDown(KeyCode.F) || pulsado)
                        {
                            //Si se acabron todas las frases del jugador se acaba la conversación
                            if (x == oracionesJugadorF.Length)
                            {   
                                finalConversacion = true;
                                enConversacion = false;
                                impreso = true;
                                debugg.DebuggingText("Final conversación");
                            }

                            //En caso contrario se pasan las frases a la funcion para que salgan las frases 
                            else
                            {
                                jugador = true;
                                //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                                if (Input.GetKeyDown(KeyCode.L) || x==0)
                                {
                                    StartCoroutine(SaleConversacion(oracionesJugadorF[x]));
                                    x++;
                                    pulsado = true;
                                }
                            }

                        }

                   }
                    //En el caso de que solo hable el gato se acaba la conversacion
                    else if(!oraciones[i - 1].Contains("?") && impreso1 == false)
                    {
                        finalConversacion = true;
                        enConversacion = false;
                        impreso1 = true;
                        debugg.DebuggingText("Final conversación");
                    }

                    
                }
                else
                {
                     jugador = false;
                    //Si se pulsa L sigue saliendo la conversacion o es la primera frase
                    if (Input.GetKeyDown(KeyCode.L) || i==0)
                    {
                        StartCoroutine(SaleConversacion(oraciones[i]));
                        i++;
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
            //Si habla el gato
            if (!jugador) { 
            debugg.DebuggingText(oracionSale + "  [" + nameNPC + "]");
            }
            //Si habla el jugador
            else
            {
                debugg.DebuggingText(oracionSale + "  [" + GameObject.Find("Cube").name + "]");
            }
    
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
            StopAllCoroutines();
          
        }
    }

}