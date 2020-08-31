using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour
{
    public GameObject target;

    [SerializeField] private GameObject noTarget;

    private void Start()
    {
        noTarget = GameObject.Find("Player/NoTarget");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
            target = null;
    }
}
