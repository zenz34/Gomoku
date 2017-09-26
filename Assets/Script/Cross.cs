using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cross : MonoBehaviour {

	public int GridX;
	public int GridY;
	public MainLoop mainLoop;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(()=> {
			mainLoop.OnClick(this);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
