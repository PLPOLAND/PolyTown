using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer = 9;
    int updates = 0;


    // Update is called once per frame
    void Update()
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
            if (updates > 2)
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
