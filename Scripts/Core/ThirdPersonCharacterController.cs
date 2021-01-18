using UnityEngine;


namespace InexperiencedDeveloper.Core
{
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ImplementGravity))]
public class ThirdPersonCharacterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController _controller;
    [SerializeField] Transform _mainCamera;

    [Header("Settings")]
    [SerializeField] float _speed = 6;
    [SerializeField] float _turnSmoothTime = 0.1f;
    [SerializeField] float _jumpForce = 15;

    float _turnSmoothVelocity;

    void Start() => Helper.TurnOnCursor(false);

    void Update() => Move();

    Vector3 MovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }

    void Move()
    {
        float targetAngle = _mainCamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        if (MovementInput().magnitude >= 0.1f)
        {


            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * MovementInput();

            _controller.Move(moveDirection * _speed * Time.deltaTime);
        }

    }
} //class
} //namespace
