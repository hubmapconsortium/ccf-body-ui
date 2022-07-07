using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesFinder : MonoBehaviour
{
    public List<Transform> leafArray = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        FindLeaves(this.transform, leafArray);
        foreach (var item in leafArray)
        {
            Debug.Log(item.gameObject.name);
            //item.gameObject.AddComponent<ExplodingViewManager>();
        }



    }

    // Update is called once per frame
    void Update()
    {

    }


    public static List<Transform> FindLeaves(Transform parent, List<Transform> leafArray)
    {
        // Debug.Log(parent.childCount);
        if (parent.childCount == 0)
        {
            // Debug.Log("no children");
            leafArray.Add(parent);
            // Debug.Log(parent.gameObject.name);
        }
        else
        {
            foreach (Transform child in parent)
            {
                FindLeaves(child, leafArray);
                leafArray.Add(parent);
                // Debug.Log(child.gameObject.name);
            }
        }

        return leafArray;
    }
}
