using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGuardadosPreferencia : MonoBehaviour {


    #region Singletons
    // Singleton
    public static DatosGuardadosPreferencia pref_GameDataInstance;
    #endregion

    #region Public variables
    public SaveDatosPreferencias savedGameDataPreferencias = new SaveDatosPreferencias();
    // public GameObject[] zombies;
    #endregion

    // instances of lists os spawnable objects when loading a file

    void Awake()
    {


        if (pref_GameDataInstance == null)
        {
            pref_GameDataInstance = this;
            //  DontDestroyOnLoad(gameObject);            //este nos va a servir para poder usar cosas de una escena en otra
        }
        else
        {
            Destroy(gameObject);
        }

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
