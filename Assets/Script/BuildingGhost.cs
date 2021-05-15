using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    private GameObject spriteGameObject;
    

    private void Awake()
    {
        spriteGameObject = transform.Find("Sprite").gameObject;
        Hide();
    }

    private void Start()
    {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildinManager_OnActiveBuildingTypeChanged;
    }

    private void BuildinManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
    {
        if(e.activeBuilidingType == null)
        {
            Hide();
        }
        else
        {
            Show(e.activeBuilidingType.sprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsClass.GetMousePostition();
        if (BuildingManager.Instance.canspawn == false)
        {
            spriteGameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0,0.5f);
            ToolTipUi.Instance.Show("Need More Space");
        }
        else
        {
            spriteGameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0.5f);
            ToolTipUi.Instance.Hide();
        }
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
        


    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }
}
