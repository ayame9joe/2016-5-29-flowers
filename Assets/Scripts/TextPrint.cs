using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour {

	float letterPause = 0.2f;
	private string word;
	private string printText;
	private int i, j = 0;

	public bool isTest1;

	//---Story Line---
	private string[] Text = {
		"流\n水\n落\n花\n春\n去\n也\n，",
		"天\n上\n人\n间\n。",
	};

	public Text txtPrint;
	//public GameObject storyBoardPanel;

	bool paused;
	// Use this for initialization
	void Start () {

		//storyBoardPanel.SetActive (true);
		if (isTest1) {
			TextChange ();
		}
		else if (!isTest1){
			if (i < Text.Length - 1) {
			i++;
		}
			TextChange();}
	
	}
	
	// Update is called once per frame
	void Update () {


		txtPrint.text = printText;
		//TextMoveOn ();
	
	}

	void TextChange () {
		word = "";
		word = Text [i];
		printText = "";
		StartCoroutine (TypeText ());
	}

	IEnumerator TypeText () {
		if (!isTest1) {
			yield return new WaitForSeconds (3.5f);
		}

		foreach (char letter in word.ToCharArray()) {
			printText += letter;
			yield return new WaitForSeconds(letterPause);
		}

		printText += "";
		j++;
	}

	public void OnTextConfirm () {
		//if (Input.GetMouseButtonDown(0))
		{                    
			//检测对话显示完没有 i = j 就是还没有显示完
			if (i == j)
			{
				letterPause = 0.0f;     //加快显的速度，让对话速度显示完
			}
			else
			{
				//检测对话语句是否超出了最大限制，超出了就DO STH.
				if (i < Text.Length - 1)
				{
					letterPause = 0.2f;
					i++;
					TextChange();
				}
				else
				{
					//DO STH.
					//storyBoardPanel.SetActive(false);
					
				}
				
			}                                          
		}          
	}




}
