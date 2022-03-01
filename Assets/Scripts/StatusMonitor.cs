using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMonitor : MonoBehaviour
{
    [SerializeField] private Gradient EnvironmentBarColor;
    [SerializeField] private Gradient HappinessBarColor;

    [SerializeField] private Slider EnvironmentSlider;
    [SerializeField] private Slider HappinessSlider;
    [SerializeField] private Image EnvironmentFill;
    [SerializeField] private Image HappinessFill;
    
    // Start is called before the first frame update
    void Start()
    {
        EnvironmentSlider.value = WorldStateData.EnvironmentLevel;
        EnvironmentSlider.maxValue = WorldStateData.MaxEnvironmentLevel;
        EnvironmentFill.color = EnvironmentBarColor.Evaluate(WorldStateData.EnvironmentLevel / EnvironmentSlider.maxValue);
        HappinessSlider.value = WorldStateData.HappinessLevel;
        HappinessSlider.maxValue = WorldStateData.MaxHappinessLevel;
        HappinessFill.color = HappinessBarColor.Evaluate(WorldStateData.HappinessLevel / HappinessSlider.maxValue);
    }
}
