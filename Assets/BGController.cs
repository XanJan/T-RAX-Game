using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class BGController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -20)
        {
            Instantiate(gameObject, new Vector3(18f, -1f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
        transform.position -= new Vector3(2f * Time.deltaTime, 0f, 0f);
    }
}
