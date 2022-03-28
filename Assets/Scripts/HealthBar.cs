using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    public float maxHealth;

    private void OnEnable() {
        Events.onHealthChange.AddListener(UpdateBar);
        Events.onMaxHealthChange.AddListener(UpdateBar);
    }

    private void OnDisable() {
        Events.onHealthChange.RemoveListener(UpdateBar);
        Events.onMaxHealthChange.RemoveListener(UpdateBar);
    }

    private void UpdateBar(float newValue) {
        fill.fillAmount = newValue / maxHealth;
    }

    private void UpdateMaxHealth(float newValue) {
        maxHealth += newValue;
    }
}
