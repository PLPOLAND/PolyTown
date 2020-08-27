using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static string saveDirPath = null;//ścieżka folderu z zapisami
    [SerializeField]
    public Save saveData = new Save();//dane do zapisu

    public bool shouldLoad = false; //czy dane powinny być załadowane
    // public Console konsola;
    private void Start() {
        saveDirPath = Application.dataPath + "/saves";
        if (GameObject.Find("SaveMenager")!=null && GameObject.Find("SaveMenager").GetComponent<SaveSystem>() != this)
        {
            Destroy(this);
        }
        else{
            DontDestroyOnLoad(this);
        }
        // konsola = GameObject.Find("Console").GetComponent<Console>();
        // konsola.add(saveDirPath + "/");
    }
    public void save(string saveName){
        // if (konsola == null)
        // {
            // konsola = GameObject.Find("Console").GetComponent<Console>();
        // }

        BinaryFormatter formatter = getBinaryFormater();
        
        if (!Directory.Exists(saveDirPath))
        {
            Directory.CreateDirectory(saveDirPath);
        }
        string savePath = saveDirPath + "/" + saveName + ".save"; //ścieżka zapisu
        Debug.Log(savePath);
        // konsola.add("Ścieżka zapisu: "+savePath);
        FileStream saveFile = File.Create(savePath);

        //pobranie danych gracza
        var tmp = new Player.PlayerToSave();
        tmp.fromPlayer(GameObject.Find("Player").GetComponent<Player>());
        this.saveData.player = tmp;
        //pobranie danych budynków        
        this.saveData.budynki = GameObject.Find("SpawnerBudynkow").GetComponent<Spawner>().budynki;
        
        //zapis
        formatter.Serialize(saveFile, saveData.seed);
        formatter.Serialize(saveFile, saveData.player);
        formatter.Serialize(saveFile, saveData.budynki);
        saveFile.Close();

        // konsola.add("Zapis zakończony pomyślnie");
    }

    public void load(string saveName){
        // if (konsola == null)
        {
            // konsola = GameObject.Find("Console").GetComponent<Console>();
        }
        shouldLoad = false;
        Debug.Log("LOAD");

        // konsola.add("Rozpoczęto wczytywanie");
        BinaryFormatter formatter = getBinaryFormater();

        if (!Directory.Exists(saveDirPath))
        {
            Directory.CreateDirectory(saveDirPath);
        }
        string savePath = saveDirPath + "/" + saveName + ".save"; //ścieżka zapisu
        // konsola.add("Ścieżka do wczytania: " + savePath);
        Debug.Log(savePath);
        FileStream saveFile = File.Open(savePath,FileMode.Open);

        //wczytanie danych
        int seed = (int)formatter.Deserialize(saveFile);
        Player.PlayerToSave player = (Player.PlayerToSave)formatter.Deserialize(saveFile);
        Dictionary<string, Budynek.BudynekToSave> budynki = (Dictionary<string, Budynek.BudynekToSave>)formatter.Deserialize(saveFile);
        
        Debug.Log("Wczytano dane");

        var map = GameObject.Find("Map").GetComponent<Map>();
        map.generateAgain(seed,map.rozmiar.x, map.rozmiar.y);//wygenerowanie mapy o tym samym seedzie co w zapisie aby wglądała tak samo
        Debug.Log("Wczytano mapę");
        // konsola.add("Wczytano mapę");
        GameObject.Find("Player").GetComponent<Player>().load(player.toPlayer(GameObject.Find("Player").GetComponent<Player>()));//wczytanie damych gracza
        Debug.Log("Wczytano dane Gracza");

        // konsola.add("Wczytano dane Gracza");
        GameObject.Find("SpawnerBudynkow").GetComponent<Spawner>().load(budynki);
        Debug.Log("Postawiono Budynki");
        // konsola.add("Postawiono Budynki");
        saveFile.Close();
    }

    public void tryToLoad(){
        if (shouldLoad == true)
        {
            load("save");
        }
    }
    public bool issaveFileExist(string saveName){
        if (!Directory.Exists(saveDirPath))
        {
            Directory.CreateDirectory(saveDirPath);
        }
        string savePath = saveDirPath + "/" + saveName + ".save";

        return File.Exists(savePath);
    }

    public BinaryFormatter getBinaryFormater(){
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
    [System.Serializable]
    public class Save
    {
        public int seed;//seed mapy potrzebny do jej odtworzenia
        public Dictionary<string, Budynek.BudynekToSave> budynki;//dane budynków 
        public Player.PlayerToSave player;//dane gracza
    }

}
