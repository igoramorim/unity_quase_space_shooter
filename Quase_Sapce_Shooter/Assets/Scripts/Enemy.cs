using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float velocidade;        //velocidade de movimento
    public Transform shotSpwan;     //posicao de onde o tiro ira sair
    public GameObject tiro;         //tiro do inimigo
    public float delayTiro;         //tempo de espera entre cada tiro
    public AudioClip shot;          //som do tiro
    AudioSource audio;              //componente para tocar os audios

    // Use this for initialization
    void Start () {
        //InvokeRepeating fica executando uma determinada funcao a cada tempo
        //No caso, e a funcao Atirar() e o tempo e a variavel delayTiro
        InvokeRepeating("Atirar", delayTiro, delayTiro);

        //Pega o componente AudioSource do Inspector do Inimigo
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //Movimento o inimigo para baixo
        transform.Translate(Vector2.down * velocidade * Time.deltaTime);
    }

    void Atirar() {
        //cria o tiro do inimigo na cena
        Instantiate(tiro, shotSpwan.position, shotSpwan.rotation);
        audio.PlayOneShot(shot, 0.75F);
    }

}
