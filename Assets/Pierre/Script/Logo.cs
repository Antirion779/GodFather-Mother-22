using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{

    private bool fall = true;

    public float vitesse;

    public GameObject sonLogo;

    private bool timer = false;
    private bool reset = false;
    private float compteur = 2;

    void Update()
    {
        compteur -= Time.deltaTime;

        if (fall)
            transform.Translate(0, -vitesse, 0);

        if (transform.position.y <= 72)
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
            SceneManager.LoadScene("Menu");
        }
            
    }


}
