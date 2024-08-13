using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionForTilemap : MonoBehaviour
{
    public Vector2 camPos; //vi tri cua camera
    public Vector2 dir; //vector này sẽ lấy hướng từ đối tượng này tới camera

    private void Update()
    {
        camPos = Camera.main.transform.position; //lấy vị trí camera
        dir.x = camPos.x - transform.position.x; //Xác định hướng x từ đối tượng này (gốc) tới camera
        dir.y = camPos.y - transform.position.y; //Xác định hướng y từ đối tượng này (gốc) tới camera

        if(dir.x > 44) //sang phải
        {
            transform.Translate(Vector2.right * 44 * 2);
        }

        if (dir.x < -44) //sang trái
        {
            transform.Translate(Vector2.right * -44 * 2);

        }

        if(dir.y > 26) //đi lên
        {
            transform.Translate(Vector2.up * 26 * 2);
        }

        if (dir.y < -26) //đi xuống
        {
            transform.Translate(Vector2.up * -26 * 2);
        }
    }
}
