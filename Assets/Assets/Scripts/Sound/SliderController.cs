using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void MusicVolume()
    {
        audioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void sfxVolume()
    {
        audioManager.Instance.sfxVolume(_sfxSlider.value);
    }
}
