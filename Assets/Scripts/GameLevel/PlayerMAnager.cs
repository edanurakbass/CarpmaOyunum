using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMAnager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    float angle;
    float donusHizi = 5f;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topClick;


    float ikiMermiArasiSure = 300f;

    float sonrakiAtisSuresi;

    public bool rotaDegissinMi;

    private void Start()
    {
        rotaDegissinMi = false;
    }



    void Update()
    {
        if (rotaDegissinMi)
        {
            RotateDegistir();
        }
       
    }
    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (angle < 45 && angle > -45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }

        

        if (Input.GetMouseButtonDown(0))
        {
           
            if (Time.time > sonrakiAtisSuresi)
            {
                sonrakiAtisSuresi = Time.deltaTime + ikiMermiArasiSure / 100;
                MermiAt();
            }
        }


       
    }
    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }

        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)], mermiYeri.position,mermiYeri.rotation) as GameObject;
    } 
}
