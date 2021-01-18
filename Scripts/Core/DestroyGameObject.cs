using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Core
{
    public class DestroyGameObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _timeToDestroy = 2f;

        void Start() => Invoke("DestroyObject", _timeToDestroy);

        void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }
}