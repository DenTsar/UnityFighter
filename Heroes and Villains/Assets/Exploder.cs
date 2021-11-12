using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void BigExplode()
    {
        Destroy(gameObject.transform.Find("Shadow").gameObject);
        Destroy(gameObject.transform.Find("HPBar").gameObject);
        gameObject.GetComponent<Animator>().enabled = false;
        foreach (Transform tr in transform.GetComponentsInChildren<Transform>())
            Explode(tr);
    }
    public void Explode(Transform t)
    {
        Destroy(t.gameObject, 5f);
        foreach (Transform c in t)
        {
            Destroy(c.gameObject.GetComponent<PolygonCollider2D>());
            c.parent = null;
            Rigidbody2D rb2 = c.gameObject.AddComponent<Rigidbody2D>(); 
            rb2.AddForce(new Vector2(Random.Range(-5, 5), Random.Range(7f, 10f)), ForceMode2D.Impulse);
            Explode(c);
        }
        if (t.name == "Player")
            Destroy(t);
    }
}
