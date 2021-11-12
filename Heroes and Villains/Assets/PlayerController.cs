using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 5f;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0) {
            transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);
            animator.SetBool("walk", true);
            if (x < 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if(x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
            animator.SetBool("walk", false);
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            animator.SetTrigger("attack");
            transform.Find("Hip/Body/Hand_R/Sword").gameObject.GetComponent<SwordCollider>().attack = true;
        }
    }
}
