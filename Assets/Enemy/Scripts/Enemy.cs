using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 2;

    abstract protected void Move();
}
