using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Guns
{
    public class Gun : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject _muzzleFlash;
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _pistolSound;

        public void MuzzleFlashOn()
        {
            _muzzleFlash.SetActive(true);
        }

        public void MuzzleFlashOff()
        {
            _muzzleFlash.SetActive(false);
        }

        public void PlayPistolSound()
        {
            _audioSource.PlayOneShot(_pistolSound);
        }
    }
}