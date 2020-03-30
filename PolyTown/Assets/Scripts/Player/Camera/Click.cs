using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer = 9;
    int updates = 0;


    // Update is called once per frame
    void Update()
    {
        if (!czyMyszkaJestNadUI())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, clickLayer))
                {
                    if (raycastHit.collider.GetComponent<Field>() == null)
                    {
                        Debug.LogError("Null on getting component type - Field");
                    }
                    else
                        raycastHit.collider.GetComponent<Field>().onClick();
                }
            }
            else
            {
                if (updates > 2 && GameObject.Find("SpawnerBudynkow").GetComponent<Spawner>().isActive)
                {
                    RaycastHit raycastHit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, clickLayer))
                    {
                        raycastHit.collider.GetComponent<Field>().highLight();
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
