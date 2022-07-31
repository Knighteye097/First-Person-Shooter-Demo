using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickUpAudio;
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
                player._hasCoin = true;
                UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                uiManager.coinImageDisplayActive();
                AudioSource.PlayClipAtPoint(_coinPickUpAudio, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
