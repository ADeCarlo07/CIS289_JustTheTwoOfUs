using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollingBackground : MonoBehaviour
{
    private float startPos;
    public float speed;
    private float length;
    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<TilemapRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //if background reached end of length adjust position for infinite scrolling
        if(transform.position.x  < cameraTransform.position.x - length)
        {
            //if you have two tilemaps you need to times length times 2
            transform.position += new Vector3(length * 2f, 0f, 0f);
        }
    }
}
