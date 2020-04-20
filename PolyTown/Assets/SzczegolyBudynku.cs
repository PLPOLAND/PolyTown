using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SzczegolyBudynku : MonoBehaviour
{
    [SerializeField]
    SzczegolyBudynkuPack[] rodzaje = null;
    [SerializeField]
    TextMeshProUGUI nazwa_link = null;
    [SerializeField]
    Image ikona = null;
    Zasoby magazynWewnetrzny = null;
    Zasoby magazynUsera = null;
    [SerializeField]
    TextMeshProUGUI[] wartosciPol_link = null;
    void Start()
    {
        magazynUsera = GameObject.Find("Player").GetComponent<Player>().zasoby;
    }

    void Update()
    {
        if(magazynWewnetrzny != null){
            wartosciPol_link[0].text = ((int)magazynWewnetrzny.getJagody()).ToString() + " / " + magazynWewnetrzny.getPojemnosc();
            wartosciPol_link[1].text = ((int)magazynWewnetrzny.getWoda()).ToString() + " / " + magazynWewnetrzny.getPojemnosc();
            wartosciPol_link[2].text = ((int)magazynWewnetrzny.getDrewno()).ToString() + " / " + magazynWewnetrzny.getPojemnosc();
        }
        else
        {
            wartosciPol_link[0].text = "0 / " + magazynWewnetrzny.getPojemnosc();
            wartosciPol_link[1].text = "0 / " + magazynWewnetrzny.getPojemnosc();
            wartosciPol_link[2].text = "0 / " + magazynWewnetrzny.getPojemnosc();
        }
    }

    void setToShow(SzczegolyBudynkuPack szczegoly, Zasoby magazynwew){
        nazwa_link.text = szczegoly.nazwa;
        ikona.sprite = szczegoly.ikona;
        magazynWewnetrzny = magazynwew;
    }

    public void onClick(GameObject obj){
        var budynek = obj.GetComponent<Budynek>();
        switch (budynek.typ)
        {
            case BudynekType.DOM:
                setToShow(rodzaje[0],budynek.magazynWewnetrzny);
                break;
            case BudynekType.DRWAL:
                setToShow(rodzaje[1],budynek.magazynWewnetrzny);
                break;
            case BudynekType.ZBIERACZEJAGOD:
                setToShow(rodzaje[2],budynek.magazynWewnetrzny);
                break;
            case BudynekType.STUDNIA:
                setToShow(rodzaje[3],budynek.magazynWewnetrzny);
                break;
            case BudynekType.CENTRUM:
                setToShow(rodzaje[4],budynek.magazynWewnetrzny);
                break;
            case BudynekType.MAGAZYN:
                setToShow(rodzaje[5],budynek.magazynWewnetrzny);
                break;
        }
    }

}

[System.Serializable]
public class SzczegolyBudynkuPack {
    [SerializeField]
    public BudynekType typ = BudynekType.NONE;
    [SerializeField]
    public string nazwa = null;
    [SerializeField]
    public Sprite ikona = null;
}
