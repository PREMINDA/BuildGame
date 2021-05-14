using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildinTypeCreatUI : MonoBehaviour
{
    private Transform btnTemplate;
    private BulidingTypeListSo bulidingTypeList;
    [SerializeField] private List<BuildingTypeso> ignorBuilding;
     
    private void Awake()
    {
       btnTemplate = transform.Find("btnTemplate");
       btnTemplate.gameObject.SetActive(false);
       bulidingTypeList = (Resources.Load<BulidingTypeListSo>("BuildingtypeList"));

        int index = 0;
        foreach (BuildingTypeso buildingType in bulidingTypeList.list) {
            if (ignorBuilding.Contains(buildingType)) continue ;
            Transform btnTransform = Instantiate(btnTemplate, transform);

            btnTransform.gameObject.SetActive(true);

            float offsetAmount = +120f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(()=>{
                BuildingManager.Instance.SetActivebuildintype(buildingType);
            });

            MouseEnterExitEvent mouseEnterExitEvent = btnTransform.GetComponent<MouseEnterExitEvent>();
            mouseEnterExitEvent.OnMouseEnter += (object sender, EventArgs e) =>
             {
                 ToolTipUi.Instance.Show(buildingType.nameString);
             };
            mouseEnterExitEvent.OnMouseExit += (object sender, EventArgs e) =>
            {
                ToolTipUi.Instance.Hide();
            };

            index++;
        }
    }

}
