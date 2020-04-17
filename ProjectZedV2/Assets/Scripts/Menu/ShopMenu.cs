using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public bool shopEnter = true;
    public GameObject shopButtonUI;

    public void ShopCome()
    {
        gameObject.SetActive(shopEnter);
        shopButtonUI.SetActive(!shopEnter);
        shopEnter = !shopEnter;
    }
}