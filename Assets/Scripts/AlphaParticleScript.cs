using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AlphaParticleScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float limit;
    [SerializeField] private float deflection;
    [SerializeField] private Vector3 centre;
    [SerializeField] private LineRenderer lineRenderer;
    private List<Vector3> positions;
   // [SerializeField] private EnergySliderScript energySlider;
    private Vector3 dir;
    private float speed = 1f;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
        positions.Add(transform.position); // Add initial position
        //rb.velocity = new Vector3(0f,speed,0f);
        initialPosition = transform.position;

        lineRenderer.SetWidth(0.07f,0.07f);
        lineRenderer.startColor = Color.red; // Set starting color
        lineRenderer.endColor = Color.yellow;

        lineRenderer.positionCount = positions.Count; // Set initial position count for line renderer
        lineRenderer.SetPositions(positions.ToArray()); // Set initial positions
    }
    
    public void GiveSpeed(float speed1)
    {
        speed = speed1;
        Debug.Log(speed);
        rb.velocity = new Vector3(0f,speed,0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GoldFoil")
       {
            GetDeflected();
       }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Finish")
       {
        Destroy(gameObject);
       }
    }
    private void GetDeflected()
    {
        dir = centre - transform.position;
            dir.x = - dir.x; 
            dir.x = dir.x * 1.5f;

            if(dir.x < 0)
            {
                dir.x = dir.x - deflection;
            }
            else
            {
                dir.x = dir.x + deflection;
            }

            if(Math.Abs(dir.x) < limit )
            {
                dir.y = - dir.y;
            }
            rb.velocity = dir * speed/3;
    }
    
    void Update()
    {
        positions.Add(transform.position); 
        // Limit the number of positions stored in the list (optional)
        if (positions.Count > 1000) // Example limit of 100 positions
        {   
            positions.RemoveAt(0); // Remove oldest position if exceeding limit
        }

        lineRenderer.positionCount = positions.Count; // Update position count for line renderer
        lineRenderer.SetPositions(positions.ToArray()); // Update positions in the line renderer
    }
    
}
