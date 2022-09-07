using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [Header("Movement")] 
    [Tooltip("Velocité Initial")] [Range(0, 1)] public float velIni;

    [SerializeField] [Range(0, 1)] private float velIt;
    [SerializeField] private float upSpeed;
    public Vector2 dir;
    private bool canMove = true;

    [Header("Explosion")] 
    [SerializeField] private int timeBeforeExplosion;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            transform.Translate(dir * Time.deltaTime * velIni);
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
        yield return new WaitForSeconds(timeBeforeExplosion);
        //Play Explosion
        SpawnManager.Instance.currentTetro -= 1;
        Destroy(gameObject);
    }
}
