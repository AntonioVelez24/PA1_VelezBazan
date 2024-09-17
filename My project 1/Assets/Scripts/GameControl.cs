using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text scoreText;
    public GameObject panel;
    private PlayerControl playerControl;
    public GameObject player;
    public Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }
    private void OnEnable()
    {
        PlayerControl.OnPlayerScore += UpdateScore;
    }
    // Update is called once per frame
    void Update()
    {
        if (player==null){
            panel.SetActive(true);
            finalText.text = "Game Over";
        }
    }
    private void UpdateScore(int newScore)
    {
        scoreText.text = "Puntaje: " + newScore;
    }
}
