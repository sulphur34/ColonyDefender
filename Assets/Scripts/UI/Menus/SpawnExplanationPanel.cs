using UnityEngine;

public class SpawnExplanationPanel : ExplanationPanel
{
    [SerializeField] GameObject _spawnButtonGameobject;

    public override void Open()
    {
        _spawnButtonGameobject.SetActive(true);
        base.Open();
    }

    public override void Close()
    {
        _spawnButtonGameobject.SetActive(false);
        base.Close();
    }
}
