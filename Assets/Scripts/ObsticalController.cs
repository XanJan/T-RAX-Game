using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalController : MonoBehaviour
{
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        moveObstecal();
    }

    private void moveObstecal()
    {
        if (transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }
        this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void setSpeed(float s)
    {
        speed += s;
    }
        
}
