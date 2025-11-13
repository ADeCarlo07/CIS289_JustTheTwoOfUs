using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Image ammoBar;
    public int curAmmo;
    private int maxAmmo = 5;

    private void Start()
    {
        curAmmo = maxAmmo;
    }


    private void UpdateAmmoBar()
    {
        float fill = (float)curAmmo / maxAmmo;
        ammoBar.fillAmount = fill;

    }

    public void RemoveAmmo(int damage)
    {

        curAmmo -= damage;

        //ensures everything stays in valid range
        curAmmo = Mathf.Clamp(curAmmo, 0, maxAmmo);
        UpdateAmmoBar();
    }

    public void AddAmmo(int healthAdded)
    {
        curAmmo += healthAdded;

        curAmmo = Mathf.Clamp(curAmmo, 0, maxAmmo);
        UpdateAmmoBar();


    }
}
