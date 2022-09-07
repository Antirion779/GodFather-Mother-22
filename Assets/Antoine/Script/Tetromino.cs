using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [Header("Movement")] 
    [Tooltip("Velocité Initial")] [Range(0, 1)] public float velIni;
    [SerializeField] private Vector3 objectif;
    private int moveAvancement;

    //[SerializeField] [Range(0, 1)] private float velIt;
    //[SerializeField] private float upSpeed;
    public Vector3 dir;
    private bool canMove = true;
    public int ID;

    void Start()
    {
        objectif = transform.position + (dir * 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            Vector3.MoveTowards(transform.position,objectif,Time.deltaTime * velIni);
        else
            GiveObjectif();
    }

    void GiveObjectif()
    {
        objectif += (dir * 0.08f);
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        canMove = true;
        yield return new WaitForSeconds(1.0f);
        moveAvancement++;
        canMove = false;
    }

    void OnCollisionEnter2D(Collision2D Bam)
    {
        Debug.Log(Bam.gameObject.tag);
        if (Bam.gameObject.tag == "Tetromino")
        {
            canMove = false;
            StartCoroutine(Kaboom());
        }
    }

    void OnCollisionExit2D(Collision2D Bam)
    {
        if (Bam.gameObject.tag == "Tetromino")
        {
            canMove = true;
            StopCoroutine(Kaboom());
        }
    }


    IEnumerator Kaboom()
    {
        yield return new WaitForSeconds(SpawnManager.Instance.timeBeforeExplosion);
        //Play Explosion
        SpawnManager.Instance.currentTetro -= 1;
        Destroy(gameObject);
    }
}
