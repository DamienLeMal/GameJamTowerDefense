using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBar : MonoBehaviour
{
    public float test;
    public bool updateRotation;
    void Start()
    {
        transform.rotation = Camera.main.transform.rotation * new Quaternion(1,180,1,1);
    }
    private void FixedUpdate() {
        if (updateRotation) transform.rotation = Camera.main.transform.rotation * new Quaternion(1,180,1,1);
    }
    public RectTransform bar;

    public void SetValue (float value) {
        value = (value >= 1) ? 1 : value;
        value = (value <= 0) ? 0 : value;
        bar.sizeDelta = new Vector2(value,0.1f);
    }
}
