using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> ogres;
    float time;
    void Start()
    {
        time = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 8)
        {
            Instantiate(ogres[Random.Range(0, 5)], new Vector3(10, 0, 0), Quaternion.identity);
            time -= 8;
        }
    }
}
