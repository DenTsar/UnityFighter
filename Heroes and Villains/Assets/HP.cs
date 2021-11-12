using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public void Decrease(float f)
    {
        transform.localScale -= new Vector3(f, 0, 0);
        if (transform.localScale.x <= 0)
            transform.root.gameObject.GetComponent<Exploder>().BigExplode();
    }
}
