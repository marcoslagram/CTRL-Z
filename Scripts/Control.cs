using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public GameObject player;
    public GameObject zombie;
    public GameObject camara;

    private GameObject[] enemigos;

    private float tiempo;
    private Vector3 posicionj;
    private Quaternion rotacionj;

    private Vector3 posicionc;
    private Quaternion rotacionc;

    private Vector3[] posicionz;
    private Quaternion[] rotacionz;
    private List<Items> myItems;

    // Collider enemigo;
    int a = 0;
    Tiempo tiempoDia;
    private DatosGuardados datos;

    private bool dentro=false;

    public SaveDatos nuevosDatos = new SaveDatos();
    Caza saludd;

    Inventory lista;

    Economia economia;

    private DialogoNPC dialogo;

    // Use this for initialization
    void Start () {
        tiempo = 0f;
        saludd=GameObject.Find("Enemigo").GetComponent<Caza>();
        economia = GameObject.Find("Enemigo").GetComponent<Economia>();
        lista = GameObject.Find("Inventory").GetComponent<Inventory>();
        dialogo = GameObject.Find("Gato").GetComponent<DialogoNPC>();
        datos = GameObject.Find("Player").GetComponent<DatosGuardados>();
        enemigos = GameObject.FindGameObjectsWithTag("Zombie");
        nuevosDatos.positionz = new Vector3[enemigos.Length];
        nuevosDatos.rotacionz = new Quaternion[enemigos.Length];
        posicionz = new Vector3[enemigos.Length];
        rotacionz =  new Quaternion[enemigos.Length];
        posicionj = player.transform.position;
        rotacionj = player.transform.rotation;
        posicionc = camara.transform.position;
        rotacionc = camara.transform.rotation;
        for (int i = 0; i < enemigos.Length; i++)
        {
            posicionz[i] = enemigos[i].transform.position;
            rotacionz[i] = enemigos[i].transform.rotation;
        }
        /*  posicionz = zombie.transform.position;
          rotacionz = zombie.transform.rotation;*/
        nuevosDatos.objetosActivos = GameObject.FindGameObjectsWithTag("Objectos");
        nuevosDatos.zombiesActivos = GameObject.FindGameObjectsWithTag("Zombie");

        tiempoDia = GameObject.Find("Player").GetComponent<Tiempo>();
        //  enemigo = GameObject.Find("Enemigo").GetComponent<Collider>();

         nuevosDatos.myItems = lista.myInventory;
        //  LoadDatasControl();
        /*   SaveDatos datos = new SaveDatos()
           {
               salud = 100,
               energia = 100,
               usos = 4,
               myItems = new System.Collections.Generic.List<Items>(),
               positionj = player.transform.position,
               rotacionj = player.transform.rotation,
               positionz = zombie.transform.position,
               rotacionz = zombie.transform.rotation

           };*/
        nuevosDatos.positionj = posicionj;
        nuevosDatos.rotacionj = rotacionj;
        nuevosDatos.positionc = posicionc;
        nuevosDatos.rotacionc = rotacionc;
        for (int i = 0; i < enemigos.Length; i++)
        {
            nuevosDatos.positionz[i] = posicionz[i];
            nuevosDatos.rotacionz[i] = rotacionz[i];
        }

    }
	
	// Update is called once per frame
	void Update () {
        tiempo = tiempo + 1 * Time.deltaTime;
        posicionj = player.transform.position;
        rotacionj = player.transform.rotation;
        posicionc = camara.transform.position;
        rotacionc = camara.transform.rotation;
        for (int i = 0; i < enemigos.Length; i++)
        {
            posicionz[i] = enemigos[i].transform.position;
            rotacionz[i] = enemigos[i].transform.rotation;
        }

        nuevosDatos.objetosActivos = GameObject.FindGameObjectsWithTag("Objectos");
        nuevosDatos.zombiesActivos = GameObject.FindGameObjectsWithTag("Zombie");


        Debug.Log(lista.myInventory.Count);
        /* // posicionz = zombie.transform.position;
         // rotacionz = player.transform.rotation;
         //  Debug.Log(saludd.dentro);
         // Debug.Log(tiempo);
         nuevosDatos.positionj = posicionj;
         nuevosDatos.rotacionj = rotacionj;
         for (int i = 0; i < enemigos.Length; i++)
         {
             nuevosDatos.positionz[i] = posicionz[i] ;
             nuevosDatos.rotacionz[i] = rotacionz[i];
         }
         // nuevosDatos.positionz = posicionz;
        //  nuevosDatos.rotacionz = rotacionz;*/

       // Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.myItems.Count);
        //nuevosDatos.myItems = lista.myInventory;
     //    Debug.Log(saludd.SaberSalud(.salud));
        nuevosDatos.salud = economia.salud;
       
        nuevosDatos.energia = lista.energia;
        nuevosDatos.usos = lista.usosControl;
      //  nuevosDatos.sigue = dialogo.sigueJuego;
        //Debug.Log(nuevosDatos.usos);

        nuevosDatos.tiempo = tiempoDia.tiempo;

        /*   if (lista.myInventory.Count > 1)
           {
     Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.myItems[1].itemName+ "guardado");
           }*/
        /* if (enemigo.on)
         {
             Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");saludd.dentro || tiempo>=30f
         }*/


        for (int i = 0; i < enemigos.Length; i++) { 
            float distancia = Vector3.Distance(enemigos[i].transform.position, GameObject.Find("Cube").transform.position);
       // Debug.Log(distancia);
        if(distancia>=10.7f && distancia <= 11.5f)
            {
                dentro = true;
            }
       else   if(distancia >= 0f && distancia <= 10.7f)
            {
                Debug.Log("11111");
                dentro = false;
            }

           

            
        }
      
//Debug.Log(dentro);
        if (saludd.entrado)
        {
            tiempo = 0;
        }
        

        if (dentro || tiempo>=30f || Input.GetKeyDown(KeyCode.Z)) 
        {
            Debug.Log("Aqui");
          dentro = false;
            SaveDatasControl();
            tiempo = 0;
           /* if (saludd.dentro)
            {
                tiempo = 0;
            }*/
        }
        //Debug.Log(lista.usosControl > 0);
 //&& lista.usosControl>0
        if (Input.GetKeyDown(KeyCode.LeftControl)  && lista.usosControl > 0 )//&& Input.GetKeyDown(KeyCode.Z)
        {
            lista.usosControl--;
            tiempo = 0;
            if (lista.usosControl <= 0)
            {
                lista.usosControl = 0;
            }
            LoadDatasControl();
        }

    }


    public void SaveDatasControl()
    { for (int i = 0; i < DatosGuardados.g_GameDataInstance.savedGameData.myItems.Count; i++)
        {
          
            DatosGuardados.g_GameDataInstance.savedGameData.myItems.RemoveAt(0);
        }
        //  if (a == 1) { 

        /* posicionz = zombie.transform.position;
         rotacionz = player.transform.rotation;*/
        //  Debug.Log(saludd.dentro);
        // Debug.Log(tiempo);
        enemigos = GameObject.FindGameObjectsWithTag("Zombie");
        nuevosDatos.positionj = posicionj;
        nuevosDatos.rotacionj = rotacionj;
        nuevosDatos.positionc = posicionc;
        nuevosDatos.rotacionc = rotacionc;
        for (int i = 0; i < enemigos.Length; i++)
        {
            nuevosDatos.positionz[i] = posicionz[i];
            nuevosDatos.rotacionz[i] = rotacionz[i];
        }
      //  if (a == 1) {
       
        //nuevosDatos.myItems = lista.myInventory;
        //    a = 2;}
        
        
        /* nuevosDatos.positionz = posicionz;
         nuevosDatos.rotacionz = rotacionz;*/
        DatosGuardados.g_GameDataInstance.savedGameData.myItems = new List<Items>();


        DatosGuardados.g_GameDataInstance.savedGameData.salud = nuevosDatos.salud;
        DatosGuardados.g_GameDataInstance.savedGameData.energia = nuevosDatos.energia;
        //DatosGuardados.g_GameDataInstance.savedGameData.usos = nuevosDatos.usos;
        DatosGuardados.g_GameDataInstance.savedGameData.tiempo = nuevosDatos.tiempo;
       // DatosGuardados.g_GameDataInstance.savedGameData.sigue = nuevosDatos.sigue;
      //  DatosGuardados.g_GameDataInstance.savedGameData.myItems = nuevosDatos.myItems;
        DatosGuardados.g_GameDataInstance.savedGameData.objetosActivos = nuevosDatos.objetosActivos;
        DatosGuardados.g_GameDataInstance.savedGameData.zombiesActivos = nuevosDatos.zombiesActivos;
        DatosGuardados.g_GameDataInstance.savedGameData.positionj = nuevosDatos.positionj;
        DatosGuardados.g_GameDataInstance.savedGameData.rotacionj = nuevosDatos.rotacionj;
        DatosGuardados.g_GameDataInstance.savedGameData.positionc = nuevosDatos.positionc;
        DatosGuardados.g_GameDataInstance.savedGameData.rotacionc = nuevosDatos.rotacionc;
        DatosGuardados.g_GameDataInstance.savedGameData.positionz = nuevosDatos.positionz;
        DatosGuardados.g_GameDataInstance.savedGameData.rotacionz = nuevosDatos.rotacionz;


       


        for (int i = 0; i < nuevosDatos.myItems.Count; i++)
        {
            DatosGuardados.g_GameDataInstance.savedGameData.myItems.Add(nuevosDatos.myItems[i]);
        }
        
           // a = 2;}

        //  Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.myItems[1].itemName + "guardado");
        /*   if (lista.myInventory.Count > 1)
           {
               Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.myItems[1].itemName + "guardado");
           }*/
        // Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.positionj);
        //  Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.salud+"      1");
        // Debug.Log(nuevosDatos + "      2");

    }

    public void LoadDatasControl()
    {
        if (!player.activeInHierarchy)
        {
            player.SetActive(true);
        }
    //    Debug.Log(nuevosDatos.myItems.Count + "   b");
       for (int i = 0; i < nuevosDatos.myItems.Count; i++)
        {
           
            nuevosDatos.myItems.RemoveAt(0);
           
        }
     

        for(int i=0;i< DatosGuardados.g_GameDataInstance.savedGameData.objetosActivos.Length; i++)
        {
            DatosGuardados.g_GameDataInstance.savedGameData.objetosActivos[i].SetActive(true);
        }

        for (int i = 0; i < DatosGuardados.g_GameDataInstance.savedGameData.zombiesActivos.Length; i++)
        {
            DatosGuardados.g_GameDataInstance.savedGameData.zombiesActivos[i].SetActive(true);
        }

        


            economia.salud=DatosGuardados.g_GameDataInstance.savedGameData.salud;
        saludd.SaberSalud(economia.salud);
        lista.energia = DatosGuardados.g_GameDataInstance.savedGameData.energia;
        lista.SaberEnergia(lista.energia);
       // lista.usosControl = DatosGuardados.g_GameDataInstance.savedGameData.usos;
       // Debug.Log(lista.usosControl);
       /* lista.SaberUsos(lista.usosControl);*/
        tiempoDia.tiempo = DatosGuardados.g_GameDataInstance.savedGameData.tiempo;
        tiempoDia.SaberTiempo(tiempoDia.tiempo);
      //  nuevosDatos.sigue = DatosGuardados.g_GameDataInstance.savedGameData.sigue;
        nuevosDatos.objetosActivos= DatosGuardados.g_GameDataInstance.savedGameData.objetosActivos ;
        nuevosDatos.zombiesActivos = DatosGuardados.g_GameDataInstance.savedGameData.zombiesActivos;
        nuevosDatos.positionj =   DatosGuardados.g_GameDataInstance.savedGameData.positionj;
        nuevosDatos.rotacionj = DatosGuardados.g_GameDataInstance.savedGameData.rotacionj;
        nuevosDatos.positionc = DatosGuardados.g_GameDataInstance.savedGameData.positionc;
        nuevosDatos.rotacionc = DatosGuardados.g_GameDataInstance.savedGameData.rotacionc;
        nuevosDatos.positionz = DatosGuardados.g_GameDataInstance.savedGameData.positionz;
        nuevosDatos.rotacionz = DatosGuardados.g_GameDataInstance.savedGameData.rotacionz;

      


        for (int i = 0; i < DatosGuardados.g_GameDataInstance.savedGameData.myItems.Count; i++)
        {
            nuevosDatos.myItems.Add(DatosGuardados.g_GameDataInstance.savedGameData.myItems[i]);
        }
        
       // nuevosDatos.myItems = DatosGuardados.g_GameDataInstance.savedGameData.myItems;

        //lista.SaberItems(lista.myInventory);
        //Debug.Log(DatosGuardados.g_GameDataInstance.savedGameData.positionj);

        player.transform.position=nuevosDatos.positionj;
        player.transform.rotation = nuevosDatos.rotacionj;
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].transform.position = nuevosDatos.positionz[i];
            enemigos[i].transform.rotation = nuevosDatos.rotacionz[i];
        }

       
        /*zombie.transform.position = nuevosDatos.positionz;
        zombie.transform.rotation = nuevosDatos.rotacionz;*/
    }



}
