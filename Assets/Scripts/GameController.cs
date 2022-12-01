using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string cena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar(){
        SceneManager.LoadScene(cena);
    }
    public void comoJogar(){
        SceneManager.LoadScene("ComoJogar");
    }
    public void sair(){
        // UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("sair");
    }
}
