using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject CircleObject;
    public GameObject CircleColor;
    public GameObject ColorChanger;
    public GameObject Engel;
    public GameObject Bengel;
    public GameObject Bengel2;
    public Transform Player;
    private Player player1;
    private EngelHareket engel_hareket;
    void Start()
    {

        player1 = FindObjectOfType<Player>();
        engel_hareket = FindObjectOfType<EngelHareket>();
    }
    void Update()
    {
        Collider2D colorChangerCollider = ColorChanger.GetComponent<Collider2D>();
        colorChangerCollider.enabled = true;
        BoxCollider2D EngelCollider = Engel.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 pos = new Vector3(x: 0f, Player.position.y + 8, z: transform.position.z);
            Vector3 poss = new Vector3(x: 0f, Player.position.y + 10.5f, z: transform.position.z);
            Vector3 engelPos = new Vector3(x: 0f, Player.position.y + 12.3f, z: transform.position.z);
            Vector3 BengelPos = new Vector3(x: 0f, Player.position.y + 14.3f, z: transform.position.z);
            Vector3 BengelPos2 = new Vector3(x: 0f, Player.position.y + 14.3f, z: transform.position.z);
            GameObject yeni_circle = Instantiate(CircleObject, pos, Quaternion.identity);
            GameObject yeni_Changer = Instantiate(ColorChanger, poss, Quaternion.identity);
            GameObject yeni_engel = Instantiate(Engel, engelPos, Quaternion.identity);
            GameObject Byeni_engel = Instantiate(Bengel, BengelPos, Quaternion.identity);
            GameObject Byeni_engel2 = Instantiate(Bengel2, BengelPos2, Quaternion.identity);
            Destroy(gameObject);
        }

    }


}
