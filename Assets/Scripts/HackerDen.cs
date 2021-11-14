using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerDen : MonoBehaviour
{
    public GameObject player, consoleCamera;

    private bool inConsole;

    public void UseConsole()
    {
        Cursor.lockState = CursorLockMode.Confined;
        player.SetActive(false);
        consoleCamera.SetActive(true);
        inConsole = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inConsole)
            {
                Cursor.lockState = CursorLockMode.Locked;
                player.SetActive(true);
                consoleCamera.SetActive(false);
            }
        }
    }
}
