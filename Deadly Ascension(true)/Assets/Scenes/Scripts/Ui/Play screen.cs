using UnityEngine;
using Mirror;

public class MainMenu : MonoBehaviour
{
	public void PlayGameOffline()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(2);
		//Application.LoadLevel(1);
	}

	public void PlayGameOnline()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(3);
		//Application.LoadLevel(1);
	}

	public void QuitGame()
	{
		Application.Quit();	
	}
}