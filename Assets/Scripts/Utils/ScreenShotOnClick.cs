using UnityEngine;

public class ScreenShotOnClick : MonoBehaviour
{    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            Debug.Log("A screenshot was taken!");
        }
    }
}
