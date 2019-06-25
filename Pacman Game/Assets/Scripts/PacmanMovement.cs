using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        //Note: we used GetComponent to access Pac-Man's Rigidbody component. 
        //We then use it to do the movement (we should never use transform.position to move GameObjects that have Rigidbodies).

        bool valid(Vector2 dir)
        {
            // Cast Line from 'next to Pac-Man' to 'Pac-Man' to detect if there was a wall
            //Note: we simply casted the Line from the point next to Pac-Man (pos + dir) to Pac-Man himself (pos).
            Vector2 pos = transform.position;
            RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
            return (hit.collider == GetComponent<Collider2D>());
        }
        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
            //Note: transform.position is casted to Vector2 because this is the only way to compare 
            //or add another Vector2. Also -Vector2.right means left and -Vector2.up means down.
        }
        
    }
}
