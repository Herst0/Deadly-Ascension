using UnityEngine;
using Mirror;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		//Application.LoadLevel(1);
	}

	public void QuitGame()
	{
		Application.Quit();	
	}
}