using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//pass number of levels
	//e.g. if size = 2 there will be 2 indexes, each index corresponds to the level in build settings, index 0 = level0
	//then you can drag a music clip to each element
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake(){
		//instructs music manager to persist
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//level = current level
	//monobehaviour method
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray [level];	

		if (thisLevelMusic) {//if theres music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
