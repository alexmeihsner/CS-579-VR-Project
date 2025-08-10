using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    private bool cursorShown = false;

    void Update()
    {
        // VR exit: B or Y button
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Application.Quit();
        }

        // ESC key: show cursor and quit if in build
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!cursorShown)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                cursorShown = true;

                Debug.Log("Cursor shown. Press ESC again to quit.");
            }
            else
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in editor
#endif
            }
        }
    }
}
