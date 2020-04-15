using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * <summary>
 * Odpowiada za kliknięna myszą nad planszą
 * </summary>
 */
public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer = 9;
    int updates = 0; // optymalizacja do raycast

    Player player; //klasa gracza
    Spawner spawner; //spawner budunków
    SzczegolyBudynku szczegolyBudynku; //UI szczegółów budynku

    private void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawner = GameObject.Find("SpawnerBudynkow").GetComponent<Spawner>();
        szczegolyBudynku = GameObject.Find("Szczegoly Budynku").GetComponent<SzczegolyBudynku>();
    }
    void Update()
    {
        if (!czyMyszkaJestNadUI() && !player.pause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, clickLayer))
                {
                    Debug.Log(raycastHit.collider.gameObject.name);
                    if (raycastHit.collider.GetComponent<Field>() == null)
                    {
                        Debug.LogError("Kliknięto na nie obsługiwany obiekt!");
                    }
                    else if(raycastHit.collider.GetComponent<Field>() != null){
                        spawner.onClick(raycastHit.collider.GetComponent<Field>().pos);
                        Debug.Log("Field");
                    }
                }
            }
            else
            {
                if (updates > 2 && spawner.isSpawn)
                {
                    RaycastHit raycastHit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, clickLayer))
                    {
                        spawner.setActiveField(raycastHit.collider.GetComponent<Field>());
                    }
                    updates = 0;
                }
                else
                {
                    updates++;
                }
            }    
        }
    }
    /**
     * <summary>
     * Sprawdza czy myszka znajduje się nad UI
     * </summary>
     * <returns>bool</returns>
     */
    public bool czyMyszkaJestNadUI(){
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData,results);
        if(results.Count > 0)
            return true;
        else
            return false;
    }

}
