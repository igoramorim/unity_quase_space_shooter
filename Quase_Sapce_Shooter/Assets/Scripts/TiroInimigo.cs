using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour {

    public Rigidbody2D rigidbodyTiro;   //variavel para manipular a fisica do GameObject
    public float velocidade;            //velocidade de movimento do tiro do inimigo
    public GameObject explosion;        //GameObject da explosao

    // Use this for initialization
    void Start () {
        //Quase a mesma programacao do tiro do player, porem como o tiro do inimigo desce
        //precisamos transformar a velocidade em um numero negativo
        //adicionando o sinal - na frente da variavel
        rigidbodyTiro.velocity = transform.up * -velocidade;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
