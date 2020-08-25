using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    
    public Map mapa = null; // pointer na mapę
    public static string saveDirPath = null;//ścieżka folderu z zapisami
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

        FileStream saveFile = File.Create(savePath);
        for (int i = 0; i < mapa.mapa.GetUpperBound(0); i++)
        {
            for (int j = 0; j < mapa.mapa.GetUpperBound(1); j++)
            {
                formatter.Serialize(saveFile, mapa.mapa[i,j]);
            }
        }
    }
    public BinaryFormatter getBinaryFormater(){
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }

    public class Save
    {
        public int seed;
        public Budynek.BudynekToSave s;//TODO
    }

}
