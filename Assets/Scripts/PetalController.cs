using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the petal
/// </summary>
public class PetalController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public MeshRenderer petalRenderer;
    public GameObject player;

    /// <summary>
    /// Time to add to the counter (in s).
    /// </summary>
    public float AddedTimeCounter = 3;

    private bool isStartGoal = false;
    private Vector3 target;
    private const float speed = 1f;
    private Transform petal;

    /// <summary>
    /// A static variable pointing at the player controller.
    /// If null it'll be initialized.
    /// </summary>
    static private PlayerController playerController = null;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        petal = transform.GetChild(0).GetComponent<Transform>();
    }

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
        if (other.transform == player.transform)
        {
            GetPlayerController().IncreaseCounter(AddedTimeCounter);
            Destroy(gameObject);
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

    //**********************************************************

    /// <summary>
    /// Method that keeps a constant reference to the player controller.
    /// </summary>
    /// <returns></returns>
    private PlayerController GetPlayerController()
    {
        if (playerController == null)
            playerController = player.GetComponent<PlayerController>();
        return playerController;
    }
}
