using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Explosion : MonoBehaviour
    {
        public float timer = 3.0f;

        public void Start()
        {
            Destroy (gameObject, timer);
        }
    }
}
