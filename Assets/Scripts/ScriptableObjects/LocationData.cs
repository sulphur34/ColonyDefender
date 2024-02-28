using Terrain;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Location Data", fileName = "new location data", order = 55)]
    public class LocationData : ScriptableObject
    {
        [SerializeField] private Location _location;
        [SerializeField] private Material _skyboxMaterial;

        public Location Location => _location;
        public Material SkyboxMaterial => _skyboxMaterial;
    }
}