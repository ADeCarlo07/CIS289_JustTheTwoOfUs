using UnityEngine;

public class HideFollow : MonoBehaviour
{
    public bool rotateFollow;
    public GameObject desiredTarget;
    public Material material;
    public Material material02;
    //public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnApplicationQuit()
    {
        material.SetFloat("_PlayerOffset", 0);
        material02.SetFloat("_PlayerOffset", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (rotateFollow)
        {
            transform.position = desiredTarget.transform.position;
        }
        else
        {
            Vector3 objectTransform = transform.position;
            Vector3 characterTransform = GameManager.instance.getTargetPlayer().transform.position;
            objectTransform.x = characterTransform.x;
            transform.position = objectTransform;
            //transform.position = gameManager.getTargetPlayer().transform.position;
        }

    }
}
