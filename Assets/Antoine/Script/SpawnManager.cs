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
    //public List<GameObject> TetroList;

    [Header("Tetro stat")]
    public int timeBeforeExplosion;
    private int[] orientation ={0, 90, 180, 270};
    [Range(0, 2)] public float waitingTime = 2.0f;
    [SerializeField] [Range(0, 2)] private float timeBtwSpawn = 1;
    [SerializeField] [Range(0, 2)] private float speed;
    [SerializeField] private int maxTetro;

    [Header("Modifier")]
    [SerializeField] [Range(0, 30)] private float cdUpgrade;
    [SerializeField] [Range(0, 2)] private float modifierSpawnRate;
    [SerializeField] [Range(0, 2)] private float modifierspeed;
    [SerializeField] [Range(0, 2)] private int modifierMaxTetro;
    [SerializeField] [Range(0, 2)] private float modifierWaitingMovement;
    private bool upgrade = true;

    [Header("Tetro")] 
    //[SerializeField] private int minTetro;
    public int currentTetro = 0;
    //[SerializeField] private int tetroL;
    //[SerializeField] private int tetroR;
    //[SerializeField] private int tetroT;
    //[SerializeField] private int tetroB;
    [SerializeField] GameObject[] shape;
    private bool canSpawn = true;


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
            int _orientation = UnityEngine.Random.Range(0, orientation.Length);

            if (canSpawn)
                //check if you can spawn a tetro
                StartCoroutine(TempoSpawn(_spawner, _shape, _orientation));
        }

        if (upgrade)
            StartCoroutine(Upgrade());
    }

    IEnumerator Upgrade()
    {
        upgrade = false;
        Debug.Log("Before");
        yield return new WaitForSeconds(cdUpgrade);
        Debug.Log("After");
        speed += modifierspeed;
        maxTetro += modifierMaxTetro;

        timeBtwSpawn -= modifierSpawnRate;
        waitingTime -= modifierWaitingMovement;

        upgrade = true;
    }

    IEnumerator TempoSpawn(int _spawner, int _shape, int _orientation)
    {
        if (spawnCells[_spawner].GetComponent<DetectSpawnCells>().canSpawnTetro)
            SpawnTetro(_shape, _spawner, _orientation);

        canSpawn = false;
        yield return new WaitForSeconds(timeBtwSpawn);
        canSpawn = true;
    }

    private void SpawnTetro(int _shape, int _spawner, int _orientation)
    {
        GameObject tetri = Instantiate(shape[_shape], spawnCells[_spawner].transform.position, Quaternion.Euler(spawnCells[_spawner].transform.rotation.x, spawnCells[_spawner].transform.rotation.y, orientation[_orientation]));
        currentTetro++;
        //TetroList.Add(tetri);
        tetri.transform.localScale = new Vector3(2, 2, 1);

        Tetromino tetro = tetri.GetComponentInChildren<Tetromino>();
        tetro.dir = spawnCells[_spawner].GetComponent<DetectSpawnCells>().dir;
        tetro.waitingTime = waitingTime;
        tetro.velIni = speed;

        spawnCells[_spawner].GetComponent<DetectSpawnCells>().canSpawnTetro = false;
    }
}