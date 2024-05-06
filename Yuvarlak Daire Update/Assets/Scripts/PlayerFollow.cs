using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;  // Takip edilecek karakterin Transform bile�eni
    public float minYPosition = 0f;  // Kameran�n en altta olabilece�i y�kseklik s�n�r�
    private Vector3 initialOffset;  // �lk pozisyon fark�
    private float lastPlayerY;  // Son bilinen oyuncu y�ksekli�i
    private Player player1;

    void Start()
    {
        player1 = FindObjectOfType<Player>();
        // �lk pozisyon fark�n� hesapla (karakterin ve arka plan�n ba�lang�� pozisyonlar� aras�ndaki fark)
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height , true);
        initialOffset = transform.position - player.position;
        lastPlayerY = player.position.y;
    }

    void Update()
    {
        // Oyuncunun y�ksekli�i artt�ysa kameray� yukar� �ek
        if (player.position.y > lastPlayerY)
        {
            float newYPosition = player.position.y + initialOffset.y;
            Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);
            transform.position = newPosition;
            lastPlayerY = player.position.y;
        }

        // Kameran�n minimum y�kseklik s�n�r�n� kontrol et
        if (transform.position.y < minYPosition)
        {
            float newYPosition = minYPosition;
            Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);
            transform.position = newPosition;
        }
    }
}
