using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosGuardadosMenu : MonoBehaviour
{
    #region Singletons
    // Singleton
    public static DatosGuardadosMenu g_GameDataInstanceMenu;
    #endregion

    #region Public variables
    //datos de CTRL-Z
    public PreferenciasJugador savedPreferences = new PreferenciasJugador();        //preferencias

    #endregion

    // instances of lists os spawnable objects when loading a file

    void Awake()
    {


        if (g_GameDataInstanceMenu == null)
        {
            g_GameDataInstanceMenu = this;
            //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
