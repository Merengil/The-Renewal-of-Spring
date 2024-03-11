using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalController : MonoBehaviour
{
    public Transform petal;
    public Transform startPoint;
    public Transform endPoint;
    public MeshRenderer petalRenderer;


    private bool isStartGoal = false;
    private Vector3 target;
    private const float speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Ignores rendering if the object isn't in camera view
        if (!petalRenderer.isVisible)
            return;

            target = GetCurrentMvtTarget();
        petal.position = Vector3.Lerp(petal.position, target, speed*Time.deltaTime);
        if ((target - (Vector3)petal.position).magnitude < 0.1)
            isStartGoal = !isStartGoal;
    }

    private Vector3 GetCurrentMvtTarget()
    {
        if (isStartGoal)
            return startPoint.position;
        else
            return endPoint.position;
    }

    /// <summary>
    /// Draws a line to show the path of the sakura petal
    /// </summary>
    private void OnDrawGizmos()
    {
        if (petal != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(petal.transform.position, startPoint.position);
            Gizmos.DrawLine(petal.transform.position, endPoint.position);
        }
    }
}
