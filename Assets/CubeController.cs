using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector2 resetPosition;

    public void ResetPosition()
    {
        target.transform.position = resetPosition;
    }

    public void LockObject()
    {
        var rb = target.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void UnlockObject()
    {
        var rb = target.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
