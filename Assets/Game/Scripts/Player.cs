using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    private float _currentAmmo;
    private float _maxAmmo = 100;
    private bool _isReload = false;
    public bool _hasCoin = false;
    private UIManager _uiManager;
    private bool _isWeaponActive = false;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    [SerializeField]
    private AudioSource _weaponShootSound;
    [SerializeField]
    private GameObject _weapon;

    // Start is called before the first frame update
    void Start()
    {
        _weapon.SetActive(false);
        _muzzleFlash.SetActive(false);
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null)
        {
            Debug.Log("UI Manager in Player Script is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (_isWeaponActive == true)
        {
            if (Input.GetMouseButton(0) && _currentAmmo > 0)
            {
                shoot();
            }
            else
            {
                _muzzleFlash.SetActive(false);
                _weaponShootSound.Stop();
            }

            if (Input.GetKeyDown(KeyCode.R) && _isReload == false)
            {
                _isReload = true;
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        calculateMovement();
    }

    void shoot()
    {
        _currentAmmo--;
        _uiManager.ammoDisplayUpdate(_currentAmmo);
        _muzzleFlash.SetActive(true);
        if (_weaponShootSound.isPlaying == false)
        {
            _weaponShootSound.Play();
        }

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Ray has hit:" + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitMarker, 1f);

            BoxDestructionBehaviour crate = hitInfo.transform.GetComponent<BoxDestructionBehaviour>();

            if(crate != null)
            {
                crate.onHittingCrate();
            }
        }
    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 directions = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = directions * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uiManager.ammoDisplayUpdate(_currentAmmo);
        _isReload = false;
    }

    public void setWeaponActive()
    {
        _weapon.SetActive(true);
        _isWeaponActive = true;
        _uiManager.ammoDisplayUpdate(100);
    }
}
