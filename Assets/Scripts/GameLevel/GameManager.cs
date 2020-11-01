using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private Text soruText, birinciSonuctext, ikinciSonucText, ucuncuSoruText;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    string hangiOyun;
    int birinciCarpan;
    int ikinciCarpan;

    int dogruSonuc;
    int birinciYanlisSonuc;
    int ikinciYanlisSonuc;

    public int dogruAdet, yanlisAdet, toplamPuan;


    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;
    PlayerMAnager playerManager;

    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerMAnager>();
    }

    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }
        StartCoroutine(baslaYaziRoutine());
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 0.1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinMi = true;
        SoruYazdir();
        
    }

    void BirinciCarpaniAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;

            case "uc":
                birinciCarpan = 3;
                break;

            case "dort":
                birinciCarpan = 4;
                break;

            case "bes":
                birinciCarpan = 5;
                break;

            case "alti":
                birinciCarpan = 6;
                break;

            case "yedi":
                birinciCarpan = 7;
                break;

            case "sekiz":
                birinciCarpan = 8;
                break;

            case "dokuz":
                birinciCarpan = 9;
                break;

            case "on":
                birinciCarpan = 10;
                break;

            case "karisik":
                birinciCarpan = Random.Range(2, 11);
                break;

        }

    }
        void SoruYazdir()
        {
            BirinciCarpaniAyarla();
            ikinciCarpan = Random.Range(2, 11);

            int rastgeleDeger = Random.Range(1, 100);

            if (rastgeleDeger <= 50)
            {
                soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
            }
            else
            {
                soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
            }

        dogruSonuc = birinciCarpan * ikinciCarpan;
        SonuclariYazdir();

        }

    void SonuclariYazdir()
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 10);
        if (dogruSonuc > 10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 8);
        }else
        {
            ikinciYanlisSonuc =Mathf.Abs(dogruSonuc - Random.Range(2, 5));
        }

        int rasgeleDeger = Random.Range(1, 100);

        if (rasgeleDeger <= 33)
        {
            birinciSonuctext.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSoruText.text = ikinciYanlisSonuc.ToString();
        }
        else if (rasgeleDeger <= 66)
        {
            birinciSonuctext.text = birinciYanlisSonuc.ToString();
            ikinciSonucText.text = dogruSonuc.ToString();
            ucuncuSoruText.text = ikinciYanlisSonuc.ToString();
        }
        else
        {
            birinciSonuctext.text = ikinciYanlisSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSoruText.text = dogruSonuc.ToString();
        }
    }

    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;

            dogruImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);

        }

        dogruAdetText.text = dogruAdet.ToString() + " Dogru" ;
        yanlisAdetText.text = yanlisAdet.ToString() + " Yanlis" ;
        puanText.text = toplamPuan.ToString() + " Puan";

        SoruYazdir();
    }
    
    
    }


