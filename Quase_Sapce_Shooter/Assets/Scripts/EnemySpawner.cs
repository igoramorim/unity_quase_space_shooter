using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies;        //Lista dos inimigos que serao spawnados

    private bool isLeft;                //Variável que indica se o spawner ira andar para a esquerda ou nao

    public float delayInicial;          //Tempo que a Unity ira esperar para comecar a criar os inimigos
    public float delayMax;              //Tempo entre a criacao de um inimigo e o outro
    public float tempoMovimento;        //Duracao do movimento do spawner antes de trocar de direcao

    //InvokeRepeating executa a funcao Spawn() para criar os inimigos repetidamente
    //E faz o mesmo com a funcao TrocarLado() para fazer o spawner trocar de direcao, indo para esquerda e direita
    void Start() {

        InvokeRepeating("Spawn", delayInicial, delayMax);
        InvokeRepeating("TrocarLado", tempoMovimento, tempoMovimento);

    }

    //Executa a funcao Movimentar() a todo momento, para o spawner nunca parar de andar
    void Update() {

        Movimentar();
    }

    //Cria o inimigo
    void Spawn() {
        //A variavel index sera um numero aleatorio entre 0 e a quantidade de inimigos colocados na lista enemies
        //Os inimigos sao colocados na lista enemies pelo Inspector da Unity
        int index = Random.Range(0, enemies.Length);
        //Com o Instantiate, spawnamos o inimigo na posicao do spawner
        Instantiate(enemies[index], transform.position, transform.rotation);
    }

    //Movimentacao do spawner
    void Movimentar() {

        //O if else abaixo faz com o que o spawner alterne a direcao do movimento entre esquerda e direita

        //Se a variavel isLeft estiver TRUE
        if (isLeft) {
            //Movimente o spawner para a esquerda usando o Vector2.left
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        //Se a variavel isLeft estiver FALSE
        else {
            //Movimente o spawner para a direita usando o Vector2.right
            transform.Translate(Vector2.right * Time.deltaTime);
        }
    }

    //Funcao para alternar a direcao em que o spawner se movimenta
    void TrocarLado() {

        //Invertemos o valor da variavel isLeft usando o sinal de negacao ( ponto de exclamacao )
        //A negacao simplesmente inverte, coloca o valor oposto.

        //Exemplo: A porta esta aberta. >> A negacao dessa frase seria >> A porta nao esta aberta

        //No caso da variavel, quando ela esta no estado TRUE, troca para o FALSE
        //E quando esta no FALSE >> TRUE
        isLeft = !isLeft;
    }
}
