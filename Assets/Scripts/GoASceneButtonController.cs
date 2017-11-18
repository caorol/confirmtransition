using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoASceneButtonController : MonoBehaviour {
		public void OnClick() {
		SceneManager.LoadScene ("AScene");
		//		GameObject.Find ("GameSceneManager").GetComponent<GameSceneManager> ().GoToTitleScene ();
	}
}
