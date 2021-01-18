using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InexperiencedDeveloper.Core;

namespace InexperiencedDeveloper.Bubble
{
public class ActivateBubble : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController _controller;
    [SerializeField] ImplementGravity _gravity;
    [SerializeField] Bubble _bubble;

    [Header("Settings")]
    [SerializeField] float _bubbleForce = 3;

    Vector3 _velocity;
    bool _usingBubble;

    void Update() => UseBubble();

    void UseBubble()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _bubble.ReturnBubbleTime() > 0)
        {
            _gravity.enabled = false;
            _usingBubble = true;
            _velocity.y = _bubbleForce;
            _controller.Move(_velocity * Time.deltaTime);
        }
        else
        {
            _gravity.enabled = true;
            _velocity = Vector3.zero;
            _usingBubble = false;
        }
    }

    public bool UsingBubble()
    {
        return _usingBubble;
    }
}
}