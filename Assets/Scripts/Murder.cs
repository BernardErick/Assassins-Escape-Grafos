using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Murder : MonoBehaviour
{
    private int[,] graph
                = new int[,] {
                            { 0,2,0,0,0,0,0,0,0,0,0 },
                            { 2,0,8,0,3,0,0,0,0,0,0 },
                            { 0,8,0,0,0,0,3,0,0,0,0 },
                            { 0,0,0,0,1,0,0,0,0,0,0 },
                            { 0,0,0,1,0,4,0,6,0,0,0 },
                            { 0,0,0,0,4,0,4,0,6,0,0 },
                            { 0,0,3,0,0,4,0,0,0,0,7 },
                            { 0,0,0,0,6,0,0,0,4,0,0 },
                            { 0,0,0,0,0,6,0,4,0,1,0 },
                            { 0,0,0,0,0,6,0,0,0,1,0 },
                            { 0,0,0,0,0,0,7,0,0,4,0 }
                            };
    private Vector3[] unityGraphPosition
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

    //HUD
    public Text playerPositionText;
    public Text murderShortestPath;
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


        playerPositionText.text = playerLocation.ToString();
    }
    IEnumerator FindPlayerCorroutine()
    {
        while (!playerCaptured || murderLocation != playerLocation)
        {
            Debug.Log("Calculando nova trajetoria!");

            ArrayList fullpath = ShortestPath.Dijkstra(graph, murderLocation, playerLocation);
            string text = "";
            foreach (int path in fullpath)
                text += "->" + path;

            float tempoDeRecalculo = 0;
            for (int i = 0; i < fullpath.Count - 1;i++) {
                int origem = (int)fullpath[i];
                int destino = (int)fullpath[i + 1];
                tempoDeRecalculo += graph[origem, destino];
            }
            murderShortestPath.text = text;
            StartCoroutine(movementMurderOnebyOne(fullpath));

            float tempoTotal = 30.0f + tempoDeRecalculo;

            Debug.Log("Tempo para recalcular: " + tempoTotal);
            yield return new WaitForSeconds(tempoTotal);
        }
    }
    IEnumerator movementMurderOnebyOne(ArrayList fullpath){
        int origem = -1;
        int destino = -1;
        float peso = 1f;
        for (int i = 0; i < fullpath.Count - 1; i++)
        {
            origem = (int)fullpath[i];
            destino = (int)fullpath[i + 1];
            peso = graph[origem, destino];

            Debug.Log("Estou no vertice: "+ origem);
            Debug.Log("Indo ao vertice: " + destino);
            Debug.Log("Com o Peso: " + peso);

            pathToGo = unityGraphPosition[destino];
            murderLocation = destino;
            //Chegando l�, eu descanso o tanto que andei
            yield return new WaitForSeconds(1f + peso);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("Teleportas");
            //SceneManager.LoadScene("GameOver");
        }
    }
}
