using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpawnCells : MonoBehaviour
{
    public bool canSpawnTetro = true;
    public Vector2 dir;

    void OnTriggerStay2D(Collider2D bam)
    {
        if (bam.gameObject.tag == "Tetromino")
            canSpawnTetro = false;
    }

    void OnTriggerExit2D(Collider2D bam)
    {
        if (bam.gameObject.tag == "Tetromino")
            canSpawnTetro = true;
    }
}

