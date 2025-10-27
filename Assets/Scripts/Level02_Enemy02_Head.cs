using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Level02_Enemy02_Head : MonoBehaviour
{
    public List<Vector2> positionHistory = new List<Vector2>();

    public Transform rotationCenter;
    public float rotationRadius = 2f;
    public float speed = 2f;

    private float positionX = 0f;
    private float positionY = 0f;
    private float angle = 0f;

    public bool oppositeDirection;

    private float ang;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;

        positionY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;


        Vector2 currentPos = new Vector2(positionX, positionY);
        positionHistory.Insert(0, currentPos);

        //Don't want too much :)
        if (positionHistory.Count > 1000)
        {
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }


        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * speed;



        Vector3 direction = rotationCenter.position - transform.position;

        if (!oppositeDirection)
        {
            ang = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0, 0, ang);


        //if(!oppositeDirection)
        //{
        //    transform.Rotate(0, 0, rotateStrength * Time.deltaTime * rotateStrength);
        //}
        //else
        //{
        //    transform.Rotate(0, 0, -rotateStrength * Time.deltaTime * rotateStrength);
        //}

        if (angle >= 360f)
        {
            angle = 0f;
        }

    }
}
