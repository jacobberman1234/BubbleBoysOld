using UnityEngine;

namespace InexperiencedDeveloper.Core
{
public class ImplementGravity : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController _controller;
    [SerializeField] ThirdPersonCharacterController _characterController;
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundMask;

    [Header("Settings")]
    [SerializeField] float _jumpForce = 1.5f;
    [SerializeField] float _groundRadius = 0.5f;

    readonly float _gravity = Physics.gravity.y;

    Vector3 _velocity;

    void Update() => ProcessGravity();
    
    void ProcessGravity()
    {

        if (IsGrounded() && _velocity.y < 0)
            _velocity.y = -2;

        if (Input.GetButtonDown("Jump") && IsGrounded())
            _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravity);

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
    }
}
}