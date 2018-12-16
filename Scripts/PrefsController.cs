using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PrefsController : MonoBehaviour
{

    public PreferenciasJugador datosPreferencias = new PreferenciasJugador();


    // Use this for initialization
    void Start()
    {
        LoadPreferencesData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SavePreferencesData()
    {
        //preferencias del jugador
        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSlider = datosPreferencias.volumenSlider;
        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSliderAmbiente = datosPreferencias.volumenSliderAmbiente;
        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSliderEfectos = datosPreferencias.volumenSliderEfectos;
        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenGeneralMixer = datosPreferencias.volumenGeneralMixer;
        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.idioma = datosPreferencias.idioma;
    }

    public void SavePreferencesToDisk()
    {
        SavePreferencesData();

        if (!Directory.Exists("datosPrefs"))
        {
            Directory.CreateDirectory("datosPrefs");
        }

        BinaryFormatter myFormatterPrefs = new BinaryFormatter();

        FileStream saveFilePrefs = File.Create("datosPrefs/misPreferencias.myBinary");

        PreferenciasJugador localCopyOfPrefs = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences;

        myFormatterPrefs.Serialize(saveFilePrefs, localCopyOfPrefs);

        saveFilePrefs.Close();
    }

    void LoadPreferencesData()
    {
        //preferencias del jugador
        datosPreferencias.volumenSlider = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSlider;
        datosPreferencias.volumenSliderAmbiente = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSliderAmbiente;
        datosPreferencias.volumenSliderEfectos = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenSliderEfectos;
        datosPreferencias.volumenGeneralMixer = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.volumenGeneralMixer;
        datosPreferencias.idioma = DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences.idioma;
    }

    public void LoadPreferencesFromDisk()
    {
        BinaryFormatter myFormatterPrefs = new BinaryFormatter();

        FileStream filePrefsToLoad = File.Open("datosPrefs/misPreferencias.myBinary", FileMode.Open);

        PreferenciasJugador tempCopyOfPrefs = (PreferenciasJugador)myFormatterPrefs.Deserialize(filePrefsToLoad);

        filePrefsToLoad.Close();

        DatosGuardadosMenu.g_GameDataInstanceMenu.savedPreferences = tempCopyOfPrefs;
    }
}

