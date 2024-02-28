using UnityEngine;
using Utils.Interfaces;

namespace Terrain
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private Route[] _routes;

        public int RoutesAmount => _routes.Length;

        public bool TryGetRoute(int routeIndex, out IRoute route)
        {
            route = null;

            if (routeIndex < _routes.Length)
            {
                route = _routes[routeIndex];
                return true;
            }

            return false;
        }
    }
}