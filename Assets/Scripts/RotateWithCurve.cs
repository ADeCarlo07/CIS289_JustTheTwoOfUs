using UnityEngine;

public class RotateWithCurve : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material material;
    public float heightOffset = 0.5f;
    public float angle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //updating y pos to match the curve. Just doing what
        //I did in the shader for the material to the sprite (kind of)
        Vector3 pos = transform.position;
        pos.y = SampleGroundYPos(pos.x) - heightOffset;
        transform.position = pos;


        //rotating to match the curve
        float slope = SampleGroundSlope(transform.position.x);
        angle = Mathf.Atan(slope) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private float SampleGroundYPos(float x)
    {
        float offsetX = x - material.GetFloat("_PlayerOffset");
        return Mathf.Pow(offsetX, 2) * material.GetFloat("_CurveStrength");


    }

    private float SampleGroundSlope(float x)
    {
        float offsetX = x - material.GetFloat("_PlayerOffset");
        return 2 * offsetX * material.GetFloat("_CurveStrength");
    }
}
