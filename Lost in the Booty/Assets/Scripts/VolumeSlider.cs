/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    
    }

}
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;

    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        musicVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        effectsVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));

        // Set initial slider values
        masterVolumeSlider.value = SoundManager.Instance.GetMasterVolume();
        musicVolumeSlider.value = SoundManager.Instance.GetMusicVolume();
        effectsVolumeSlider.value = SoundManager.Instance.GetEffectsVolume();
    }
}
