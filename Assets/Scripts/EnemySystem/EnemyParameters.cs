using System;
using UnityEngine;

namespace EnemySystem
{
    [Serializable]
    public struct EnemyParameters
    {
        [SerializeField] private float _scale;
        [SerializeField] private Material _material;

        public float Scale => _scale;
        public Material Material => _material;
    }
}