using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerController : MonoBehaviour
{
    public GestionDias dia;   //para guardar automaticamente cada vez que se termine un dia

    public SaveDatos datosActuales = new SaveDatos();   //para poder usar los datos que almacenemos en las estadisticas

    public ControladorDatosJuego datosJuego = new ControladorDatosJuego();


    // Use this for initialization
    void Start()
    {
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {

        //for (GestionDias.dia = 0; GestionDias.dia <= 5; GestionDias.dia++) //para que cada vez que transcurra un dia, guarde a disco
        //{
        //revisar la condicion de seguir dentro del bucle
        //  SavePlayerDataToDisk();
        // }

        //Invocar a cargar de disco, tambien las preferencias
        //se invoca desde el script Menu, en PulsarContinuar

    }


    public void SavePlayerDataToDisk()
    {
        //primero guardamos en local
        SavePlayerData();

        // 1) Path check
        if (!Directory.Exists("datosPartidas"))       //DUDA: cuando tu creas este directorio, ¿donde lo crea?
        {
            Directory.CreateDirectory("datosPartidas");
        }
        // 2) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();
        // 3) Create file
        FileStream saveFile = File.Create("datosPartidas/miPartida.myBinary"); //carpeta/archivo/extension

        // 4) Reference to data being saved                                                                   
        ControladorDatosJuego localCopyOfData = DatosGuardados.g_GameDataInstance.saveDataDisk;   //guardas los datos que tienes salvados en ese momento

        // 5) Writing data in binary form
        myFormatter.Serialize(saveFile, localCopyOfData);   //nombre de archivo donde vas a guardar, y copia de los datos que vas a guardar (serializar)
                                                            // 6) Close file!!!!! EXTREMELY IMPORTANT
        saveFile.Close();
    }



    public void LoadPlayerDataFromDisk() //aqui carga del disco
    {
        // 0) Binary formatter
        BinaryFormatter myFormatter = new BinaryFormatter();

        // 1) File opening
        FileStream fileToLoad = File.Open("datosPartida/miPartida.myBinary", FileMode.Open);

        // 2) Deserialize to temporal variable
        ControladorDatosJuego tempCopyOfData = (ControladorDatosJuego)myFormatter.Deserialize(fileToLoad);

        // 3) Close file!!!!! EXTREMELY IMPORTANT
        fileToLoad.Close();

        // 4) Decide what to do with the loaded data
        DatosGuardados.g_GameDataInstance.saveDataDisk = tempCopyOfData;

    }




    void SavePlayerData()
    {
        //DatosGuardados.g_GameDataInstance.savedGameData.salud = datosActuales.salud;
        //DatosGuardados.g_GameDataInstance.savedGameData.energia = datosActuales.energia;
        //DatosGuardados.g_GameDataInstance.savedGameData.usos = datosActuales.usos;
        //DatosGuardados.g_GameDataInstance.savedGameData.tiempo = datosActuales.tiempo;
        DatosGuardados.g_GameDataInstance.savedGameData.myItems = datosActuales.myItems;
        //DatosGuardados.g_GameDataInstance.savedGameData.positionj = datosActuales.positionj;
        //DatosGuardados.g_GameDataInstance.savedGameData.rotacionj = datosActuales.rotacionj;
        //DatosGuardados.g_GameDataInstance.savedGameData.positionz = datosActuales.positionz;
        //DatosGuardados.g_GameDataInstance.savedGameData.rotacionz = datosActuales.rotacionz;
        //DatosGuardados.g_GameDataInstance.savedGameData.positionc = datosActuales.positionc;
        //DatosGuardados.g_GameDataInstance.savedGameData.rotacionc = datosActuales.rotacionc;
        DatosGuardados.g_GameDataInstance.saveDataDisk.objetosActivos = datosJuego.objetosActivos;
        DatosGuardados.g_GameDataInstance.saveDataDisk.zombiesActivos = datosJuego.zombiesActivos;
        DatosGuardados.g_GameDataInstance.saveDataDisk.tiempoSobra = datosJuego.tiempoSobra;
        DatosGuardados.g_GameDataInstance.saveDataDisk.dia = datosJuego.dia;
        DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSlider = datosJuego.volumenSlider;
        DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSliderAmbiente = datosJuego.volumenSliderAmbiente;
        DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSliderEfectos = datosJuego.volumenSliderEfectos;
        DatosGuardados.g_GameDataInstance.saveDataDisk.volumenGeneralMixer = datosJuego.volumenGeneralMixer;

    }




    void LoadPlayerData()
    {
        //datosActuales.salud = DatosGuardados.g_GameDataInstance.savedGameData.salud;
        //datosActuales.energia = DatosGuardados.g_GameDataInstance.savedGameData.energia;
        //datosActuales.usos = DatosGuardados.g_GameDataInstance.savedGameData.usos;
        //datosActuales.tiempo = DatosGuardados.g_GameDataInstance.savedGameData.tiempo;
        datosActuales.myItems = DatosGuardados.g_GameDataInstance.savedGameData.myItems;
        //datosActuales.positionj = DatosGuardados.g_GameDataInstance.savedGameData.positionj;
        //datosActuales.rotacionj = DatosGuardados.g_GameDataInstance.savedGameData.rotacionj;
        //datosActuales.positionz = DatosGuardados.g_GameDataInstance.savedGameData.positionz;
        //datosActuales.rotacionz = DatosGuardados.g_GameDataInstance.savedGameData.rotacionz;
        //datosActuales.positionc = DatosGuardados.g_GameDataInstance.savedGameData.positionc;
        //datosActuales.rotacionc = DatosGuardados.g_GameDataInstance.savedGameData.rotacionc;
        datosJuego.objetosActivos = DatosGuardados.g_GameDataInstance.saveDataDisk.objetosActivos;
        datosJuego.zombiesActivos = DatosGuardados.g_GameDataInstance.saveDataDisk.zombiesActivos;
        datosJuego.tiempoSobra = DatosGuardados.g_GameDataInstance.saveDataDisk.tiempoSobra;
        datosJuego.dia = DatosGuardados.g_GameDataInstance.saveDataDisk.dia;
        datosJuego.volumenSlider = DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSlider;
        datosJuego.volumenSliderAmbiente = DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSliderAmbiente;
        datosJuego.volumenSliderEfectos = DatosGuardados.g_GameDataInstance.saveDataDisk.volumenSliderEfectos;
        datosJuego.volumenGeneralMixer = DatosGuardados.g_GameDataInstance.saveDataDisk.volumenGeneralMixer;


    }


}