using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com


public class Pencil : MonoBehaviour
{
	/// <summary>
	/// The color of the pencil.
	/// </summary>
	public Color value;

	void Start(){
		GetComponent<Button> ().onClick.AddListener (() => GameObject.FindObjectOfType<UIEvents> ().PencilClickEvent (this));
	}

	/// <summary>
	/// Enable pencil selection.
	/// </summary>
	public void EnableSelection(){
		GetComponent<Animator>().SetBool("RunScale",true);
	}

	/// <summary>
	/// Disable pencil selection.
	/// </summary>
	public void DisableSelection(){
		GetComponent<Animator>().SetBool("RunScale",false);
	}
}
