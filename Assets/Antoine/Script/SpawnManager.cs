using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [Header("Tab")]
    [SerializeField] private GameObject[] spawnCells;

    [Header("Tetro stat")]
    private int[] orientation = new int[]{0,90,180,270};

    [Header("Tetro")]
    [SerializeField] private int minTetro;
    [SerializeField] private int maxTetro;
    public int currentTetro = 0;
    [SerializeField] private int tetroL;
    [SerializeField] private int tetroR;
    [SerializeField] private int tetroT;
    [SerializeField] private int tetroB;
    [SerializeField] GameObject[] shape;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTetro < maxTetro)
        {
            int _shape = UnityEngine.Random.Range(0, shape.Length);
            int _spawner = UnityEngine.Random.Range(0, spawnCells.Length);

            GameObject tetri = Instantiate(shape[_shape]);
        }
    }
}
