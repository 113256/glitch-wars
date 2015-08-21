using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	//keys we will use
	//in c# consts are static
	const string MASTER_VOLUME_KEY = "master volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level unlocked...";//level unlocked 1/2/3...

	//static because only one instance on class level
	public static void SetMasterVolume(float volume){
		//volume is 0-1
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= Application.levelCount - 1) {
			//concatenate level.toString() so key is "level unlocked 1/2/3..."
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);//no bools so use 1 for true
		} else {
			Debug.LogError("trying to unlock level not in build order");
		}
	}

	public static bool isLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY+ level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if(level <= Application.levelCount - 1){
			//return bool
			return isLevelUnlocked;
		} else {
			Debug.LogError("trying to query level not in build order");
			return false;
		}
	}

	//between 1 and 3
	public static void SetDifficulty(int difficulty){
		if (difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("difficulty has to be between 1 and 3");
		}
	}

	public static int GetDifficulty(){
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}

}
