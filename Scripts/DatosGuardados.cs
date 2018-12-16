using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosGuardados : MonoBehaviour {
    public GameObject player;
    public GameObject zombie;
    public GameObject camara;
    public Transform consumibles;
    public Transform armas;


    [SerializeField] public Vector3[] zombiesSeri;
    [SerializeField] public Quaternion[] zombiesRotaSeri;
    public Inventory lista;

    //Image[] slotsConsumibles;
    //Image[] slotsArmas;
    #region Singletons
    // Singleton
    public static DatosGuardados g_GameDataInstance;
    #endregion

    #region Public variables
    public SaveDatos savedGameData = new SaveDatos();
    public ControladorDatosJuego saveDataDisk = new ControladorDatosJuego();
    public GameObject[] zombies;
    #endregion

    // instances of lists os spawnable objects when loading a file

    void Awake()
    {
           

        if (g_GameDataInstance == null)
        {
            g_GameDataInstance = this;
          //  DontDestroyOnLoad(gameObject);            //este nos va a servir para poder usar cosas de una escena en otra
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        lista = GameObject.Find("Inventory").GetComponent<Inventory>();
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
     //   slotsConsumibles = consumibles.GetComponentsInChildren<Image>();
       // slotsArmas = armas.GetComponentsInChildren<Image>();
        zombiesSeri=new Vector3[zombies.Length];
        zombiesRotaSeri= new Quaternion[zombies.Length];

        savedGameData.positionz = zombiesSeri;
        savedGameData.rotacionz = zombiesRotaSeri;
        savedGameData.tiempo = 300;
        savedGameData.salud = 100;
        savedGameData.energia = 100;
        savedGameData.usos = 4;
        savedGameData.objetosActivos = GameObject.FindGameObjectsWithTag("Objectos");
        //  savedGameData.sigue = false;
        savedGameData.myItems = new List<Items>();

        for (int i = 0; i < lista.myInventory.Count; i++)
        {

            savedGameData.myItems.Add(lista.myInventory[i]);
        }
      //;lista.myInventory
        savedGameData.positionj = player.transform.position;
        savedGameData.rotacionj = player.transform.rotation;
        savedGameData.positionc = camara.transform.position;
        savedGameData.rotacionc = camara.transform.rotation;
      //  savedGameData.objetosActivos = GameObject.FindGameObjectsWithTag("Objectos");
   //     savedGameData.zombiesActivos= GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < zombies.Length; i++)
        {
            savedGameData.positionz[i] = zombies[i].transform.position;
            savedGameData.rotacionz[i] = zombies[i].transform.rotation;
        }
    /*    savedGameData.consumibles = lista.slotsConsumibles;
        savedGameData.armas = lista.slotsArmas;*/

       /* for (int i = 0; i < slotsArmas.Length; i++)
        {
            savedGameData.armas[i] =null;
            savedGameData.consumibles[i] = null;

        }*/

        /* savedGameData.positionz = zombie.transform.position;
         savedGameData.rotacionz = zombie.transform.rotation;*/
    }
}
