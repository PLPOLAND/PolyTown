using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator{
    

    private List<FieldType> fields;
    public void init(){
        fields = new List<FieldType>();
    }

    public void addField(Fields typ, ref GameObject mesh){
        fields.Add(new FieldType(typ, mesh));
    }

    public void generate(GameObject[,] map, Vector2Int size){

        Vector2 pos = new Vector2(0, 0);
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newobj = MonoBehaviour.Instantiate(fields[1].mesh);
                
                newobj.name = i + " " + j;
                newobj.layer = 9;
                // newobj.AddComponent<MeshCollider>();
                // newobj.AddComponent<ClickOn>();
                // var n = newobj.GetComponent<ClickOn>();
                // n.red = red;
                var t = newobj.transform.position;
                t.x += pos.x;
                t.z += pos.y;
                newobj.transform.position = t;
                pos.y += 4;
            }
            pos.y = 0;
            pos.x += 4;
        }
    }
}

class FieldType{
    public Fields type;
    public GameObject mesh;

    public FieldType(Fields type, GameObject mesh){
        this.type = type;
        this.mesh = mesh;
    }
}
