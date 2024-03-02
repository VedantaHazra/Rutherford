using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour
{
private static int n = 0;
private GameObject managerInstant;
[SerializeField] private GameObject manager;
[SerializeField] UnityEngine.Rendering.Universal.Light2D light;
[SerializeField] Transform spawnPoint;

private void Start()
{
    light.enabled = false;
}
public void ButtonPressed()
{
    if(n==0)
    {
        light.enabled = true;
        manager.SetActive(true);
        n= -1;
    }
    else
    {
        light.enabled = false;
        manager.SetActive(false);
        n = 0;
    }

}


}
