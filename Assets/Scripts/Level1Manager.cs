using UnityEngine;
using UnityEngine.Tilemaps;

public class Level1Manager : MonoBehaviour
{
    //Set things invisible when switching between SpaceDog and SpaceGuy

    public bool upsideDown;
    public bool hidden;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (upsideDown)
        {
            if (GameManager.instance.playingAsSpaceDog())
            {
                hidden = true;
                if (gameObject.GetComponent<MeshRenderer>() != null)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                if (gameObject.GetComponent<TilemapRenderer>() != null)
                {
                    gameObject.GetComponent<TilemapRenderer>().enabled = false;
                }
                foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = false;
                }
                if (gameObject.GetComponent<Collider2D>() != null)
                {
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }
            else
            {
                hidden = false;
                if (gameObject.GetComponent<MeshRenderer>() != null)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                if (gameObject.GetComponent<TilemapRenderer>() != null)
                {
                    gameObject.GetComponent<TilemapRenderer>().enabled = true;
                }
                foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = true;
                }
                if (gameObject.GetComponent<Collider2D>() != null)
                {
                    gameObject.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
        else
        {
            if (GameManager.instance.playingAsSpaceDog())
            {
                if (gameObject.GetComponent<MeshRenderer>() != null)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                if (gameObject.GetComponent<TilemapRenderer>() != null)
                {
                    gameObject.GetComponent<TilemapRenderer>().enabled = true;
                }

                foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = true;
                }
                if (gameObject.GetComponent<Collider2D>() != null)
                {
                    gameObject.GetComponent<Collider2D>().enabled = true;
                }
            }
            else
            {
                if (gameObject.GetComponent<MeshRenderer>() != null)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }

                if (gameObject.GetComponent<TilemapRenderer>() != null)
                {
                    gameObject.GetComponent<TilemapRenderer>().enabled = false;
                }

                foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = false;
                }

                if (gameObject.GetComponent<Collider2D>() != null)
                {
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
          
            }
        }
       
    }
}
