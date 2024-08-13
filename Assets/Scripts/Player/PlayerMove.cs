using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public Vector2 direction;
    public float speed = 5f;
    private int current = 0;

    private Vector2 currentDirection;

    public GameObject firework;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("runX", direction.x);
        anim.SetFloat("runY", direction.y);
        anim.SetFloat("velocity", rig.velocity.magnitude);

        if (direction != Vector2.zero)
        {
            currentDirection = direction;
        }

        anim.SetFloat("dirX", currentDirection.x);
        anim.SetFloat("dirY", currentDirection.y);

        direction.Normalize();

        if (Input.GetKeyDown(KeyCode.H))
        {
            var getQ = QuestManager.instance.receivedQuest.Where(x => x.brandStoryID == 2 && x.qip == 1).ToList();
            if (getQ.Count > 0)
            {
                foreach (var x in getQ)
                {
                    x.SetCurrent();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            float posX = Random.Range(transform.position.x - 1, transform.position.x + 1);
            float posY = Random.Range(transform.position.y - 0.5f, transform.position.y + 0.5f);
            Vector3 pos = new Vector3(posX, posY, transform.position.z);

            FloatDMG.instance.Show(Random.Range(100, 200), pos);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            EditorApplication.isPlaying = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CinemachineCameraShake.instance.ShakeCamera(3f, .2f);
            firework.SetActive(true);
            firework.transform.parent = null;
            firework.GetComponent<CircleCollider2D>().enabled = true;
            StartCoroutine(delayFirework());
        }
    }

    IEnumerator delayFirework()
    {
        yield return new WaitForSeconds(3f);
        firework.GetComponent<CircleCollider2D>().enabled = false;
        firework.transform.parent = transform;
        transform.localPosition = Vector3.zero;
        firework.SetActive(false);
    }

    private void FixedUpdate()
    {
        rig.velocity = direction * speed;
    }

    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    public void PlayerAnimation()
    {
        if (rig.velocity.magnitude > 0)
        {
            if (direction.x > 0 && direction.y == 0) { anim.Play("PlayerRunE"); current = 1; }
            if (direction.x > 0 && direction.y > 0) { anim.Play("PlayerRunNE"); current = 2; }
            if (direction.x > 0 && direction.y < 0) { anim.Play("PlayerRunSE"); current = 3; }

            if (direction.x < 0 && direction.y == 0) { anim.Play("PlayerRunW"); current = 4; }
            if (direction.x < 0 && direction.y > 0) { anim.Play("PlayerRunNW"); current = 5; }
            if (direction.x < 0 && direction.y < 0) { anim.Play("PlayerRunSW"); current = 6; }

            if (direction.x == 0 && direction.y > 0) { anim.Play("PlayerRunN"); current = 7; }
            if (direction.x == 0 && direction.y < 0) { anim.Play("PlayerRunS"); current = 8; }
        }
        else
        {
            switch (current)
            {
                case 1: anim.Play("PlayerStaticE"); break;
                case 2: anim.Play("PlayerStaticNE"); break;
                case 3: anim.Play("PlayerStaticSE"); break;
                case 4: anim.Play("PlayerStaticW"); break;
                case 5: anim.Play("PlayerStaticNW"); break;
                case 6: anim.Play("PlayerStaticSW"); break;
                case 7: anim.Play("PlayerStaticN"); break;
                case 8: anim.Play("PlayerStaticS"); break;
            }
        }
    }
}