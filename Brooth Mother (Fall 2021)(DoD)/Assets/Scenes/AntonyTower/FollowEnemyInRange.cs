using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyInRange : MonoBehaviour
{

    public string followableTag;
    public float minimumRange;
    // Start is called before the first frame update
    void Start()
    {
        try {

            testTagExistance(followableTag);
        } catch (UnityException ex) {
                followableTag = null;
        }
    }


    private void testTagExistance(string tag) {
         GameObject.FindWithTag(tag);
    }

    // Update is called once per frame
    void Update()
    {

        if (followableTag == null) {
            throw new UnityException("Followable tag does not exist");
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag(followableTag);

        float detectDistance = 10000f;
        GameObject closest = null;


        foreach (GameObject obj in objects) {
            Transform otherTransform = obj.transform;
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            if (distance < minimumRange)
                continue;


            if (distance < detectDistance) {
                closest = obj;
                detectDistance = distance;
            }
        }

        if (closest != null) {
           // followObject(closest);
        }
        
        
    }

    void followObject(GameObject obj) {

        Vector3 direction = (obj.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);

    }


 
}
