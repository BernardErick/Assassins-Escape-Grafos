using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    private int[,] graph
<<<<<<< HEAD
           = new int[,] {
=======
            = new int[,] {
>>>>>>> 7e682520b3b3c1ae560250a14605e43596f28aec
                            { 0,2,0,0,0,0,0,0,0,0,0,0,0,0 },
                            { 2,0,8,0,3,0,0,0,0,0,0,0,0,0 },
                            { 0,8,0,0,0,0,3,0,0,0,0,0,0,0 },
                            { 0,0,0,0,1,0,0,0,0,0,0,0,0,0 },
                            { 0,0,0,1,0,4,0,6,0,0,0,0,0,0 },
                            { 0,0,0,0,4,0,4,0,6,0,0,0,0,0 },
                            { 0,0,3,0,0,4,0,0,0,0,0,4,0,5 },
                            { 0,0,0,0,6,0,0,0,4,0,0,0,0,0 },
                            { 0,0,0,0,0,6,0,4,0,1,0,0,0,0 },
                            { 0,0,0,0,0,6,0,0,0,1,0,0,0,0 },
                            { 0,0,0,0,0,0,0,0,0,4,0,3,0,0 },
                            { 0,0,0,0,0,0,4,0,0,0,3,0,5,0 },
                            { 0,0,0,0,0,0,0,0,0,0,0,5,0,4 },
                            { 0,0,0,0,0,0,5,0,0,0,0,0,4,0 },
                            };
<<<<<<< HEAD
                       };
    private Vector3[] unityGraphPosition
=======
                        };
    private Vector3[] unityGraphPosition 
>>>>>>> 7e682520b3b3c1ae560250a14605e43596f28aec
        = { new Vector3(-175.525f,-637.58f,-91.562f), //A
            new Vector3(-179.74f,-637.58f,-91.562f), //B
            new Vector3(-195.61f,-637.58f,-91.562f), //C
            new Vector3(-177.56f,-637.58f,-85.53f), //D
            new Vector3(-179.68f,-637.58f,-85.53f), //E
            new Vector3(-187.57f,-637.58f,-85.53f), //F
            new Vector3(-195.64f,-637.58f,-85.53f), //G
            new Vector3(-179.64f,-637.58f,-73.56f), //H
            new Vector3(-187.58f,-637.58f,-73.56f), //I
            new Vector3(-187.58f,-637.58f,-71.56f), //J
            new Vector3(-195.6f,-637.58f,-71.56f), //K
            new Vector3(-195.56f,-638.14f,-77.62f), //L
            new Vector3(-205.47f,-638.14f,-77.62f), //M
            new Vector3(-205.47f,-638.14f,-85.52f), //N
        };

    public int playerLocation;
    public GameObject player;
    public int murderLocation;
    public bool stoped;

    private bool playerCaptured;
    private Vector3 pathToGo;
    public Rigidbody rb;

    public ArrayList fullpath;
    [Range(0f, 1f)]
    public float t;
    private void Awake()
    {
        this.transform.position = unityGraphPosition[murderLocation];
    }

    private void Start()
    {
        StartCoroutine(FindPlayerCorroutine());
    }
    private void Update()
    {
        transform.LookAt(player.transform);
        playerLocation = player.GetComponent<Linus>().playerPosition;
        rb.position = Vector3.Lerp(this.transform.position, pathToGo, t);
    }
    IEnumerator FindPlayerCorroutine()
    {
        while (!playerCaptured || murderLocation != playerLocation)
        {
            Debug.Log("Calculando nova trajetoria!");
            ArrayList fullpath = ShortestPath.Dijkstra(graph, murderLocation, playerLocation);
            StartCoroutine(movementMurderOnebyOne(fullpath));
            yield return new WaitForSeconds(60.0f);
        }
    }
    IEnumerator movementMurderOnebyOne(ArrayList fullpath){
        foreach(int path in fullpath){
            Debug.Log(path);
        }
        foreach (int path in fullpath)
        {
            Debug.Log("Estou no vertice: " + path);
            pathToGo = unityGraphPosition[path];
            murderLocation = path;
            // float peso = graph[path, path + 1];
            //t = 0.1f - (peso / 100f);
            //t = 0.3f;
            yield return new WaitForSeconds(6f);
        }
    }
}
