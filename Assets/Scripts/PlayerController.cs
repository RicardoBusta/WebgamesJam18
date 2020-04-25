using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    public void Move(Vector3 direction)
    {
        var scale = Time.deltaTime * playerSpeed;
        transform.position += scale * direction;
    }
}