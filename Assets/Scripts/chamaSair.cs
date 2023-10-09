using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaSair : MonoBehaviour
{
    public void Sair() {
        Application.Quit();
        #if UNITY_EDITOR
	UnityEditor.EditorApplication.isPlaying = false;
	#endif
    }
}
