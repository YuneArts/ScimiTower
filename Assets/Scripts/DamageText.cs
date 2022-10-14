using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    public static DamageText Create(GameObject dmgTextSpawn, Transform spot, int damageAmount)
    {
        GameObject damagePopup = Instantiate(dmgTextSpawn, spot);

        DamageText damageTextPopup = damagePopup.GetComponent<DamageText>();
        damageTextPopup.Setup(damageAmount);

        return damageTextPopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
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

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }
}
