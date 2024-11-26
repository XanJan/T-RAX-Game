using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }
        this.transform.position -= new Vector3(5f * Time.deltaTime, 0, 0);

    }
        
}
