using UnityEngine;

public class PauseMenu : Menu
{
    public override void Open()
    {
        base.Open();
        Time.timeScale = 0f;
    }

    public override void Close()
    {
        base.Close();
        Time.timeScale = 1f;
    }
}
