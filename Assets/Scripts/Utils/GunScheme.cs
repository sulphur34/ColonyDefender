using System.Collections;
using UnityEngine;

[System.Serializable]
public class GunScheme : IEnumerable
{
    public Vector3[] Positions;

    public IEnumerator GetEnumerator()
    {
        foreach (Vector3 position in Positions)
        {
            yield return position;
        }
    }

    public Vector3 this[int index]
    {
        get
        {
            Vector3 position = Positions[index];
            return position;
        }
    }
}


