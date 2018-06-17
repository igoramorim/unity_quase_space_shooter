using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float velocidade;            //Velocidade de movimento
    public GameObject tiro;             //GameObject que sera o tiro da nave
    public Transform shotSpwan;         //A posicao de onde o tiro ira sair
    public GameObject[] enemies;        //Lista que vai guardaro os inimigos que estao na tela. Usada no powerup
    public AudioClip shot;              //Som do tiro
    public AudioClip explosionSound;    //Som da explosao
    public AudioClip upgrade;           //Som do powerup
    public GameObject explosion;        //GameObject da explosao

    //Funcao Start() e executada somente uma vez, no inicio do jogo
    void Start () {
       
    }
	
	//Funcao Update() e chamada a todo momento. Um Loop infinito
    //Chamamos as funcoes Movimentar() e Atirar() a todo instante
	void Update () {
        Movimentar();
        Atirar();
    }

    //Funcao que verifica os inputs do teclado e faz a nave se movimentar
    void Movimentar() {
        //o eixo x, que e o Horizontal, corresponde as teclas 'A' e 'S' ou as setas do teclado

        //quando o jogador aperta a tecla 'S' o valor de Horizontal vai para 1

        //exemplo: digamos que voce colocou 10 na velocidade
        //Vecto2.right significa 1 no eixo X
        //a nave vai andar na velocidade de 1 * 10 = 10
        if (Input.GetAxis("Horizontal") > 0) {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        //quando apertar a tecla 'A', o Horizontal fica -1
        //e o Vector2.left significa -1 no eixo X
        //no fim a conta fica -1 * 10 = -10

        //como vimos desde as primeiras aulas do curso, aumentamos o X andar para a direita
        //e diminuimos para a esquerda
        if (Input.GetAxis("Horizontal") < 0) {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        //para o eixo Vertical, que e o Y, a ideia e a mesma
        //para baixo fica -1
        //e para cima 1
        if (Input.GetAxis("Vertical") < 0) {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0) {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
    }

    //Funcao da Unity para colisoes
    void OnCollisionEnter2D(Collision2D colisorObjetos) {

        //colisao com os GameObjects com TAG 'Enemy'
        if (colisorObjetos.gameObject.tag == "Enemy") {
            //Funcao Instantiate cria objetos na tela, nesse caso sera a explosao
            Instantiate(explosion, transform.position, transform.rotation);
            //Toca o som da explosao
            AudioManager.PlaySound(explosionSound);
            //Destroi o GameObject com esse Script (a nave)
            Destroy(gameObject);
            //Destroi o GameOject com a TAG 'Enemy'
            Destroy(colisorObjetos.gameObject);
            //Carrega a cena de Gameplay
            SceneManager.LoadScene("Gameplay");
        }

        if (colisorObjetos.gameObject.tag == "TiroInimigo") {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioManager.PlaySound(explosionSound);
            Destroy(gameObject);
            Destroy(colisorObjetos.gameObject);
            SceneManager.LoadScene("Gameplay");
            
        }

        //Colisao com o PowerUp que destroi todos os inimigos da cena
        if (colisorObjetos.gameObject.tag == "PowerUpKill") {
            AudioManager.PlaySound(upgrade);
            Destroy(colisorObjetos.gameObject);

            //A lista enemies vai guardar todos os inimigos que estiverem na cena no momento da colisao
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            AudioManager.PlaySound(explosionSound);

            //Destroi cada inimigo da lista enemies e cria as explosoes
            foreach (GameObject enemy in enemies) {
                Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
                Destroy(enemy);
            }
        }
    }

    //Tiro da nave
    void Atirar() {
        //Fire1 e o botao esquerdo do mouse
        //Esse if verifica se ele foi pressionado
        //Se for, cria o tiro
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(tiro, shotSpwan.position, shotSpwan.rotation);
            AudioManager.PlaySound(shot);
        }
    }
}
