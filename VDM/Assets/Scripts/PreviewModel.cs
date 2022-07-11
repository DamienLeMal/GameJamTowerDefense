using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PreviewModel : MonoBehaviour
{
    public void ChangeModel (GameObject prefab) {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.GetComponent<MeshTable>() != null)
                Destroy(child.gameObject);
        }
        GameObject g = Instantiate(prefab,Vector3.up,Quaternion.identity,transform);
        g.transform.localPosition = Vector3.up;
        ChangeMaterial(canPlace);
    }
    
    public void ChangeMaterial (Material m) {
        for(int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            MeshTable mt = child.GetComponent<MeshTable>();
            if (mt is null) continue;
            foreach (MeshRenderer mr in mt.meshes) {
                mr.material = m;
            }
        }
    }
    public DecalProjector decalProjector;
    public void SetDamageRangeDecal (float size) {
        decalProjector.size = new Vector3(size,size,size) * 2;
    }
    public Material canPlace;
    public Material cannotPlace;
    private bool canPlaceUnit;
    public List<GameObject> objectsInCollider = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Ground") return;
        if (objectsInCollider.Contains(other.gameObject)) return;
        objectsInCollider.Add(other.gameObject);
        ChangeMaterial(cannotPlace);
        UnitPlacer.singleton.canPlaceUnit = false;
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Ground") return;
        if (!objectsInCollider.Contains(other.gameObject)) return;
        objectsInCollider.Remove(other.gameObject);
        if (objectsInCollider.Count == 0) {
            ChangeMaterial(canPlace);
            UnitPlacer.singleton.canPlaceUnit = true;
        }
    }

    private void OnEnable() {
        objectsInCollider.Clear();
    }
}
