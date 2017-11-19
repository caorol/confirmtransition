using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	public float startX = 0;
	public float startY = 1000;
	public float startZ = 0;
	public float endX = 0;
	public float endY = 50;
	public float endZ = 10;
	public int waitStart = 3;

	public delegate void Callback ();
	public event Callback Done;

	private int frameCount = 80;
	private Transform self;
	private bool isStartMove = false;
	private float increaseX;
	private float increaseY;
	private float increaseZ;

	void Start () {
		self = GetComponent<Transform> ();
		self.position = new Vector3 (startX, startY, startZ);
		Debug.Log ("start: (x, y, z): " + startX + ", " + startY + ", " + startZ + ")");
		Debug.Log ("end:   (x, y, z): " + endX + ", " + endY + ", " + endZ + ")");

		// 増分
		increaseX = 0;
		increaseY = (startY - endY) / frameCount;
		increaseZ = (endZ - startZ) / frameCount;
	}

	void Update () {
		if (isStartMove) {
			float x, y, z;
			// x は左右どちらからの移動かで計算が変わるので注意
			x = self.position.x - endX > 0 ? self.position.x - increaseX : endX;
			// y は減っていく: 上から下へ移動なので + から - へ値が移動する
			y = self.position.y - endY > 0 ? self.position.y - increaseY : endY;
			// z は増えていく: 手前から奥へ
			z = endZ - self.position.z > 0 ? self.position.z + increaseZ : endZ;
			//			Debug.Log ("(x, y, z): " + x + ", " + y + ", " + z + ")");

			self.position = new Vector3 (x, y, z);
			if (y <= endY) {
				isStartMove = false;
				Debug.Log ("camera done");
				Done ();
			}
		}
	}

	public void StartMoveCamera() {
		Invoke ("SetStart", waitStart);
	}

	private void SetStart() {
		isStartMove = true;
	}
}
