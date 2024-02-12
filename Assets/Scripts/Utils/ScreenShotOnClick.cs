using UnityEngine;

public class ScreenShotOnClick : MonoBehaviour
{
    int index = 1;
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ScreenCapture.CaptureScreenshot("screenshot" + index + ".png");
            index++;
        }
    }
}
