using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureInfo : MonoBehaviour
{
    public bool Unlocked = false;
    public int Cost = 0;


    private void OnEnable()
    {
        transform.GetComponent<Button>().onClick.AddListener(OpenThis);
    }

    private void OpenThis()
    {
        GameObject.Find("CustomizeGearUI").GetComponent<MenuController>().openCanvas(this.gameObject);
    }
}
