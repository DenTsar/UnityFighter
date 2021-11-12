using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public bool attack;
    (float, float,float) circle;
    private void Start()
    {
        if (transform.root.tag == "Ogre")
            circle = (-0.77f, -0.13f, 0.79f);
        else
            circle = (-0.54f, 0.44f, 0.65f);
    }

    void Update()
    {
        Collider2D[] stuffHit = Physics2D.OverlapCircleAll(transform.position +
            (transform.rotation * new Vector3(circle.Item1 * transform.root.transform.localScale.x, circle.Item2)), circle.Item3);
        foreach (Collider2D i in stuffHit)
        {
            GameObject o = i.transform.root.gameObject;
            if (attack && ((transform.root.tag == "Ogre" && o.name == "Player") || (transform.root.name == "Player" && o.tag == "Ogre")))
            {
                attack = false;
                float damage = o.name == "Player" ? 0.5f : 1f;
                o.transform.Find("HPBar/Health").gameObject.GetComponent<HP>().Decrease(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + 
                (transform.rotation * new Vector3(circle.Item1 * transform.root.transform.localScale.x, circle.Item2)), circle.Item3);
    }
}
