using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private Transform spawnPoint;    
    [SerializeField] private int spawnInterval = 10;
    [SerializeField] private EnergySliderScript energySlider;
    [SerializeField] private List<GameObject> alphaParticles;
    private float speed = 1f;
     IEnumerator StartInterval()
    {
        while (true)
        {
            speed = 1f;
            speed += energySlider.GetValue() * speed * 4;
            Spawn();
           

            yield return new WaitForSeconds(spawnInterval); // Wait for spawnInterval amount of seconds
        }
    }

    void Start()
    {
        StartCoroutine(StartInterval());
    }
    private void GiveSpeed(GameObject particle)
    {

            AlphaParticleScript script = particle.GetComponent<AlphaParticleScript>();
            //Debug.Log(speed);
            script.GiveSpeed(speed); // Apply new speed to each alpha particle
        
    }
    private void Spawn()
    {
        int n = 0;
        foreach (GameObject alphaParticle in alphaParticles)
        {
            n++;
            GameObject particle = Instantiate(alphaParticle,spawnPoint);
            GiveSpeed(particle);
            spawnPoint.position = new Vector3 (spawnPoint.position.x + 0.5f, spawnPoint.position.y,0f);
        }
        spawnPoint.position = new Vector3 (spawnPoint.position.x - 0.5f * n, spawnPoint.position.y,0f);
    }
}
