using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour {

	public Button ReplayButton;
	public Text Message;
	public MainLoop mainLoop;

	void Start () {
		ReplayButton.onClick.AddListener(()=>{
			gameObject.SetActive(false);
			mainLoop.Restart();
		});
	}

	public void Show (ChessType wintype) {
		switch (wintype) {
			case ChessType.Black:
				{
					Message.text = string.Format("Congratulations!You Win!");
				}
				break;
			case ChessType.White:
				{
					Message.text = string.Format("You Lose!");
				}
				break;
		}
	}
}
