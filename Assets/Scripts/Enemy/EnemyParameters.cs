using System;
using UnityEngine;

[Serializable]
public struct EnemyParameters
{
    [SerializeField] private float _scale;
    [SerializeField] private float _height;

    public float Scale => _scale;
    public float Height => _height;
}
