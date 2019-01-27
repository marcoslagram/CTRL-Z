using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardadoGeneral : MonoBehaviour {
   


    
  //  public Inventory lista;

    
    #region Singletons
    // Singleton
    public static DatosGuardadoGeneral guar_GameDataInstance;
    #endregion

    #region Public variables
    public SaveDatosGeneral savedGameDataGeneral = new SaveDatosGeneral();
   // public GameObject[] zombies;
    #endregion

    // instances of lists os spawnable objects when loading a file

    void Awake()
    {


        if (guar_GameDataInstance == null)
        {
            guar_GameDataInstance = this;
            //  DontDestroyOnLoad(gameObject);            //este nos va a servir para poder usar cosas de una escena en otra
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {

        


       /* lista = GameObject.Find("Inventory").GetComponent<Inventory>();
       
        savedGameData.tiempo = 300;
        
        savedGameData.myItems = new List<Items>();

        for (int i = 0; i < lista.myInventory.Count; i++)
        {

            savedGameData.myItems.Add(lista.myInventory[i]);
        }
       
     */
       
    }
}
