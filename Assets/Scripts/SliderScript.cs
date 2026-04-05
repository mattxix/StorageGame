using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("references")]
    public FPMovement movementScript;
    [Header("sliders")]
    public Slider speedSlider;
    public TextMeshProUGUI speedValue;
    public Slider JumpSlider;
    public TextMeshProUGUI JumpValue;
    

    void Start()
    {

        speedSlider.minValue = .1f;
        speedSlider.maxValue = 40f;
        speedSlider.value = 7f;

        JumpSlider.minValue = 0f;
        JumpSlider.maxValue = 40f;
        JumpSlider.value = 7f;


        speedSlider.onValueChanged.AddListener(OnSliderValueChangedSpeed);
        JumpSlider.onValueChanged.AddListener(OnSliderValueChangedJump);
    }

    void OnSliderValueChangedSpeed(float value)
    {
        movementScript.speed = value;
        speedValue.text = value.ToString("F1");
        
    }
    void OnSliderValueChangedJump(float value)
    {
        movementScript.jumpStrength = value;
        JumpValue.text = value.ToString("F1");
    }
}