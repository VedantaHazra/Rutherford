using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleusScript : MonoBehaviour
{
    [SerializeField] private Slider protonSlider;
    [SerializeField] private Slider neutronSlider;

    [SerializeField] private List<GameObject> protons;
    [SerializeField] private List<GameObject> neutrons;

    int pno = 0;
    int nno = 0;

    // Start is called before the first frame update
    void Start()
    {
        protonSlider.onValueChanged.AddListener(OnProtonSliderChanged);
        neutronSlider.onValueChanged.AddListener(OnNeutronSliderChanged);

    }

    private void OnProtonSliderChanged(float newProton)
    {
        //Change no. of proton
        int n = (int)(newProton*20);
        Debug.Log(n+" "+ pno);
        if(pno<=n)
        {
            for(int i=0; i< protons.Count; i++)
            {
                if(i<protons.Count)
                {
                    protons[i].SetActive(true);

                }
                
            }
        }
        else
        {
            for(int i=0; i< protons.Count; i++)
            {
                if(i<protons.Count)
                {
                    protons[i].SetActive(false);

                }
            }
        }
        pno = n;

        
        
    }
    private void OnNeutronSliderChanged(float newNeutron)
    {
        //Change no. of neutron
        int n = (int)(newNeutron*20);
        if(nno<=n)
        {
            for(int i=0; i< neutrons.Count; i++)
            {
                neutrons[i].SetActive(true);

                
            }
        }
        else
        {
            for(int i=0; i< neutrons.Count; i++)
            {
                    neutrons[i].SetActive(false);

            }
    }
    nno = n;
}
}
