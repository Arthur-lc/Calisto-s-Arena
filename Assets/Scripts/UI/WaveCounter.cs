using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public int wave = 0;
    public TextMeshProUGUI number;
    private void OnEnable() {
        Events.onStartWave.AddListener(Count);
    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(Count);
    }

    private void Count() {
        wave++;
        number.text = wave.ToString();
        GameManager.Instance.waveNumber = wave;
    }
}
