using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealText : MonoBehaviour
{

    public static HealText Create(GameObject healTextSpawn, Transform spot, int healAmount)
    {
        GameObject healPopup = Instantiate(healTextSpawn, spot);

        HealText healTextPopup = healPopup.GetComponent<HealText>();
        healTextPopup.Setup(healAmount);

        return healTextPopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor = new Color(0.1f, 0.9f, 0.15f, 1f);

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        //textColor = textMesh.color;
        textMesh.color = textColor;
        disappearTimer = 0.5f;
    }

    private void Update()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int healAmount)
    {
        textMesh.SetText(healAmount.ToString());
    }
}
