//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float rotate;
    public float rotateSpeed;
    int i = -1;

    public List<WeaponBase> gunList;
    public GameObject player;
    public GameObject shotSpawn;
    private Rigidbody rb;
    Transform playerTransform;
    public Transform shotSpawn;
    
    void Start()
    {
        gunList = new List<WeaponBase>();
        playerTransform = player.transform;
    }
    void OnTriggerEnter(Collider guns)
    {
        if (guns.CompareTag("Burst") || guns.CompareTag("Single") || guns.CompareTag("Auto"))
        {
            AddToInventory(guns.gameObject.GetComponent<WeaponBase>());
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb = GetComponent <Rigidbody>();

        rotate += moveHorizontal;
        transform.eulerAngles = new Vector3(0.0f, rotate * rotateSpeed, moveHorizontal * tilt);

        if (moveVertical == 1) 
        {
            transform.position += (transform.forward * Time.deltaTime * speed);
        }
        else if(moveVertical == -1)
        {
            transform.position -= (transform.forward * Time.deltaTime * speed);
        }


        GetWeaponsInInventory();

        if (gunList.Count > 0 && i > -1)
        {
            gunList[i].Positioning();

            if(gunList[i].gameObject.name == "Automatic")
            {
                if (Input.GetButton("Fire1"))
                {
                    gunList[i].Fire();
                }

            }
            else if(Input.GetButtonDown("Fire1"))
                gunList[i].Fire();
        }
    }

    public void AddToInventory(WeaponBase guns)
    { 
        guns.gameObject.SetActive(false);
        gunList.Add(guns.gameObject.GetComponent<WeaponBase>());

    }
    public void GetWeaponsInInventory()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            if (gunList.Count > 0 && i < 0)
                i = 0;
                else
                    gunList[i].gameObject.SetActive(false);

            i = 0;
            
            gunList[i].gameObject.SetActive(true);
            shotSpawn.SetActive(true);
            gunList[i].transform.position = playerTransform.position;
            gunList[i].transform.parent = playerTransform;
                
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (gunList.Count > 0 && i < 0)
                i = 1;
            else
                gunList[i].gameObject.SetActive(false);

            i = 1;

            gunList[i].gameObject.SetActive(true);
            shotSpawn.SetActive(true);
            gunList[i].transform.position = playerTransform.position;
            gunList[i].transform.parent = playerTransform;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (gunList.Count > 0 && i < 0)
                i = 2;
            else
                gunList[i].gameObject.SetActive(false);

            i = 2;

            gunList[i].gameObject.SetActive(true);
            shotSpawn.SetActive(true);
            gunList[i].transform.position = playerTransform.position;
            gunList[i].transform.parent = playerTransform;
        }
    }
}
