using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialo : MonoBehaviour
{
    [SerializeField]
    private Text dialoD;
    [SerializeField]
    private Text dialoE;
    [SerializeField]
    private Text dialoF;
    
    void Update()
    {
        SetHealOk(ArmeShop.Healeru);
        SetUltOk(ArmeShop.Ulteru);
        SetGreOk(ArmeShop.Naderu);
    }

    void SetHealOk(int ok)
    {
        dialoD.text = ok.ToString();
    }
    void SetUltOk(int ok)
    {
        dialoE.text = ok.ToString();
    }
    void SetGreOk(int ok)
    {
        dialoF.text = ok.ToString();
    }
}
