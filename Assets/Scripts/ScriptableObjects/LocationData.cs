using UnityEngine;

[CreateAssetMenu(menuName = "Location Data", fileName = "new location data", order = 55)]
public class LocationData : ScriptableObject
{
    [SerializeField] Location _location;
    [SerializeField] Material _skyboxMaterial;

    public Location Location => _location;
    public Material skyboxMaterial => _skyboxMaterial;
}
