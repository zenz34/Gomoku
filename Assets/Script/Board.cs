using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {
	public GameObject CrossPrefab;
	const float CrossSize = 40;
	public const int CrossCount = 15;
	public const int Size = 560;
	public const int HalfSize = Size / 2;
	Dictionary<int, Cross> _crossMap = new Dictionary<int, Cross>();

	static int MakeKey(int x, int y) {
		return x * 10000 + y;
	}

	public void Reset () {
		foreach (Transform child in this.gameObject.transform) {
			GameObject.Destroy(child.gameObject);
		}

		var mainLoop = GetComponent<MainLoop>();

		_crossMap.Clear();

		for (int x = 0; x < CrossCount; x++) {
			for (int y = 0; y < CrossCount; y++) {
				var crossObject = GameObject.Instantiate<GameObject>(CrossPrefab);
				crossObject.transform.SetParent(gameObject.transform);
				crossObject.transform.localScale = Vector3.one;

				var pos = crossObject.transform.localPosition;
				pos.x = -HalfSize + x * CrossSize;
				pos.y = -HalfSize + y * CrossSize;
				pos.z = 1;
				crossObject.transform.localPosition = pos;

				var cross = crossObject.GetComponent<Cross>();
				cross.GridX = x;
				cross.GridY = y;

				cross.mainLoop = mainLoop;

				_crossMap.Add(MakeKey(x, y), cross);
			}
		}
	}

	public Cross GetCross(int gridX, int gridY) {
		Cross cross;
		if (_crossMap.TryGetValue(MakeKey(gridX, gridY), out cross)) {
			return cross;
		}

		return null;
	}

	void Start () {
		Reset();
	}

	void Update () {
		
	}
}
