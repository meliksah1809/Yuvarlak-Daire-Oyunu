using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEngel2 : MonoBehaviour
{
    private BigEngel bigengel1;
    public SpriteRenderer srr;
    public Color colorMavi;
    public Color colorSarý;
    public Color colorMor;
    public Color colorPembe;
    public float startX = 0f;
    public float endX = 5f;
    private float hiz = 5;
    private bool bittiMi = true;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public string currentColor;
    private Instantiate instantiate;
    public int rastgele_sayi;
    public int sonuc_sayi;
    public Color sonuc_renk;

    void Start()
    {
        bigengel1 = FindObjectOfType<BigEngel>();
        rastgele_sayi = Random.Range(2, 4);
        sonuc_sayi = rastgele_sayi;
        instantiate = FindObjectOfType<Instantiate>();
        srr = GetComponent<SpriteRenderer>();
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);
        transform.position = startPosition;
    }

    void Update()
    {
        srr.tag = bigengel1.tag;
        currentColor = bigengel1.currentColor;
        srr.color = bigengel1.srr.color; // Nesnenin rengini güncelle

        // Hareket yönünü belirleme
        Vector3 hareket = bittiMi ? startPosition : endPosition;

        // Hedefe doðru hareket etme (sadece x ekseni üzerinde)
        float step = bigengel1.sonuc_sayi* Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, hareket, step);

        // Hedefe ulaþýldýðýnda yönü tersine çevirme
        if (transform.position == hareket)
        {
            bittiMi = !bittiMi;
        }
    }
    public void SetRandomColor()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0:
                srr.color = colorMavi;
                currentColor = "Mavi";
                tag = "Mavi";

                break;
            case 1:
                srr.color = colorSarý;
                currentColor = "Sarý";
                tag = "Sarý";

                break;
            case 2:
                srr.color = colorMor;
                currentColor = "Mor";
                tag = "Mor";
                break;
            case 3:
                srr.color = colorPembe;
                currentColor = "Pembe";
                tag = "Pembe";

                break;
        }

    }
}
