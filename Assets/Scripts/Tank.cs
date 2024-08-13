using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform roadObject;
    public List<Transform> roads = new List<Transform>();
    private int current = 0;

    private Rigidbody2D rb;
    public float speedMove = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current = 0;

        foreach (Transform t in roadObject)
        {
            roads.Add(t);
        }

        transform.position = roads[current].position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (current + 1 < roads.Count)
        {
            if (Vector2.Distance(transform.position, roads[current + 1].position) > 0.2f)
            {
                Vector2 huongNhin = roads[current + 1].position - transform.position;
                float gocXoay = Mathf.Atan2(huongNhin.y, huongNhin.x) * Mathf.Rad2Deg - 90;
                rb.rotation = gocXoay;

                transform.position = Vector2.MoveTowards(transform.position, roads[current + 1].position, speedMove * Time.deltaTime);
            }
            else
            {
                current++;
            }
        }
        else
        {
            Debug.Log("Đã đến nơi"); //thực hiện việc trừ điểm
        }
    }
}