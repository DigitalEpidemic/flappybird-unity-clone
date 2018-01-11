using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsController : MonoBehaviour {

	public static AdsController instance;

	void Awake () {
		MakeSingleton ();
	}

	void OnEnable () {
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}

	void OnDisable () {
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}
		
	void LevelFinishedLoading (Scene scene, LoadSceneMode mode) {
		if (scene.name == "MainMenu") {
			int random = Random.Range (0, 10);
			if (random > 7) {
				ShowAd ();
			}
		}
	}
	
	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void ShowRewardAd () {
		if (Advertisement.IsReady ("rewardedVideo")) {
			ShowOptions options = new ShowOptions ();
			options.resultCallback = HandleShowResult;

			Advertisement.Show ("rewardedVideo", options);
		}
	}

	public void ShowAd () {
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}

	void HandleShowResult (ShowResult result) {
		if (result == ShowResult.Finished) {
			Debug.Log ("Video Completed - Here is a reward!");
		} else if (result == ShowResult.Skipped) {
			Debug.Log ("Video Skipped - NO reward!");
		} else if (result == ShowResult.Failed) {
			Debug.Log ("Video failed to show ):");
		}
	}
		

} // AdsController
