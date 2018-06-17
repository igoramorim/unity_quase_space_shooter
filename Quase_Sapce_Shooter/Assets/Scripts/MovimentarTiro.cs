using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarTiro : MonoBehaviour {

    public float velocidade;            //velocidade de movimento do tiro do Player
    public Rigidbody2D rigidbodyTiro;   //variavel que vai guardar o componente RigidBody2D do tiro
    public GameObject explosion;        //GameObject da explosao
    public AudioClip explosionSound;    //som da explosao

    // Use this for initialization
    void Start () {
        //Para movimentar um GameObject pela cena, ele precisar ter o componente RigidBody2D
        //que e reponsavel pela fisica do objeto

        //Altera a velocidade e o sentido do RigidBody2D
        //transform.up * velocidade faz ir para cima com a velocidade determinada na variavel 'velocidade'
        rigidbodyTiro.velocity = transform.up * velocidade;
    }

    // Update is called once per frame
    void Update() {
        
    }

    //Colisao entre objetos
    void OnCollisionEnter2D(Collision2D colisorObjetos) {

        //Colisao com os inimigos
        if (colisorObjetos.gameObject.tag == "Enemy") {
            //Cria a explosao
            Instantiate(explosion, transform.position, transform.rotation);
            //Destroi o tiro e o inimigo
            Destroy(gameObject);
            Destroy(colisorObjetos.gameObject);
            //Aumenta a pontuacao em 1
            ScoreManager.score += 1;
            //Toca o som de explosao
            AudioManager.PlaySound(explosionSound);
        }

        //Colisao com o tiro do inimigo
        if (colisorObjetos.gameObject.tag == "TiroInimigo") {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(colisorObjetos.gameObject);
            AudioManager.PlaySound(explosionSound);
        }

    }
}
