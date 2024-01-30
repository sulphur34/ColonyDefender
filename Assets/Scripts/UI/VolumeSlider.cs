using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Menu _menu;

    private Slider _slider;

    private void Awake()
    {        
        _slider = GetComponent<Slider>();
        _audioManager.VolumeChanged += SetSlider;
        _menu.Opened += SetSlider;
    }

    private void SetSlider(float value)
    {
        _slider.value = value;
    }

    private void SetSlider()
    {
        _slider.value = _audioManager.Volume;
    }
}
