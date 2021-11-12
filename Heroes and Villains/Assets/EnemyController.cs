using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    Transform player;
    bool attacking;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);
        if(GameObject.Find("Player")!=null)
            player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player == null ? 10 : Vector2.Distance(transform.position, player.transform.position);
        if (distance > 5)
            transform.Translate(Vector3.left * Time.deltaTime);
        else if (distance > 2.5)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack") && !attacking)
        {
            transform.Find("Hip/Body/Hand_R/Club").gameObject.GetComponent<SwordCollider>().attack = true;
            animator.SetTrigger("attack");
            attacking = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            attacking = false;
        if (distance > 5 || transform.position.x >= player.transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        if (transform.position.x < -15)
            Destroy(gameObject);
    }
}
