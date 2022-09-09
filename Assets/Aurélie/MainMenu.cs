using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int select = 1;

    public GameObject arrow1, arrow2;

    private void Start()
    {
        arrow1.SetActive(true);
        arrow2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            select = 1;
            arrow1.SetActive(true);
            arrow2.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            select = 2;
            arrow2.SetActive(true);
            arrow1.SetActive(false);
        }
        if (select == 1)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
                Debug.Log("truc");
        }
        if (select == 2)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
                SceneManager.LoadScene("Playtest");
        }
    }
}
