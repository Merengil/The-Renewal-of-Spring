using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the petal
/// </summary>
public class PetalController : MonoBehaviour
{
    public GameObject petalGameObject;
    public Transform petal;
    public Transform startPoint;
    public Transform endPoint;
    public Transform player;
    public CharacterController playerController;
    public MeshRenderer petalRenderer;

    /// <summary>
    /// Time to add to the counter (in ms).
    /// </summary>
    public int AddedTimeCounter = 3000;

    private bool isStartGoal = false;
    private Vector3 target;
    private const float speed = 1f;

    //**********************************************************

    // Start is called before the first frame update
    /*void Start()
    {
    }*/

    //**********************************************************

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

    //**********************************************************

    /// <summary>
    /// When colliding with the petal, destroy it and add time to the timer
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerController.IncreaseCounter(AddedTimeCounter);
            Destroy(petalGameObject);
        }
    }

    //**********************************************************

    private Vector3 GetCurrentMvtTarget()
    {
        if (isStartGoal)
            return startPoint.position;
        else
            return endPoint.position;
    }

    //**********************************************************

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
