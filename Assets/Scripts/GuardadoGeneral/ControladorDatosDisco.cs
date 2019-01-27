using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ControladorDatosDisco : MonoBehaviour {


    public SaveDatosGeneral nuevosDatosGeneral = new SaveDatosGeneral();


    private Inventory lista;


    // Use this for initialization
    void Start () {

        lista = GameObject.Find("Inventory").GetComponent<Inventory>();
        nuevosDatosGeneral.diaActual = GestionDias.dia;
        nuevosDatosGeneral.tiempoRestante = Tiempo.tiempoSobra;
        nuevosDatosGeneral.myItems = lista.myInventory;
        nuevosDatosGeneral.respuestaPer = GestionDias.respuesta;
        nuevosDatosGeneral.latasInven = Salida.usosMas;
        nuevosDatosGeneral.cantidadLatas = Salida.cantidad;
        nuevosDatosGeneral.cantidadControl = GestionDias.cantidadControlZ;
    }
	
	// Update is called once per frame
	void Update () {

        nuevosDatosGeneral.diaActual = GestionDias.dia;
        nuevosDatosGeneral.tiempoRestante = Tiempo.tiempoSobra;
        nuevosDatosGeneral.myItems = lista.myInventory;
        nuevosDatosGeneral.respuestaPer = GestionDias.respuesta;
        nuevosDatosGeneral.latasInven = Salida.usosMas;
        nuevosDatosGeneral.cantidadLatas = Salida.cantidad;
        nuevosDatosGeneral.cantidadControl = GestionDias.cantidadControlZ;



    }


    public void SaveDatosGeneral()
    {
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.cantidadLatas = Salida.cantidad;//nuevosDatosGeneral.cantidadLatas;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.diaActual = GestionDias.dia; //nuevosDatosGeneral.diaActual;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.tiempoRestante = Tiempo.tiempoSobra; // nuevosDatosGeneral.tiempoRestante;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.latasInven = Salida.usosMas;//nuevosDatosGeneral.latasInven;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.respuestaPer = GestionDias.respuesta;//nuevosDatosGeneral.respuestaPer;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.myItems = Inventory.inventarioEstatico; // nuevosDatosGeneral.myItems;
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.cantidadControl = GestionDias.cantidadControlZ;


    }


    public void SaveDatosDisco()
    {
        // Update local data with current game data
        SaveDatosGeneral();
        Debug.Log("Guar");
        // 1) Path check
        if (!Directory.Exists("myGuardados"))
        {
            Directory.CreateDirectory("myGuardados");
        }
        // 2) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();

        // 3) Create file
        FileStream saveFile = File.Create("myGuardados/myGuardado.myBinary");

        // 4) Reference to data being saved
        SaveDatosGeneral localCopyOfData = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral;
        // 5) Writing data in binary form
        myFormatter.Serialize(saveFile, localCopyOfData);
        // 6) Close file!!!!! EXTREMELY IMPORTANT
        saveFile.Close();

        
    }


    public void LoadPlayerDataFromDisk()
    {
        // 0) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();
        // 1) File opening
        FileStream fileToLoad = File.Open("myGuardados/myGuardado.myBinary", FileMode.Open);
        // 2) Deserialize to temporal variable
        SaveDatosGeneral tempCopyOfData = (SaveDatosGeneral)myFormatter.Deserialize(fileToLoad); // Lo fuerza a ser de GameStatics y es Serializable
        // 3) Close file!!!!! EXTREMELY IMPORTANT
        fileToLoad.Close();
        // 4) Decide what to do with the loaded data
        DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral = tempCopyOfData;

        LoadDatosGeneral();
    }

    public void LoadDatosGeneral()
    {
        Salida.cantidad = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.cantidadLatas;//nuevosDatosGeneral.cantidadLatas;
        GestionDias.dia=DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.diaActual; //nuevosDatosGeneral.diaActual;
        Tiempo.tiempoSobra = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.tiempoRestante; // nuevosDatosGeneral.tiempoRestante;
        Salida.usosMas = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.latasInven;//nuevosDatosGeneral.latasInven;
        GestionDias.respuesta = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.respuestaPer;//nuevosDatosGeneral.respuestaPer;
        Inventory.inventarioEstatico = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.myItems; // nuevosDatosGeneral.myItems;
        GestionDias.cantidadControlZ = DatosGuardadoGeneral.guar_GameDataInstance.savedGameDataGeneral.cantidadControl;
    }

}
