using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] TextMeshProUGUI pointText;
    [SerializeField] int pointWhenPickUpCoint = 100;
    int points2;

    PlayerScript playerScript;

    private int point = 0;
    void Start()
    {
        points2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerScript>().addToCoin(pointWhenPickUpCoint);
            //Debug.Log("Eat coin");
            //points2 = points2 + 10;
            //Debug.Log("Point: " + points2);
            //playerScript.addToCoin(pointWhenPickUpCoint);
            Destroy(gameObject, 0.3f);
        }
    }
}
