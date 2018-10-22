using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Interactable {

    public List<Items> myInventory = new List<Items>();
    private DebugText debugg;
    //private GameObject g;
    private ItemsBase myBase;
    private GameObject gal;
    bool started = false;
    private int cont = 0;
  /*  float timeToWaitFor = 3f;
    float currentTime = 0f;*/
    int number = 0;
    private float tiempo = 0f;
    // private float maxdistance = 3f;
    // private bool interacciono=false;

    // Use this for initialization
    void Start () {
        myBase = GameObject.FindGameObjectWithTag("ItemsBase").GetComponent<ItemsBase>();
        /*print(myBase.myItems[0].itemName);
        print(myBase.myItems[1].itemName);*/
        //  debugg = GameObject.Find("DebugText");
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }

    private void Update()
    {
        //Añado los Items interactuables al inventario
        AñadirItemsInventario();

        //Si hay algun item repetido le incremento la cantidad 
        
        ItemsInventarioRepetidos();
    

        //Abrir inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            debugg.DebuggingText("Inventario abierto");

         /*   if (!started)
            {
                StartCoroutine(TiempoCouroutine(5));
            }*/
           
            //Debug.Log(number);

            //Si no hay nada
            if (myInventory.Count == 0 )
            {
                debugg.DebuggingText("No hay ningun objeto en el inventario");
                
            }
            else
            {
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
        for (int i = 0; i < myInventory.Count; i++)
        {

            if(Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.I))
            {
                debugg.DebuggingText("Has eliminado: 1" + myInventory[0].itemName.ToString());
                //Si la cantidad es mayor que 1 se quita uno a la cantidad
                if (myInventory[0].cantidad > 1)
                {
                    myInventory[0].cantidad--;
                }
                else
                {
                    //Se elimina el elemento del inventorio si la cantidad es 1
                    myInventory.RemoveAt(0);
                }
                
                

            }
        }
    }



    private void AñadirItemsInventario()
    {
       
        /*
         
        
        
        
        Quiero hacer que si hay dos objetos que se llaman igual sean los dos 
         sean interactuables a la vez no solo uno



        */

        //Se recorre la lista de los items que hay disponibles en el juego
        for (int i = 0; i < myBase.myItems.Count; i++)
        {
                gal = GameObject.Find(myBase.myItems[i].itemName);


            //     Debug.Log(i);
            //Para que cuando desaparaezca el objecto no de fallo
            if (gal == null)
            {

                continue;
            }
            //Los objectos interactuables se ponen rosa
            if (gal)
            {
                gal.transform.GetComponent<Renderer>().material.color = Color.magenta;
            }

            //Debug.Log(myBase.myItems[i].itemName);

            
            // Debug.Log(distancia);
            //Distancia del jugador al objecto
            float distancia = Vector3.Distance(gal.transform.position, GameObject.Find("Cube").transform.position);

            //private Transform palo;
            // debugg.DebuggingText(distancia.ToString());
            //  Debug.Log(distancia);
            // && 
            //Si es menor que la máxima distancia de interaccion puede interactuar
            if (distancia <= maxdistance)
            {
                //mensaje en pantalla
                debugg.DebuggingText("Pulsa E para interactuar con el objecto");

                
                 
                
               /* if (Input.GetKey(KeyCode.T))
                { 
                    StartCoroutine(TiempoCouroutine());
                    
                }*/
               
                //Si se pulsa E interaccionas con el
                if (Input.GetKey(KeyCode.E))
                {

                    /*if (gal != null)
                    {*/
                        //Se añade al inventario
                        myInventory.Add(myBase.myItems[i]);
                       // g = GameObject.Find(myBase.myItems[i].itemName);
                        Interact(gal);

                        //   interacciono = true;
                  //  }
                }
            }

            /*
            
        
        
        
        Quiero hacer que si ya no esta a la la distancia de interaccion
             que no ponga que pulse E para ello quiero parar la ejecucion x segundos
             
         
         */
             
         
      



            /*   else if(distancia > maxdistance)
                   {
       debugg.DebuggingText("");
                   }   
               */

        }
        //   StartCoroutine(TiempoCouroutine());
    }
    //Se elimina el objecto y quitas el mensaje de pulsar de la pantalla
    public void Interact(GameObject ga)
    {
        debugg.DebuggingText("");
        Destroy(ga);
        
    }
    
  /*  IEnumerator TiempoCouroutine()
    {
        started = true;
  
           
            yield return new WaitForSeconds(5.0f);//La subrutina se ejecuta cada timeToWaitFor
        
        started = false;
    }*/
    
}
