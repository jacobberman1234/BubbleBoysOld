using UnityEngine;
using InexperiencedDeveloper.Animation;
using InexperiencedDeveloper.Guns;

namespace InexperiencedDeveloper.Core
{
    public class Shoot : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] ThirdPersonCharacterAnimation _characterAnimation;
        [SerializeField] GunAnimation _gunAnimation;

        int _animationNumber;

        void Start() => _animationNumber = 1;

        private void Update() => ShootWeapon(); 

        void ShootWeapon()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwapAnimationNumber();

                GameObject rayHit = Helper.ShootRay(100, Camera.main);
                _characterAnimation.PlayCharacterShootAnimation(_animationNumber);
                _gunAnimation.PlayPistolShootAnimation(_animationNumber);
                print(rayHit.name);
            }
        }

        void SwapAnimationNumber()
        {
            if (_animationNumber == 1)
                _animationNumber = 2;
            else
                _animationNumber = 1;
        }

    }
}