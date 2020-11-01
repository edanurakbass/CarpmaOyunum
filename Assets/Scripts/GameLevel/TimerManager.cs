using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    int kalanSure;

    bool sureSaysinmi;

    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject sonuclarObje, zamanObje, puanObje, dogruYanlisObje, playerObje;
    void Start()
    {
        kalanSure = 90;
        sureSaysinmi = true;
        sonucPaneli.SetActive(false);

        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        puanObje.SetActive(true);
        dogruYanlisObje.SetActive(true);
        playerObje.SetActive(true);


        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();

            }
            else
            {
                sureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0 )
            {
                sureSaysinmi = false;
                sureText.text = "";

                EkraniTemizle();
                sonucPaneli.SetActive(true);
            }
            kalanSure--;
        }
    }

    void EkraniTemizle()
    {
        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        puanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        playerObje.SetActive(false);
    }
   
}
