using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Bubble
{
public class Bubble : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ActivateBubble _activateBubble;

    [Header("Settings")]
    [SerializeField] float _baseBubbleTimer = 4;
    [SerializeField] float _baseRefreshTimer = 2;

    float _bubbleTimer;
    float _refreshTimer;

    void Start() => ResetTimers();

    void Update() => BubbleTimer();

    void BubbleTimer()
    {
        if (!_activateBubble.UsingBubble())
        {
            if (_refreshTimer > 0)
            {
                _refreshTimer -= Time.deltaTime;
            }
            else
            {
                if (_bubbleTimer < _baseBubbleTimer)
                {
                    _bubbleTimer += Time.deltaTime;
                }
                else
                {
                    _bubbleTimer = _baseBubbleTimer;
                }
            }
        }
        else if (_activateBubble.UsingBubble())
        {
            _refreshTimer = _baseRefreshTimer;
            _bubbleTimer -= Time.deltaTime;
        }
    }

    public float ReturnBubbleTime()
    {
        return _bubbleTimer;
    }
    
    void ResetTimers()
    {
        _bubbleTimer = _baseBubbleTimer;
        _refreshTimer = _baseRefreshTimer;
    }
}
}