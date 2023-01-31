using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject applePreFab;

    public float appleDropDelay = .8f;

    public float leftAndRightEdge = 24f;

    public float changeDirChance = 0.02f;

    public float speed = 20.0f;

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePreFab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }


    }

    void FixedUpdate() {

        if (Random.value < changeDirChance) {
            speed *= -1f;
        }
    }
}
