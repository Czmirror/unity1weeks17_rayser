using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonSceneMove : MonoBehaviour {

	public string loadScene;

	public void pushButton () {
		SceneManager.LoadScene ( loadScene );
	}
}
