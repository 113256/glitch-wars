using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider diffSlider;
	private LevelManager levelManager;
	//not in hierarchy of options screen but it wont be null if we start from Start scene due to persistentMusicManager
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		levelManager= GameObject.FindObjectOfType<LevelManager> ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		diffSlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		//need this to actually change the volume
		musicManager.ChangeVolume (volumeSlider.value);
	}



	public void saveAndExit(){
		//save options
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
		levelManager.LoadLevel ("01a Start");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		diffSlider.value = 2;
	}
}
