using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmeShop : MonoBehaviour
{
    private Player player;
    public Transform arme1Prefab, arme2Prefab, arme3Prefab;
    public Slider sliderMoney;
    
    private int costArme1 = 10;
    private int costArme2 = 20;
    private int costArme3 = 5;
    
    public static int grenaderestante = 3;

    public void SetPlayer(Player player)
    {
        this.player = player;
        sliderMoney.maxValue = player.maxMoney;
    }

    public void Update()
    {
        sliderMoney.value = player.currentMoney;
    }

    public void SelectAchat1()
    {
        buyArme(arme1Prefab, arme1Prefab.name, costArme1);
    }
    
    public void SelectAchat2()
    {
        buyArme(arme2Prefab, arme2Prefab.name, costArme2);
    }
    
    public void SelectAchat3()
    {
        EjectScript.FiveGre();
        buyArme(arme3Prefab, arme3Prefab.name, costArme3);
    }

    private void buyArme(Transform arme, string name, int cost)
    {
        if (player.currentMoney - cost >= 0)
        {
            if (AddArme(arme))
            {
                player.currentMoney -= cost;
                Debug.Log(name + " buy !");
            }
            else
            {
                Debug.Log(name + " already buy !");
            }
        }
        else
        {
            Debug.Log("No money...");
        }
    }

    public bool AddArme(Transform arme)
    {
        int i = 0;
        
        while (i < player.TotalArme.Count && arme != player.TotalArme[i])
        { 
            i++;
        }
        
        if (i == player.TotalArme.Count)
        {
            player.TotalArme.Add(arme);
            //Instantiate(arme, player.transform.GetChild(1).transform.GetChild(0));
            return true;
        }

        return false;
    }
 
}
