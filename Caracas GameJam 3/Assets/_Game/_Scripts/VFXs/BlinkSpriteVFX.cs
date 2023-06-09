using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSpriteVFX : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float interval;
    [SerializeField] private bool playOnStart;
    [SerializeField] private bool undefined;

    // Components
    private SpriteRenderer _spr;

    private bool _isBlinking = false;

    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (playOnStart) SetBlink();
    }

    public void SetBlink()
    {
        _isBlinking = true;
        StartCoroutine(ApplyBlink(interval));
        if (!undefined) StartCoroutine(SetBlinkTime(time));
    }

    private IEnumerator SetBlinkTime(float time)
    {
        yield return new WaitForSeconds(time);
        _isBlinking = false;
        _spr.enabled = true;
    }

    private IEnumerator ApplyBlink(float time)
    {
        _spr.enabled = !_spr.enabled;
        yield return new WaitForSeconds(time);
        if (_isBlinking) StartCoroutine(ApplyBlink(interval));
    }
}
