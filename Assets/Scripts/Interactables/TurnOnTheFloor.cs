using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTheFloor : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0, -1, 0);

    private void FixedUpdate()
    {
        transform.Rotate(rotation);
    }
}
