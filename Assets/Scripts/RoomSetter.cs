using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomSetter : MonoBehaviour
{
    public int id;

    public bool playerEnter;

    public bool pointCaptured;

    [SerializeField] private Linus linus;

    public static RoomSetter instance;

    public int sum;

    public Text informationText;

    public string defaultText= "Segure o bot�o esquerdo do mouse.";

    void Start(){
        instance = this;
    }


    private void Update()
    {
        if (playerEnter) {
            if (Input.GetKey(KeyCode.Mouse0) && !pointCaptured)
            {
                sum++;
                informationText.text = "Carregando... Restam "+ (3000-sum).ToString();
                if ((sum / 3000) >= 1) {
                    pointCaptured = true;
                    linus.ponto --;
                    defaultText = "Ponto j� analisado!";
                    informationText.text = defaultText;
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                // Debug.Log("Soltando");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            informationText.text = defaultText;
            other.GetComponent<Linus>().playerPosition = id;
            playerEnter = true;
        }
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<Murder>().murderLocation = id;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            informationText.text = "";
            playerEnter = false;
        }
    }
}
