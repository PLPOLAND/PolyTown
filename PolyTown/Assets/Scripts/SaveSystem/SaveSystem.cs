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
    private void Start() {
        saveDirPath = Application.persistentDataPath + " / saves";
    }
    public void save(string saveName){
        BinaryFormatter formatter = getBinaryFormater();
        
        if (Directory.Exists(saveDirPath))
        {
            Directory.CreateDirectory(saveDirPath);
        }
        string savePath = saveDirPath + saveName + ".save"; //ścieżka zapisu
        Debug.Log(savePath);
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

        load(saveName);
    }

    public void load(string saveName){
        BinaryFormatter formatter = getBinaryFormater();

        if (Directory.Exists(saveDirPath))
        {
            Directory.CreateDirectory(saveDirPath);
        }
        string savePath = saveDirPath + saveName + ".save"; //ścieżka zapisu
        Debug.Log(savePath);
        FileStream saveFile = File.Open(savePath,FileMode.Open);
        int data = (int)formatter.Deserialize(saveFile);
        Debug.Log(data);
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
