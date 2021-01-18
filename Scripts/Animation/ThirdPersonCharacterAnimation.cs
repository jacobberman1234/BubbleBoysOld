using UnityEngine;
using InexperiencedDeveloper.Core;
using InexperiencedDeveloper.Bubble;

namespace InexperiencedDeveloper.Animation
{
public class ThirdPersonCharacterAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ThirdPersonCharacterController _characterController;
    [SerializeField] ImplementGravity _gravity;
    [SerializeField] ActivateBubble _activateBubble;
    [SerializeField] Animator _animator;

    void Update() => Animate();

    void Animate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);

        if(Input.GetButtonDown("Jump"))
            _animator.SetTrigger("jump");

        _animator.SetBool("grounded", _gravity.IsGrounded());
        _animator.SetBool("floating", _activateBubble.UsingBubble());

    }

    public void PlayCharacterShootAnimation(int animationNumber) => _animator.SetTrigger("shoot" + animationNumber.ToString());
}
}