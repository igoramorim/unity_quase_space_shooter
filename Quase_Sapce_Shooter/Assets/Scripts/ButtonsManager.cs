using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //funcao responsavel por trocar de cena
    //recebe o nome da cena como parametro => variavel sceneName
    //para usar o SceneManager e necessario o "import" da linha 4
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
