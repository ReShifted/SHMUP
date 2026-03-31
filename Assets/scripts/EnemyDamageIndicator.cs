using System.Collections;
using UnityEngine;

public class EnemyDamageIndicator : MonoBehaviour
{
    private Renderer[] renderers;
    private Color[][] originalColors;

    public Color flashcolor = Color.red; // use red so it's obvious
    public float flashduration = 0.05f;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length][];

        for (int i = 0; i < renderers.Length; i++)
        {
            // Make sure each renderer has its own material instance
            Material[] mats = renderers[i].materials;

            originalColors[i] = new Color[mats.Length];

            for (int j = 0; j < mats.Length; j++)
            {
                mats[j] = new Material(mats[j]); // force instance
                originalColors[i][j] = mats[j].color;
            }

            renderers[i].materials = mats;
        }
    }

    public void Flash()
    {
        StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        // Apply flash color
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                mat.color = flashcolor;
            }
        }

        yield return new WaitForSeconds(flashduration);

        // Restore original colors
        for (int i = 0; i < renderers.Length; i++)
        {
            Material[] mats = renderers[i].materials;

            for (int j = 0; j < mats.Length; j++)
            {
                mats[j].color = originalColors[i][j];
            }
        }
    }
}