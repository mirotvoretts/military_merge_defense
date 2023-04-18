using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _body;
    [SerializeField] private Animator _gunAnimator;

    public Transform Body { get => _body; }
    public Animator GunAnimator { get => _gunAnimator; }
}
