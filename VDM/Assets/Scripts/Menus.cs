using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public void QuitGame () {
        Application.Quit();
    }

    public void ToggleGameobject (GameObject o) {
        o.SetActive(!o.activeSelf);
    }
}
