using UnityEngine;
using Mirror;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MainMenu : MonoBehaviour
{
	public void ChangeScene(string nameScene)
	{
		UnitySceneManager.LoadScene(nameScene);
	}
	public void QuitGame()
	{
		Application.Quit();	
	}
}