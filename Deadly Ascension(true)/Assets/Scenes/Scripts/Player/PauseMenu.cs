using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using StarterAssets;
public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public static bool GameIsPaused =false;
    private ThirdPersonController thirdPersonController;
    private ThirdPersonShooter thirdPersonShooter;
    
    
    void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        thirdPersonShooter = GetComponent<ThirdPersonShooter>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        thirdPersonController.enabled = true;
        thirdPersonShooter.enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        thirdPersonController.enabled = false;
        thirdPersonShooter.enabled = false;
    }


}
