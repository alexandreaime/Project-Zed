using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private bool shopEnter = true;
    public GameObject shopButtonUI;

    public void ShopEnterQuit()
    {
        gameObject.SetActive(shopEnter);
        shopButtonUI.SetActive(!shopEnter);
        shopEnter = !shopEnter;
    }
}