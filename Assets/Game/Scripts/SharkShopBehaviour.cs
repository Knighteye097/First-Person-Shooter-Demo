using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShopBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioClip _youWinClip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                
                if(player._hasCoin == true)
                {
                    player._hasCoin = false;
                    player.setWeaponActive();
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if(uiManager != null)
                    {
                        uiManager.coinImageDisplayDisabled();
                        uiManager.setCrossHairActive();
                    }
                    AudioSource.PlayClipAtPoint(_youWinClip, transform.position, 1f);
                }

                else
                {
                    Debug.Log("Get Out of here!");
                }
            }
        }   
    }
}
