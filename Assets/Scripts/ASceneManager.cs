using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASceneManager : MonoBehaviour {
	private CameraManager cameraManager = null;
	private GameObject scorePanel = null;
	private bool isGameStart = false;

	void Awake () {
		Debug.Log ("<color=green>ASceneManager - Awake</color>");
		cameraManager = GameObject.Find ("Main Camera").GetComponent<CameraManager> ();
		CameraManager.Done += ReadyCameraCallback;

		string canvasName = "Canvas";
		string scorePanelName = "ScorePanel";
		scorePanel = GameObject.Find (canvasName).transform.Find(scorePanelName).gameObject;
		if (scorePanel == null) {
			Debug.Log ("<color=green>score panel is null !!!</color>");
		}
		Debug.Log ("<color=green>close score panel</color>");
		scorePanel.SetActive (false);

		// カメラズーム
		cameraManager.StartMoveCamera ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReadyCameraCallback() {
		ShowScorePanel ();
	}

	private void GameStart() {
		isGameStart = true;
	}

	private void ShowScorePanel() {
		Debug.Log ("<color=green>show score panel</color>");
		scorePanel.SetActive (true);
		Invoke("GameStart", 0.5f);
	}

	void OnApplicationQuit () {
		Debug.Log ("<color=green>ASceneManager - OnApplicationQuit</color>");
	}
	void OnDisable () {
		Debug.Log ("<color=green>ASceneManager - OnDisable</color>");
	}
	void OnDestroy () {
		Debug.Log ("<color=green>ASceneManager - OnDestroy</color>");
	}
}
