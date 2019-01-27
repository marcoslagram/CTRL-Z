using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ControladorDatosPreferencia : MonoBehaviour {


    public SaveDatosPreferencias nuevosDatosPreferencia = new SaveDatosPreferencias();

    private Menu menu;

    // Use this for initialization
    void Start () {
        menu = GameObject.Find("MenuController").GetComponent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void SaveDatosPreferencias()
    {
        DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenGeneral = menu.volumenSlider.value;
        DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenAmbiente = menu.volumenSliderAmbiente.value;
        DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenEfectos = menu.volumenSliderEfectos.value;
        DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.idioma = menu.idioma.value;

    }


    public void SaveDatosDiscoPref()
    {
        // Update local data with current game data
        SaveDatosPreferencias();
       
        // 1) Path check
        if (!Directory.Exists("myGuardadosPref"))
        {
            Directory.CreateDirectory("myGuardadosPref");
        }
        // 2) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();

        // 3) Create file
        FileStream saveFile = File.Create("myGuardadosPref/myGuardadoPref.myBinary");

        // 4) Reference to data being saved
        SaveDatosPreferencias localCopyOfData = DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias;
        // 5) Writing data in binary form
        myFormatter.Serialize(saveFile, localCopyOfData);
        // 6) Close file!!!!! EXTREMELY IMPORTANT
        saveFile.Close();


    }


    public void LoadPreferenciasFromDisk()
    {
        // 0) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();
        // 1) File opening
        FileStream fileToLoad = File.Open("myGuardadosPref/myGuardadoPref.myBinary", FileMode.Open);
        // 2) Deserialize to temporal variable
        SaveDatosPreferencias tempCopyOfData = (SaveDatosPreferencias)myFormatter.Deserialize(fileToLoad); // Lo fuerza a ser de GameStatics y es Serializable
        // 3) Close file!!!!! EXTREMELY IMPORTANT
        fileToLoad.Close();
        // 4) Decide what to do with the loaded data
        DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias = tempCopyOfData;

        LoadDatosPreferencias();
    }

    public void LoadDatosPreferencias()
    {
        menu.volumenSlider.value = DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenGeneral;
        menu.volumenSliderAmbiente.value = DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenAmbiente;
        menu.volumenSliderEfectos.value = DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.volumenEfectos;
        menu.idioma.value = DatosGuardadosPreferencia.pref_GameDataInstance.savedGameDataPreferencias.idioma;
    }
}
