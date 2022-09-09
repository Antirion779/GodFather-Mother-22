using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{

    private bool fall = true;

    public float vitesse;

    public GameObject logo2, sonLogo, laCamera, gameboy1, gameboy2;
    public Camera laCameraMain;

    private bool timer = false;
    private bool reset = false;
    private float compteur = 2;

    void Update()
    {
        compteur -= Time.deltaTime;

        if (fall)
        {
            transform.Translate(0, -vitesse, 0);
            logo2.transform.Translate(0, -vitesse, 0);
        }

        if (transform.position.y <= 2.35)
        {
            fall = false;
            sonLogo.SetActive(true);
            timer = true;
        }

        if (timer && reset == false)
        {
            compteur = 2;
            reset = true;
        }

        if (compteur <= 0 && reset == true)
        {
            SceneManager.LoadScene("Main menu");
        }
            
    }


}
