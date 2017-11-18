using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndButtonController : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene ("BScene");
		//		GameObject.Find ("GameSceneManager").GetComponent<GameSceneManager> ().GoToTitleScene ();
	}
}
