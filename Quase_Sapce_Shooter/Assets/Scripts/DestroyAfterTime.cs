using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    //Esse script ira destruir o GameObject depois de um determinado tempo
    //Ele e usado em varios GameObjects, como os tiros, os inimigos e as explosoes

    //Tempo de vida do GameObject
    public float tempoVida;

	void Start () {
        //Invoke ira executar a funcao DestroyObject
        Invoke("DestroyObject", tempoVida);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Funcao responsavel por destruir o GameObject
    void DestroyObject() {
        Destroy(gameObject);
    }
}
