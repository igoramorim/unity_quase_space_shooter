using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //variavel publica e estatica que guarda a pontuacao
    public static int score;

    //variavel text que ira mostrar na tela a pontuacao
    Text text;

    void Start () {
        //Pegamos o componente Text do GameObject
        text = GetComponent<Text>();
        
        //zeramos a pontuacao no inicio do jogo
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Atualizamos a pontuacao na tela do jogador
        text.text = "Score: " + score;
    }
}
