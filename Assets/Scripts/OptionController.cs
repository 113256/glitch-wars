using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	private LevelManager levelManager;
	//not in hierarchy of options screen but it wont be null if we start from Start scene due to persistentMusicManager
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		levelManager= GameObject.FindObjectOfType<LevelManager> ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		//so that the values are saved when you return to this screen, and also between game sessions
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		//need this to actually change the volume
		/*there will be a null reference error if you play from the options screen since theres no music manager, if you start from splash
		the persistent music manager will persist to the options screen*/
		musicManager.ChangeVolume (volumeSlider.value);
	}



	public void saveAndExit(){
		//save options
		PlayerPrefsManager.SetDifficulty ((int)difficultySlider.value);
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);

		levelManager.LoadLevel ("01a Start");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2;
	}
}
