using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollingBackground : MonoBehaviour
{
    //This script is for the moving stars in the background of Tutorial

    public Transform background1;
    public Transform background2;
    public float speed;

    private float length;

    void Start()
    {
        length = background1.GetComponent<TilemapRenderer>().bounds.size.x;
    }

    void Update()
    {
        //Move both
        background1.Translate(Vector2.left * speed * Time.deltaTime);
        background2.Translate(Vector2.left * speed * Time.deltaTime);

        //If background1 is fully offscreen, move it in front of background2
        if (background1.position.x < -length)
        {
            background1.position = new Vector3(background2.position.x + length, background1.position.y, background1.position.z);
        }

        //If background2 is fully offscreen, move it in front of background1
        if (background2.position.x < -length)
        {
            background2.position = new Vector3(background1.position.x + length, background2.position.y, background2.position.z);
        }
    }
}
