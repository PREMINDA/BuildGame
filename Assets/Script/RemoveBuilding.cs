using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemoveBuilding : MonoBehaviour
{
    [SerializeField]private Button removeButton;
    private Sprite outline;
    void Start()
    {
        Debug.Log(this.gameObject.GetComponent<Sprite>()) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && BuildingManager.Instance.isClickFree)
        {
            

            RaycastHit2D hit = Physics2D.Raycast(UtilsClass.GetMousePostition(), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    Destroy(this.gameObject);
                }
               
            }
        }

    }


}