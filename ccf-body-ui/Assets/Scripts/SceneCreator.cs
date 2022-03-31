using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCreator : MonoBehaviour
{
    [SerializeField] private GameObject pre_TissueBlock;
    // Start is called before the first frame update
    [SerializeField] DataReader dataReader;
    [SerializeField] private NodeArray nodeArray;

    void Start()
    {
        nodeArray = dataReader.nodeArray;
        foreach (var node in nodeArray.nodes)
        {
            if (node.entityId != null)
            {
                GameObject tissueBlock = Instantiate(pre_TissueBlock);
                var position = tissueBlock.transform.position;
                var rotation = tissueBlock.transform.rotation;
                var scale = tissueBlock.transform.localScale;
                var tempMatrix = Matrix4x4.TRS(position, rotation, scale);

                Debug.Log("Before:");
                Debug.Log(position);
                Debug.Log(rotation);
                Debug.Log(scale);
                Debug.Log(tempMatrix);

                Matrix4x4 matrix = CreateMatrix(node);
                Debug.Log(node.entityId);

                position = matrix.ExtractPosition();
                rotation = matrix.ExtractRotation();
                scale = matrix.ExtractScale();

                Debug.Log("After:");
                Debug.Log(position);
                Debug.Log(rotation);
                Debug.Log(scale);
                Debug.Log(tempMatrix);
                
                tissueBlock.transform.position = position;
                tissueBlock.transform.rotation = rotation;
                tissueBlock.transform.localScale = scale;
            }

        }

        // Test();
    }

    Matrix4x4 CreateMatrix(Node node)
    {
        return new Matrix4x4(
            new Vector4(node.transformMatrix[0], node.transformMatrix[1], node.transformMatrix[2], node.transformMatrix[3]),
            new Vector4(node.transformMatrix[4], node.transformMatrix[5], node.transformMatrix[6], node.transformMatrix[7]),
            new Vector4(node.transformMatrix[8], node.transformMatrix[9], node.transformMatrix[10], node.transformMatrix[11]),
            new Vector4(node.transformMatrix[12], node.transformMatrix[13], node.transformMatrix[14], node.transformMatrix[15])
        );
    }

    void Test()
    {
        var position = new Vector3(11, 22, 33);
        var rotation = Quaternion.Euler(10, 20, 30);
        var scale = new Vector3(1, 2, 3);

        Debug.Log("Before:");
        Debug.Log(position);
        Debug.Log(rotation);
        Debug.Log(scale);

        var m = Matrix4x4.TRS(position, rotation, scale);

        position = m.ExtractPosition();
        rotation = m.ExtractRotation();
        scale = m.ExtractScale();

        Debug.Log("After:");
        Debug.Log(position);
        Debug.Log(rotation);
        Debug.Log(scale);
    }
}
