using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{

    public fall_apart break_script;

    [SerializeField] LineRenderer aimLine;
    Vector2 velocity;
    Vector2 startPos;
    Vector2 currentPos;

    public fall_apart partsToShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (partsToShoot.getCount() >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                velocity = (startPos - currentPos) * 1.5f;

                drawLine();
            }
            if (Input.GetMouseButtonUp(0))
            {
                clearLine();
                break_script.BreakApart(velocity);
            }
        }
    }

    private void drawLine()
    {
        Vector3[] positions = new Vector3[15];
        for (int i = 0; i < 15; i++)
        {
            float t = i * 0.05f;
            Vector3 pos = new Vector2(0, 1.1f) + velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;
        }

        aimLine.positionCount = 15;
        aimLine.SetPositions(positions);
    }

    private void clearLine()
    {
        aimLine.positionCount = 0;
    }
}
