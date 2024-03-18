using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
	public GameObject[] uiElements;

    void Start()
    {
        // Ajouter des écouteurs d'événements aux boutons
        playButton.onClick.AddListener(PlayGame);
        button2.onClick.AddListener(Button2Clicked);
        button3.onClick.AddListener(Button3Clicked);
        button4.onClick.AddListener(Button4Clicked);
        button5.onClick.AddListener(Button5Clicked);
    }

    void PlayGame()
    {
       // lancer le jeu
        Debug.Log("Le a été lancé :) ");
		foreach (GameObject element in uiElements)
        {
            element.SetActive(false);
        }
    }

    void Button2Clicked()
    {
        Debug.Log("Le bouton 2 a été cliqué !");
        // Ajoutez le code ici pour le comportement du bouton 2
    }

    void Button3Clicked()
    {
        Debug.Log("Le bouton 3 a été cliqué !");
        // Ajoutez le code ici pour le comportement du bouton 3
    }

    void Button4Clicked()
    {
        Debug.Log("Le bouton 4 a été cliqué !");
        // Ajoutez le code ici pour le comportement du bouton 4
    }

    void Button5Clicked()
    {
        Application.Quit();
    }
}