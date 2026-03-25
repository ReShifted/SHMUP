using UnityEngine;
using System.Collections.Generic;

public class FollowParent : MonoBehaviour
{
    public BossMovementTest head;
    public FollowParent parent;

    public int wait = 60;
    public float speed = 10f;

    private List<Vector3> history = new List<Vector3>();
    public int max = 1000;

    void Update()
    {
        history.Insert(0, transform.position);

        if (history.Count > max)
        {
            history.RemoveAt(history.Count - 1);
        }

        Vector3 target = transform.position;

        if (parent != null && parent.history.Count > wait)
        {
            target = GetPos(parent.history, wait);
        }
        else if (head != null && head.positionHistory.Count > wait)
        {
            target = GetPos(head.positionHistory, wait);
        }

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    Vector3 GetPos(List<Vector3> list, int wait)
    {
        int i = Mathf.Clamp(wait, 0, list.Count - 1);
        int j = Mathf.Clamp(wait + 1, 0, list.Count - 1);

        Vector3 a = list[i];
        Vector3 b = list[j];

        float t = 0.5f;

        return Vector3.Lerp(a, b, t);
    }
}