using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    private BulidingTypeListSo builidingTypeListSo;
    private BuildingTypeso activeBuilidingType = null;
    private Camera mainCamera;
    public static BuildingManager Instance { get; private set; }
    public bool canspawn = true;
    public bool isClickFree = false;

    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;
    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeso activeBuilidingType;
    }

    private void Awake()
    {
        Instance = this;
        builidingTypeListSo = (Resources.Load<BulidingTypeListSo>("BuildingtypeList"));
        

    }
    private void Start()
    {
        mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBuilidingType != null) {
            
            if (Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject() && canspawn) {
                
                if (ResourceManager.Instance.CanAfford(activeBuilidingType.BuildingResourceCostArray))
                {
                    
                    ResourceManager.Instance.SpendResourse(activeBuilidingType.BuildingResourceCostArray);
                    Instantiate(activeBuilidingType.prefabs, UtilsClass.GetMousePostition(), Quaternion.identity);
                    isClickFree = false;
                }
            }
            canSpawnBuilding(activeBuilidingType, UtilsClass.GetMousePostition());
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                activeBuilidingType = null;
                isClickFree = true;
                OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs
                {
                    activeBuilidingType = activeBuilidingType
                });

            }
        }
    }

    public void SetActivebuildintype(BuildingTypeso buildintype)
    {
        activeBuilidingType = buildintype;
        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs
        {
            activeBuilidingType = activeBuilidingType
        }); 
    }
    private bool canSpawnBuilding(BuildingTypeso buildingTypeso,Vector3 pos)
    {
            BoxCollider2D boxCollider2D = buildingTypeso.prefabs.GetComponent<BoxCollider2D>();
            Collider2D[] collider2DArray= Physics2D.OverlapBoxAll(pos + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);
            if(collider2DArray.Length == 0)
            {
                canspawn = true;
            }
            else
            {
                canspawn = false;
            }

            return canspawn;
    }
}
