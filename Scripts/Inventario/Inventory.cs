using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Interactable {

    public  List<Items> myInventory = new List<Items>();

    public GameObject invenarioCanvas;

    public Image energiaH;
    public Text usosH;

    public GameObject radio;
    public GameObject jugador;

    public Transform consumibles;
    public Transform armas;

   public Image[] slotsConsumibles;
  public  Image[] slotsArmas;


    public static List<Items> inventarioEstatico = new List<Items>();
    private DebugText debugg;
   private GameObject[] g;
    private ItemsBase myBase;
    private GameObject gal;

    public bool recoger = false;
    public bool tirarRadio = false;
    public bool consumirObjeto = false;

    int s = 0;
   public int energia;
    string inventario;
    private Economia miEconomia;
    // bool started = false;
    //private int cont = 0;
    /*  float timeToWaitFor = 3f;
      float currentTime = 0f;*/
    //  int number = 0;
    //  private float tiempo = 0f;
    // private float maxdistance = 3f;
    // private bool interacciono=false;
    int x;
    public int usosControl;

    public float tiempoCompro = 0f;
    public float tiempoCorrer = 0f;
    public float tiempoRecuperar = 0f;
    public bool correr = true;

    private bool abierto = false;
    // Use this for initialization
    void Start () {
        myBase = GameObject.FindGameObjectWithTag("ItemsBase").GetComponent<ItemsBase>();
        miEconomia = GameObject.Find("Enemigo").GetComponent<Economia>();
        /*print(myBase.myItems[0].itemName);
        print(myBase.myItems[1].itemName);*/
        //  debugg = GameObject.Find("DebugText");
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
        energia = 100;
        // usosControl = 2;
        

        slotsConsumibles = consumibles.GetComponentsInChildren<Image>();
        slotsArmas = armas.GetComponentsInChildren<Image>();
    }

     void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.M))
          {
              pulsado = !pulsado;
          }*/
        
        // energia = SaberEnergia(energia);
        energiaH.fillAmount = energia / 100f;
        //debugg.DebuggingEnergia("La energia es: " + energia.ToString());
        //  Debug.Log(usosControl);
        //&& Input.GetKeyDown(KeyCode.Z)
        /*  if (Input.GetKeyDown(KeyCode.LeftControl) )
          {
             // usosControl--;

             /* if (usosControl <= 0)
              {
                  usosControl = 0;
              }
          }*/


        if (myInventory.Count > 0)
        {
            Debug.Log(myInventory[0]);
        }


        if (energia > 0)
        {
            correr = true;
        }

        else
        {
            correr = false;
        }


       // Debug.Log("En  " + energia);

        if (Input.GetButton("Correr") && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0))
        {
          //  Debug.Log("Entr");
            tiempoCompro = tiempoCompro + 1 * Time.deltaTime;
            if (tiempoCompro >= 3f)
            {
                tiempoCorrer = tiempoCorrer + 1 * Time.deltaTime;
                if (tiempoCorrer >= 1f)
                {
                    if (energia > 0)
                    {
                        energia = energia - 5;
                    }

                    else
                    {
                        
                    }
                    
                    tiempoCorrer = 0f;
                }
            }
        }

        else
        {
            tiempoCompro = 0f;
            tiempoRecuperar = tiempoRecuperar + 1 * Time.deltaTime;

            if (tiempoRecuperar >= 5f)
            {
                if (energia == 100)
                {
                    energia = 100;
                }
                else
                {
                    energia = energia + 5;
                }

                tiempoRecuperar = 0f;
                
            }


        }

        recoger = false;
        tirarRadio = false;
      //  Debug.Log(jugador.transform.forward);
       // AsignarSpriteCorrespondiente();
        ActualizarCanvasInventario();
        // usosControl = SaberUsos(usosControl);
        usosH.text = "CTRL+Z: " + usosControl.ToString();
       // debugg.DebuggingUsos("Los usos de CTRL+Z: " + usosControl.ToString());
        //Añado los Items interactuables al inventario
        AñadirItemsInventario();

        //Si hay algun item repetido le incremento la cantidad 
        
        ItemsInventarioRepetidos();

      
     
        //Abrir inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            // debugg.DebuggingText("Inventario abierto");
            invenarioCanvas.SetActive(!invenarioCanvas.activeInHierarchy);
            //abierto = !abierto;
       
         /*   if (myInventory.Count == 0 )
            {
                debugg.DebuggingText("No hay ningun objeto en el inventario");
                
            }
            else
            {
                inventario = "Objectos en el inventario: \n" ;
                for (int i = 0; i < myInventory.Count; i++)
                { 
                    debugg.DebuggingText(inventario + myInventory[i].itemName.ToString() + "  Cantidad: " + myInventory[i].cantidad.ToString());
                    
                    inventario = inventario + myInventory[i].itemName.ToString() + "  Cantidad: " + myInventory[i].cantidad.ToString() + "\n";
                }}*/
               
      //  UsarItemsInventario();     
        }
        

    }

    private void ItemsInventarioRepetidos()
    {
        for (int i = 0; i < myInventory.Count; i++)
        {
            //Si esi es distinto de myInventory.Count - 1
            if (i != (myInventory.Count - 1))
            {
                //Se comprueba entre los elementos del inventario menos con el ultimo
                if (myInventory[i].itemName == myInventory[i + 1].itemName)
                {
                    myInventory[i].cantidad++;
                    myInventory.RemoveAt(i + 1);

                }
                //Se comprueban los elementos del inventario con el ultimo
                else if(myInventory[i].itemName == myInventory[myInventory.Count-1].itemName)
                {
                    myInventory[i].cantidad++;
                    myInventory.RemoveAt(myInventory.Count-1);
                }
            }

        
         }
    }


  /*  private void UsarItemsInventario()
    {
        //debugg.DebuggingEnergia("La energia es " + energia.ToString());
        for (int i = 0; i < myInventory.Count; i++)
        {
            

            if(Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.I))
            {
                debugg.DebuggingText("Has usado: 1 " + myInventory[0].itemName.ToString());
               

                if (myInventory[0].itemName.ToString() == "LataConserva")
                {
                   
                    usosControl ++;
                 //   debugg.DebuggingUsos("Los usos de CTRL+Z: " + usosControl.ToString());
                   // debugg.DebuggingEnergia("La energia es: " + energia.ToString());

                }
                else if(myInventory[0].itemName.ToString() == "PiedraEspecial")
                {

                    miEconomia.salud = 100;
                    
                }

                

                else if (myInventory[0].itemName.ToString() == "Tarta")
                {

                    energia = 100;
                }


                

                //Si la cantidad es mayor que 1 se quita uno a la cantidad
                if (myInventory[0].cantidad > 1 && (myInventory[0].itemName.ToString() == "PiedraEspecial" || myInventory[0].itemName.ToString() == "LataConserva" || myInventory[0].itemName.ToString() == "Tarta"))
                {
                    myInventory[0].cantidad--;
                }
                else if(myInventory[0].cantidad ==  1 && (myInventory[0].itemName.ToString() == "PiedraEspecial" || myInventory[0].itemName.ToString() == "LataConserva" || myInventory[0].itemName.ToString() == "Tarta"))
                {
                    //Se elimina el elemento del inventorio si la cantidad es 1
                    myInventory.RemoveAt(0);
                }
                
                

            }
        }
    }*/

   

    public void PulsarPiedra()
    {
        for (int i = 0; i < myInventory.Count; i++)
        {
            if(myInventory[i].cantidad>=1 && myInventory[i].id == 2)
            {

                if (myInventory[i].cantidad == 1)
                {
                    
                    slotsConsumibles[1].sprite = null;
                    slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = null;
                    slotsConsumibles[1].transform.GetChild(2).GetComponent<Text>().text = null;
                    myInventory.Remove(myInventory[i]);
                    // AsignarSpriteCorrespondiente();
                }

                else
                {
                    myInventory[i].cantidad--;
                }
                consumirObjeto = true;
                miEconomia.salud = 100;
                
            }
            
        }


    }


    public void PulsarTarta()
    {
        for (int i = 0; i < myInventory.Count; i++)
        {
            if (myInventory[i].cantidad >= 1 && myInventory[i].id == 3)
            {

                if (myInventory[i].cantidad == 1)
                {

                    slotsConsumibles[3].sprite = null;
                    slotsConsumibles[3].transform.GetChild(0).GetComponent<Text>().text = null;
                    slotsConsumibles[3].transform.GetChild(2).GetComponent<Text>().text = null;
                    myInventory.Remove(myInventory[i]);
                    // AsignarSpriteCorrespondiente();
                }

                else
                {
                    myInventory[i].cantidad--;
                }
                consumirObjeto = true;
                energia = 100;

            }

        }

    }


    public void PulsarRadio()
    {
        for (int i = 0; i < myInventory.Count; i++)
        {
            if (myInventory[i].cantidad >= 1 && myInventory[i].id == 7)
            {

                if (myInventory[i].cantidad == 1)
                {

                    slotsConsumibles[5].sprite = null;
                    slotsConsumibles[5].transform.GetChild(0).GetComponent<Text>().text = null;
                    slotsConsumibles[5].transform.GetChild(2).GetComponent<Text>().text = null;
                    myInventory.Remove(myInventory[i]);
                    
                    // AsignarSpriteCorrespondiente();
                }

                else
                {
                    myInventory[i].cantidad--;
                }
                tirarRadio = true;
                radio.transform.position = jugador.transform.position +jugador.transform.forward+jugador.transform.right;
                radio.SetActive(true);
               
                

            }

        }

    }

    private void AñadirItemsInventario()
    {


        g = GameObject.FindGameObjectsWithTag("Objectos");
        //Debug.Log(myBase.myItems[2]);
        //Debug.Log(g.Length);
        
        bool compro = false;
        for (int i = 0; i < g.Length; i++)
        {
            //Para despues agregarlo correctamente al inventario
            x=AsignarItemCorrespondiente(i);
            
       
            //Para que cuando desaparaezca el objecto no de fallo
            if (g[i] == null)
            {

                continue;
            }
            //Los objectos interactuables se ponen rosa
            
                g[i].transform.GetComponent<Renderer>(). material.color = Color.magenta;

       /* if (g[i].transform.name == "Palo")
                {
                    int x =0;
                }
                else
                {
                    int x = 1;
                }*/
            //Distancia del jugador al objecto
            float distancia = Vector3.Distance(g[i].transform.position, GameObject.Find("Cube").transform.position);
            // Debug.Log(distancia);
            //Si es menor que la máxima distancia de interaccion puede interactuar
           // Debug.Log(x);
            if (distancia <= maxdistance)
            {
                //mensaje debug
                debugg.DebuggingText("Pulsa E para interactuar con el objeto");

                recoger = true;

               // Debug.Log(recoger);
                //Idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //debugg.DebuggingText("Pulsa E para interactuar con el objeto");
                }

              
                else if (Menu.idiomaElegido == 1)
                {
                    //debugg.DebuggingText("Pulsa E para interactuar co obxecto");
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //debugg.DebuggingText("Press down E for interact with the object");
                }


                s = 0;
                compro = true;

               
                //Si se pulsa E interaccionas con el
                   if (Input.GetKey(KeyCode.E))
                    {

                    
                    //Se añade al inventario
                    myInventory.Add(myBase.myItems[x]);
                   // AsignarSpriteCorrespondiente();
                    

                   // g = GameObject.Find(myBase.myItems[i].itemName);
                    Interact(g[i]);

                    //   interacciono = true;
              //  }
            }
        }

            /*else
            {
                
            }
            */

        }

        if (compro == false && s==0)
        {
            debugg.DebuggingText("");
            s++;
        }
    }
    //Se elimina el objecto y quitas el mensaje de pulsar de la pantalla
     public void Interact(GameObject ga)
    {
        debugg.DebuggingText("");
        ga.SetActive(false);
        
    }

    public int AsignarItemCorrespondiente(int i)
    {
        if (g[i].transform.name == "Palo")
        {
            x = 0;
        }
        else if (g[i].transform.name == "LataConserva" || g[i].transform.name == "LataConserva(Clone)")
        {
            x = 1;
        }
        else if (g[i].transform.name == "PiedraEspecial" || g[i].transform.name == "PiedraEspecial(Clone)")
        {
            x = 2;
        }
        else if (g[i].transform.name == "Tarta" || g[i].transform.name == "Tarta(Clone)")
        {
            x = 3;
        }
        else if (g[i].transform.name == "Piedra")
        {
            x = 4;
        }
        else if (g[i].transform.name == "Clavos")
        {
            x = 5;
        }
        else if (g[i].transform.name == "Cuerda")
        {
            x = 6;
        }
        else if (g[i].transform.name == "Radio" || g[i].transform.name == "Radio(Clone)")
        {
            x = 7;
        }

        return x;
    }
  /*  public void ComprobarCantidad()
    {
          else if (myInventory[i].id == 1)
        {
            slotsConsumibles[0].sprite = myInventory[i].itemSprite;
            slotsConsumibles[0].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();
        }
        else if (myInventory[i].id == 2)
        {
            slotsConsumibles[1].sprite = myInventory[i].itemSprite;
            slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();
        }
        else if (myInventory[i].id == 3)
        {
            slotsConsumibles[2].sprite = myInventory[i].itemSprite;
            slotsConsumibles[2].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();
        }
    }*/
    public void AsignarSpriteCorrespondiente()
    {
        for(int i = 0; i < myInventory.Count;i++)
        {
            if (myInventory[i].id == 0)
            {
                slotsArmas[0].sprite = myInventory[i].itemSprite;
                
            }
           
          else if (myInventory[i].id == 4)
            {
                slotsArmas[1].sprite = myInventory[i].itemSprite;
            }
          else  if (myInventory[i].id == 5)
            {
                slotsArmas[2].sprite = myInventory[i].itemSprite;
            }
            else if (myInventory[i].id == 6)
            {
                slotsArmas[3].sprite = myInventory[i].itemSprite;
            }

            else if (myInventory[i].id == 1)
            {
                slotsConsumibles[0].sprite = myInventory[i].itemSprite;
                slotsConsumibles[0].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();


                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }


                slotsConsumibles[0].transform.GetChild(1).GetComponent<Text>().text = myInventory[i].itemDescription;////////////////////////
            }
            else if (myInventory[i].id == 2)
            {
                slotsConsumibles[1].sprite = myInventory[i].itemSprite;
                slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }
                slotsConsumibles[1].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;
            }
            else if (myInventory[i].id == 3)
            {
                slotsConsumibles[3].sprite = myInventory[i].itemSprite;
                slotsConsumibles[3].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }

                slotsConsumibles[3].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;
            }

            else if (myInventory[i].id == 7)
            {
               
                slotsConsumibles[5].sprite = myInventory[i].itemSprite;
                slotsConsumibles[5].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }

                slotsConsumibles[5].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;
            }


        }

       
    }

       public void ActualizarCanvasInventario()
       {
        //si inventario está vacio
        if (myInventory.Count == 0)
        {
            for(int i = 0; i < slotsArmas.Length; i++)
            {
                slotsArmas[i].sprite = null;
            }

            slotsConsumibles[0].sprite = null;
            slotsConsumibles[0].transform.GetChild(0).GetComponent<Text>().text = null;
            slotsConsumibles[0].transform.GetChild(1).GetComponent<Text>().text = null;
            slotsConsumibles[1].sprite = null;
            slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = null;
            slotsConsumibles[1].transform.GetChild(2).GetComponent<Text>().text = null;
            slotsConsumibles[3].sprite = null;
            slotsConsumibles[3].transform.GetChild(0).GetComponent<Text>().text = null;
            slotsConsumibles[3].transform.GetChild(2).GetComponent<Text>().text = null;
            slotsConsumibles[5].sprite = null;
            slotsConsumibles[5].transform.GetChild(0).GetComponent<Text>().text = null;
            slotsConsumibles[5].transform.GetChild(2).GetComponent<Text>().text = null;
        }


        for (int i = 0; i < myInventory.Count; i++)
        {
            //Armas
            if (myInventory[i].id == 0)
            {
                slotsArmas[0].sprite = myInventory[i].itemSprite;
                break;
            }


            else
            {
                slotsArmas[0].sprite = null;
            }

        }

        for (int i = 0; i < myInventory.Count; i++)
        {

            if (myInventory[i].id == 4)
            {
                slotsArmas[1].sprite = myInventory[i].itemSprite;
                break;
            }

            else
            {
                slotsArmas[1].sprite = null;
            }

        }

        for (int i = 0; i < myInventory.Count; i++)
        {

            if (myInventory[i].id == 5)
            {
                slotsArmas[2].sprite = myInventory[i].itemSprite;
                break;
            }

            else
            {
                slotsArmas[2].sprite = null;
            }
        }

        for (int i = 0; i < myInventory.Count; i++)
        {
            if (myInventory[i].id == 6)
            {
                slotsArmas[3].sprite = myInventory[i].itemSprite;
                break;
            }

            else
            {
                slotsArmas[3].sprite = null;
            }
        }
        //Consumibles

        for (int i = 0; i < myInventory.Count; i++)
        {

            if (myInventory[i].id == 1)
            {
                slotsConsumibles[0].sprite = myInventory[i].itemSprite;
                slotsConsumibles[0].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();


                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }
                slotsConsumibles[0].transform.GetChild(1).GetComponent<Text>().text = myInventory[i].itemDescription;

                //   myInventory.Contains("Palo")
                break;
            }

            else
            {
                slotsConsumibles[0].sprite = null;
                slotsConsumibles[0].transform.GetChild(0).GetComponent<Text>().text = null;
                slotsConsumibles[0].transform.GetChild(1).GetComponent<Text>().text = null;

            }


        }

        for (int i = 0; i < myInventory.Count; i++)
        {

            if (myInventory[i].id == 2)
            {
                slotsConsumibles[1].sprite = myInventory[i].itemSprite;
                slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }
                slotsConsumibles[1].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;

                break;

            }

            else
            {
                slotsConsumibles[1].sprite = null;
                slotsConsumibles[1].transform.GetChild(0).GetComponent<Text>().text = null;
                slotsConsumibles[1].transform.GetChild(2).GetComponent<Text>().text = null;

            }

        }


        for (int i = 0; i < myInventory.Count; i++)
        {

            if (myInventory[i].id == 3)
            {
                slotsConsumibles[3].sprite = myInventory[i].itemSprite;
                slotsConsumibles[3].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }
                slotsConsumibles[3].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;

                break;

            }


            else
            {
                slotsConsumibles[3].sprite = null;
                slotsConsumibles[3].transform.GetChild(0).GetComponent<Text>().text = null;
                slotsConsumibles[3].transform.GetChild(2).GetComponent<Text>().text = null;

            }

        }

        for (int i = 0; i < myInventory.Count; i++)
        {


            if (myInventory[i].id == 7)
            {
                slotsConsumibles[5].sprite = myInventory[i].itemSprite;
                slotsConsumibles[5].transform.GetChild(0).GetComponent<Text>().text = myInventory[i].cantidad.ToString();

                //Segun el idioma elegido
                if (Menu.idiomaElegido == 0)
                {
                    //Aqui se pondría la descripcion del ojecto en español
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 1)
                {
                    //Aqui se pondría la descripcion del ojecto en español en gallego
                    // myInventory[i].itemDescription = ".......";
                }

                else if (Menu.idiomaElegido == 2)
                {
                    //Aqui se pondría la descripcion del ojecto en español en inglés
                    // myInventory[i].itemDescription = ".......";
                }
                slotsConsumibles[5].transform.GetChild(2).GetComponent<Text>().text = myInventory[i].itemDescription;

                break;

            }

            else
            {
                slotsConsumibles[5].sprite = null;
                slotsConsumibles[5].transform.GetChild(0).GetComponent<Text>().text = null;
                slotsConsumibles[5].transform.GetChild(2).GetComponent<Text>().text = null;

            }
        }
        
       }

    /*  IEnumerator TiempoCouroutine()
      {
          started = true;


              yield return new WaitForSeconds(5.0f);//La subrutina se ejecuta cada timeToWaitFor

          started = false;
      }*/

    public int SaberEnergia(int energia)
    {
        return energia;
    }

    public int SaberUsos(int usos)
    {
        return usos;
    }

    public List<Items> SaberItems(List<Items> myInventory)
    {
        return myInventory;
    }
}



