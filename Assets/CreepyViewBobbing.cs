using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyViewBobbing : MonoBehaviour
{
    [SerializeField] private float bobbingSpeed = 0.1f;
    [SerializeField] private float bobbingAmount = 0.1f;
    [SerializeField] private float midPoint = 2.0f;
    [SerializeField] private bool enable = true;

    private float timer = 0.0f;
    private float initialY = 0.0f;

    void Start()
    {
        initialY = transform.localPosition.y;
    }

    void Update()
    {
        if (!enable) return;

        float waveY = initialY + bobbingAmount * Mathf.Sin(timer);
        timer += bobbingSpeed * Time.deltaTime;

        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }

        if (transform.localPosition.y < midPoint)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, waveY, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, midPoint, transform.localPosition.z);
        }
    }
}