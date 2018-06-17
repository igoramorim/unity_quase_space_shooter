using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    //O Script AudioManager sera usado para tocar os sons do jogo
    //como os tiros e as explosoes

    //Quando a variavel e publica e static conseguimos usa-la dentro de outro script
    //Como na linha 72 do script Player
    //AudioManager.PlaySound(explosionSound);
    public static AudioSource audio;

	void Start () {
        //Guarda o componente AudioSource na variavel audio
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Funcao static para conseguirmos usa-la em outros scripts
    public static void PlaySound(AudioClip clip) {
        //toca o som somente um vez
        audio.PlayOneShot(clip, 1.0f);
    }
}
