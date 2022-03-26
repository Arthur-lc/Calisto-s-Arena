using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ImpulseManager : MonoBehaviour
{
    public static ImpulseManager Instance;
    public CinemachineImpulseSource impulseSource;

    void Start()
    {
        Instance = this;
    }

    public void Shake(float magnitude = 1) {
        impulseSource.GenerateImpulse(magnitude);
    }
}
