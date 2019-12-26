using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class AntFollower : MonoBehaviour
{
    public PathCreator myPath;
    float updatePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePos += 5 * Time.deltaTime;
        transform.position = myPath.path.GetPointAtDistance(updatePos);
        Quaternion antRotation = myPath.path.GetRotationAtDistance(updatePos);

        antRotation.x = 0;
        antRotation.y = 0;
        transform.rotation = antRotation;
    }

    public void GetPath(PathCreator newPath) {
        myPath = newPath;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "antDetector") {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown() {
        Destroy(gameObject);
    }
}
