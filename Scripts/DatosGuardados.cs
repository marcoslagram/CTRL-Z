using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardados : MonoBehaviour {
    public GameObject player;
    public GameObject zombie;
    public GameObject camara;
    #region Singletons
    // Singleton
    public static DatosGuardados g_GameDataInstance;
    #endregion

    #region Public variables
    public SaveDatos savedGameData = new SaveDatos();
    public GameObject[] zombies;
    #endregion

    // instances of lists os spawnable objects when loading a file

    void Awake()
    {
           

        if (g_GameDataInstance == null)
        {
            g_GameDataInstance = this;
          //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        savedGameData.positionz = new Vector3[zombies.Length];
        savedGameData.rotacionz = new Quaternion[zombies.Length];
        savedGameData.tiempo = 300;
        savedGameData.salud = 100;
        savedGameData.energia = 100;
        savedGameData.usos = 4;
      //  savedGameData.sigue = false;
        //savedGameData.myItems = new List<Items>();
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
           /* savedGameData.positionz = zombie.transform.position;
            savedGameData.rotacionz = zombie.transform.rotation;*/
    }
}
