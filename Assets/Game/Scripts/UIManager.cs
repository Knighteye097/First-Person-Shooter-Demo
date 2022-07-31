using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoDisplay;

    [SerializeField]
    private GameObject _coinImage;

    [SerializeField]
    private GameObject _crossHair;
    // Start is called before the first frame update
    void Start()
    {
        ammoDisplay.text = "Ammo: " + 0;
        _coinImage.SetActive(false);
        _crossHair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ammoDisplayUpdate(float ammo)
    {
        ammoDisplay.text = "Ammo: " + ammo;
    }

    public void coinImageDisplayActive()
    {
        _coinImage.SetActive(true);
    }

    public void coinImageDisplayDisabled()
    {
        _coinImage.SetActive(false);
    }

    public void setCrossHairActive()
    {
        _crossHair.SetActive(true);
    }
}
