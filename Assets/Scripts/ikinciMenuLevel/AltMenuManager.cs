using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AltMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject altMenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClick;
    void Start()
    {
        altMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        altMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f);
    }

   public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        
        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        SceneManager.LoadScene("MenuLevel");
    }
}
