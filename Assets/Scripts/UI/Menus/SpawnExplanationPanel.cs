using UnityEngine;

namespace UI.Menus
{
    public class SpawnExplanationPanel : ExplanationPanel
    {
        [SerializeField] private GameObject _spawnButtonGameobject;

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
}