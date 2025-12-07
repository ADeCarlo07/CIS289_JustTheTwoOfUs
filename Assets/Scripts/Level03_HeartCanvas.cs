using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_HeartCanvas : MonoBehaviour
{
    public static Level03_HeartCanvas instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   

    public static void destroyInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }



}
