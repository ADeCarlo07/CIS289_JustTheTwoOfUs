using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    public float radius = .6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.OverlapCircle(transform.position, radius, gameObject.layer);
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
