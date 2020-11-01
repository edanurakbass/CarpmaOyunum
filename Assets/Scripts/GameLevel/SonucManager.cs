using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject tekrarOynaButton, anaMenuButton;

    float sureTimer;
    bool resimAcilsinMi;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {

        sureTimer = 0;
        resimAcilsinMi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        tekrarOynaButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuButton.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(ResimAcRoutine());
    }



    IEnumerator ResimAcRoutine()
    {
        while (resimAcilsinMi)
        {
            sureTimer += .15f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinMi = false;

                dogruText.text = gameManager.dogruAdet.ToString() + " DOGRU";
                yanlisText.text = gameManager.yanlisAdet.ToString() + " YANLIS";
                puanText.text = gameManager.toplamPuan.ToString() + " PUAN";

                tekrarOynaButton.GetComponent<RectTransform>().DOScale(1, 0.3f);
                anaMenuButton.GetComponent<RectTransform>().DOScale(1, 0.3f);
            }
        }
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");

    }

}
