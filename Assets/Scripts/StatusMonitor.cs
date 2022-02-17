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
    
    public float EnvironmentStatusLevel = 5;
    public float HappinessStatusLevel = 5;
    // Start is called before the first frame update
    void Start()
    {
        EnvironmentSlider.value = EnvironmentStatusLevel;
        EnvironmentFill.color = EnvironmentBarColor.Evaluate(EnvironmentStatusLevel / EnvironmentSlider.maxValue);
        HappinessSlider.value = HappinessStatusLevel;
        HappinessFill.color = HappinessBarColor.Evaluate(HappinessStatusLevel / HappinessSlider.maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
