using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    private UnitSO selectedUnit;
    public PreviewModel previewObject;
    public static UnitPlacer singleton;
    private void Start() {
        singleton = this;
    }
    public Collider terrain;
    public bool canPlaceUnit;
    private UnitButton selectedUnitButton;
    public GameObject unitPrefab;
    public void SetSelectedUnit (UnitButton b) {
        selectedUnit = b.unit;
        if (b.cost > Player.singleton.dollards) return;
        if (selectedUnit is null) return;
        previewObject.ChangeModel(selectedUnit.prefab);
        previewObject.SetDamageRangeDecal(selectedUnit.shotRange);
        previewObject.gameObject.SetActive(true);
        selectedUnitButton = b;
    }
    public void StopPlacing () {
        selectedUnit = null;
        previewObject.gameObject.SetActive(false);
    }
    public float placementRadius;
    private void Update() {
        if (selectedUnit is null) return;

        //Move preview Object
        RaycastHit hitPoint;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (terrain.Raycast(ray, out hitPoint, Mathf.Infinity)) {
            previewObject.transform.position = hitPoint.point;
        }
        
        //Action on mouse event
        if (Input.GetMouseButtonDown(1)) {
            StopPlacing();
        }
        if (Input.GetMouseButtonUp(0)) {
            if (canPlaceUnit)
                PlaceUnit();
            StopPlacing();
        }
    }

    private void PlaceUnit () {
        GameObject unit = Instantiate(unitPrefab,previewObject.transform.position+Vector3.up*0.5f,Quaternion.identity);
        unit.GetComponent<Unit>().InitUnit(selectedUnit);
        Player.singleton.RemoveDollards(selectedUnitButton.cost);
        selectedUnitButton.UpdatePrice();

    }

}
