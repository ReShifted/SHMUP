using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CooldownUI : MonoBehaviour
{
    public float cooldownTime = 1f;
    public KeyCode triggerKey = KeyCode.Q;

    private RectTransform rect;
    private Image img;
    private bool isCoolingDown = false;

    private float startY;
    public float endY = -70f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        img = GetComponent<Image>();

        startY = rect.anchoredPosition.y;

        img.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        if (!isCoolingDown && Input.GetKeyDown(triggerKey))
        {
            StartCoroutine(Cooldown());
        }

        img.color = new Color(1f, 1f, 1f, isCoolingDown ? 1f : 0f);
    }

    IEnumerator Cooldown()
    {
        isCoolingDown = true;

        float timer = 0f;

        while (timer < cooldownTime)
        {
            timer += Time.deltaTime;

            float t = timer / cooldownTime;

            float newY = Mathf.Lerp(startY, endY, t);
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, newY);

            yield return null;
        }

        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, startY);

        isCoolingDown = false;
    }
}