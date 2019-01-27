using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float maxdistance = 5f;
    public float distancia;
    public bool dentro = false;
    public int elegirConversacion;
    
    
 //   public GameObject[] g;
   // public DebugText debugg;
  //  public List<Items> myInventory = new List<Items>();
   // public ItemsBase myBase;
    

    // Use this for initialization
    void Start () {
      //  debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }

    // Update is called once per frame
    void Update()
    {
      //  InteractuarObjetos();
    }
    /*

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Enemigo")
        {
            dentro = true;
        }
    }*/



    /*   public virtual void InteractuarObjetos()
       {

           g = GameObject.FindGameObjectsWithTag("Objectos");

           //Debug.Log(g.Length);
           bool compro = false;
           for (int i = 0; i < g.Length; i++)
           {
               //Para que cuando desaparaezca el objecto no de fallo
               if (g[i] == null)
               {

                   continue;
               }
               //Los objectos interactuables se ponen rosa

               g[i].transform.GetComponent<Renderer>().material.color = Color.magenta;


               //Distancia del jugador al objecto
               float distancia = Vector3.Distance(g[i].transform.position, GameObject.Find("Cube").transform.position);

               //Si es menor que la máxima distancia de interaccion puede interactuar
               if (distancia <= maxdistance)
               {
                   //mensaje debug
                   debugg.DebuggingText("Pulsa E para interactuar con el objecto");

                   compro = true;


                   //Si se pulsa E interaccionas con el
                   if (Input.GetKey(KeyCode.E))
                   {


                       //Se añade al inventario
                       myInventory.Add(myBase.myItems[i]);
                       // g = GameObject.Find(myBase.myItems[i].itemName);
                       Interact(g[i]);
                   }
               }
           }
           if (compro == false)
           {
               debugg.DebuggingText("");

           }
       }

       public void Interact(GameObject ga)
       {
           debugg.DebuggingText("");
           Destroy(ga);

       }*/
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GameObject.Find("Cube").transform.position, maxdistance);
    }

}
