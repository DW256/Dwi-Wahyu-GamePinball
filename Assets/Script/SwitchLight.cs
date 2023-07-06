using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;

    public Material offMaterial;
    public Material onMaterial;

    private Renderer r;
    private bool isOn = false;

    private void Start()
    {
        r = GetComponent<Renderer>();

        SetLight(false);
    }

    private void SetLight(bool active)
    {
        isOn = active;
        if (isOn)
        {
            r.material = onMaterial;
        }
        else
        {
            r.material = offMaterial;
        }
    }

    private IEnumerator Blink(int times)
    {
        int blinkTimes = times * 2;
        for (int i = 0; i < blinkTimes; i++)
        {
            SetLight(!isOn);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != ballCollider) return;

        //SetLight(!isOn);
        StartCoroutine(Blink(2));
    }

}
