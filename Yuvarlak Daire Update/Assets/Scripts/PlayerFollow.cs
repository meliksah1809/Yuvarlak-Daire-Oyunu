using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;  // Takip edilecek karakterin Transform bileþeni
    public float minYPosition = 0f;  // Kameranýn en altta olabileceði yükseklik sýnýrý
    private Vector3 initialOffset;  // Ýlk pozisyon farký
    private float lastPlayerY;  // Son bilinen oyuncu yüksekliði
    private Player player1;

    void Start()
    {
        player1 = FindObjectOfType<Player>();
        // Ýlk pozisyon farkýný hesapla (karakterin ve arka planýn baþlangýç pozisyonlarý arasýndaki fark)
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height , true);
        initialOffset = transform.position - player.position;
        lastPlayerY = player.position.y;
    }

    void Update()
    {
        // Oyuncunun yüksekliði arttýysa kamerayý yukarý çek
        if (player.position.y > lastPlayerY)
        {
            float newYPosition = player.position.y + initialOffset.y;
            Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);
            transform.position = newPosition;
            lastPlayerY = player.position.y;
        }

        // Kameranýn minimum yükseklik sýnýrýný kontrol et
        if (transform.position.y < minYPosition)
        {
            float newYPosition = minYPosition;
            Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);
            transform.position = newPosition;
        }
    }
}
