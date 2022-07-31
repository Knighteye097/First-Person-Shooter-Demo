using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestructionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _destructibleCrate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHittingCrate()
    {
        Instantiate(_destructibleCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
