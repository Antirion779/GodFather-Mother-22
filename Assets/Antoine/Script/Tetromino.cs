using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [Header("Movement")] 
    [Tooltip("Velocité Initial")] [Range(0, 1)] public float velIni;
    public float waitingTime;
    [SerializeField] private Vector3 objectif;

    //[SerializeField] [Range(0, 1)] private float velIt;
    //[SerializeField] private float upSpeed;
    public Vector3 dir;
    [SerializeField] private bool canMove = false;
    [SerializeField] private bool hasToStop = false;
    public int ID;

    void Start()
    {
        objectif = transform.position + (dir * 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && !hasToStop)
            transform.position = Vector3.MoveTowards(transform.position,objectif, velIni * Time.deltaTime);
        else
            GiveObjectif();

    }

    void GiveObjectif()
    {
        objectif += (dir * 0.16f);
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        canMove = true;
        yield return new WaitForSeconds(waitingTime);
        canMove = false;
    }

    void OnCollisionEnter2D(Collision2D Bam)
    {
        Debug.Log(Bam.gameObject.name + Bam.GetContact(0).point);
        if (Bam.gameObject.tag == "Tetromino")
        {
            hasToStop = true;
            StartCoroutine(Kaboom());
        }
        else if (Bam.gameObject.tag == "DeadZone")
        {
            SpawnManager.Instance.currentTetro -= 1;
            Destroy(gameObject);
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
