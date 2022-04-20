using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ GameObject wallLeft, wallRight;
    public float timer;
    Vector3 _mousePosition;
    public float speed;
    public float lastPositionOfX, beforeOneFrameFromLastPositionOfX;//used in Ball Script

    // Start is called before the first frame update
    void Start()
    {
        wallLeft = GameObject.Find("WallLeft");
        wallRight = GameObject.Find("WallRight");
       lastPositionOfX = 0;
       beforeOneFrameFromLastPositionOfX = 0;


    }

    void Update()
    {   
        timer+=Time.deltaTime;

        lastPositionOfX = transform.position.x;
        if (timer>=0.5f)
        {
            beforeOneFrameFromLastPositionOfX = lastPositionOfX;
            timer = 0f;
        }


      _mousePosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, -13, Camera.main.transform.position.z*-1));
        _mousePosition.x = Mathf.Clamp(_mousePosition.x, wallLeft.transform.position.x+transform.lossyScale.x/2f, wallRight.transform.position.x - transform.lossyScale.x / 2f);
     

    }
    private void FixedUpdate()
    {
        

        
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(_mousePosition.x, transform.position.y, 0), Time.deltaTime * speed);
    }
}
