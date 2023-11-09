using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IntensifyLight : MonoBehaviour
{
    [SerializeField] private Light2D Light;

    void Update()
    {
        Light.intensity = Mathf.PingPong(Time.time, 1f);
    }
}
