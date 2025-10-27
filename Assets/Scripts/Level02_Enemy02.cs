using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level02_Enemy02 : MonoBehaviour
{
  
    public int followIndex;
    public GameObject head;
    public Transform rotationCenter;

    List<Vector2> headPositionList;

    public bool oppositeDirection;

    private float ang;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        headPositionList = head.GetComponent<Level02_Enemy02_Head>().positionHistory;

    }

    // Update is called once per frame
    void Update()
    {

        if (headPositionList.Count > followIndex)
        {
            transform.position = headPositionList[followIndex];
        }


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

    }


}
