using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public bool shopEnter = true;
    public GameObject shopMenuUI, shopButtonUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (shopEnter)
                ShopEnter();
            
            else
                ShopQuit();
        }
    }

    public void ShopEnter()
    {
        shopMenuUI.SetActive(shopEnter);
        shopButtonUI.SetActive(!shopEnter);
        Time.timeScale = 0f;
        shopEnter = !shopEnter;
    }

    public void ShopQuit()
    {
        shopMenuUI.SetActive(shopEnter);
        shopButtonUI.SetActive(!shopEnter);
        Time.timeScale = 1f;
        shopEnter = !shopEnter;
    }
}