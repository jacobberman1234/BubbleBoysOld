using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InexperiencedDeveloper.Guns;

namespace InexperiencedDeveloper.Animation
{
public class GunAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Gun[] _guns;
    [SerializeField] List<Animator> _gunAnimators;

    void Start() => FindGunsAndAnimators();

    void FindGunsAndAnimators()
    {
        _guns = FindObjectsOfType<Gun>();
        if (_guns.Length <= 0)
            return;

        foreach (var gun in _guns)
            _gunAnimators.Add(gun.GetComponent<Animator>());
    }

    public void PlayPistolShootAnimation(int animationNumber) => _gunAnimators[animationNumber - 1].SetTrigger("shoot");
}
}