using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{
    public GameObject pickupFrag;
    public GameObject scoreObj;
    public GameObject timerObj;
    Timer timer;
    Score score;

    // Use this for initialization
    void Start()
    {
        // check what gameplay mode this is
        // assign an int accordingly
        MovePickup(2, 2, 2);
        timer = timerObj.GetComponent<Timer>();
        score = scoreObj.GetComponent<Score>();
    }

    /// <summary>
    /// generate a random x, y, and z that are not where (x, y, z) is
    /// </summary>
    /// <returns></returns>
    public int[] RandomCoords(int x, int y, int z)
    {
        int[] result = new int[3];
        do
        {
            result[0] = Random.Range(1, 4);
            result[1] = Random.Range(1, 4);
            result[2] = Random.Range(1, 4);
        } while (result == new int[3] { x, y, z });        
        return result;
    }

    /// <summary>
    /// Move Pickup to random location, avoiding x, y, z
    /// </summary>
    /// <param name="coords"></param>
    public void MovePickup(int x, int y, int z)
    {
        int[] coords = RandomCoords(x, y, z);
        transform.position = new Vector3(coords[0], coords[1], coords[2]);
    }

    /// <summary>
    /// Move Pickup to x, y, z
    /// </summary>
    /// <param name="coords"></param>
    public void MovePickupTo(int x, int y, int z)
    {
        transform.position = new Vector3(x, y, z);
    }

    /// <summary>
    /// instantiate fragments where pickup was collected, and move pickup somewhere else
    /// </summary>
    void PickupCollected()
    {
        Instantiate(pickupFrag, transform.position, Quaternion.identity); // instantiate fragments where pickup is
        MovePickup((int)transform.position.x, (int)transform.position.y, (int)transform.position.z); // jump to another location
        score.AddScore();
        timer.AddTime();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") 
            PickupCollected();   
    }
}
