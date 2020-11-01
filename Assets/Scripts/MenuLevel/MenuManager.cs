using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClick;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikMi;
    void Start()
    {
        sesPaneliAcikMi = false;

        sesPaneli.GetComponent<RectTransform>().localScale = new Vector3(0, -38, 0);

        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.Unset);
    }

    public void IkinciLeveleGec()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        
        SceneManager.LoadScene("ikinciMenuLevel");
    }
    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        if (!sesPaneliAcikMi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(230, 0.5f);
            sesPaneliAcikMi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
            sesPaneliAcikMi = false;
        }
    }
    public void OyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        Application.Quit();
    }
   
}
