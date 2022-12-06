using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string cena;
    public GameObject Pause;
    public GameObject dialogo;
    public GameObject informacao;
    public GameObject caminho;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPause(){
        Pause.SetActive(true);
        dialogo.SetActive(false);
        informacao.SetActive(false);
        caminho.SetActive(false);
        // Debug.Log("pause");
    }

    public void ShowOffPause(){
        Pause.SetActive(false);
                dialogo.SetActive(true);
        informacao.SetActive(true);
        caminho.SetActive(true);
        Time.timeScale=1;
        Debug.Log("despause");
    }

    public void Jogar(){
        SceneManager.LoadScene(cena);
    }
    public void comoJogar(){
        SceneManager.LoadScene("ComoJogar");
    }
    public void sair(){
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("sair");
    }
}
