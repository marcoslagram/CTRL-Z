using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Interactable {

    public  List<Items> myInventory = new List<Items>();


    public Image energiaH;
    public Text usosH;

    public static List<Items> inventarioEstatico = new List<Items>();
    private DebugText debugg;
   private GameObject[] g;
    private ItemsBase myBase;
    private GameObject gal;
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
            debugg.DebuggingText("Inventario abierto");

       
            if (myInventory.Count == 0 )
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
                }
                UsarItemsInventario();
            }
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


    private void UsarItemsInventario()
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
            
        /*    if (g[i].transform.name == "Palo")
        {
            x = 0;
        }
            if (g[i].transform.name == "LataConserva")
            {
                x = 1;
            }
            else
        {
             x = 2;
        }*/

          //  Debug.Log(i);
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
                debugg.DebuggingText("Pulsa E para interactuar con el objecto");
                s = 0;
                compro = true;

               
                //Si se pulsa E interaccionas con el
                   if (Input.GetKey(KeyCode.E))
                    {

                
                    //Se añade al inventario
                    myInventory.Add(myBase.myItems[x]);
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
        else if (g[i].transform.name == "LataConserva")
        {
            x = 1;
        }
        else if (g[i].transform.name == "PiedraEspecial")
        {
            x = 2;
        }
        else if (g[i].transform.name == "Tarta")
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
       
        return x;
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



