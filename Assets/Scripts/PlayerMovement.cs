using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float Speed = 7f;
    private Rigidbody _rb;
    private float x;
    private Vector2 startPos;
    public float offset;
    private float offsetSave;
    private float offsetRotate;
    private float offsetEnd;
    private GameObject Neck;
    private float t;
    private float a;
    private float b;
    private float rotate;
    private float Timer;
    public bool MovingForwardB;
    public bool MovingToTheSidesB;
    private bool FinishRotationB;
    private bool ObstaclesRotationB;
    private bool ObstRotB;
    private float RotationFinishF;
    public bool DontStart;
    private float[] ComplexityLvlArray = new float[50] {1f, 1.1f, 1.1f, 1.4f, 1.1f, 1.1f, 1.2f, 1.4f, 1.2f, 1.2f,
                                                1.2f, 1.2f, 1.3f, 1.2f, 1.3f, 1.1f, 1.2f, 1.2f, 1.3f, 1.1f,
                                                1.7f, 1.8f, 1.8f, 1.8f, 1.7f, 1.2f, 1.7f, 1.8f, 2, 2.2f,
                                                2.3f, 2.4f, 2f, 1.2f, 1.8f, 2, 2.2f, 2.4f, 2.5f, 2.6f,
                                                2.2f, 1.8f, 2f, 2.1f, 2.2f, 2.4f, 2.5f, 2.6f, 2.8f, 3};
    public int ComplexityLvl;
    void Start()
    {
        ComplexityLvl = SceneManager.GetActiveScene().buildIndex - 1;
        if (PlayerPrefs.GetInt("LevelStart") == 1) DontStart = true;
        offsetRotate = offset;
        Neck = GameObject.Find("Neck").gameObject;
        _rb = GetComponent<Rigidbody>();
        MovingForwardB = true;
        MovingToTheSidesB = true;
    }
    void FixedUpdate()
    {
        if (MovingForwardB)
            if (DontStart)
                MovingForward();
        if (MovingToTheSidesB)
        {
            if (DontStart)
                MovingToTheSides();
        }
        else MovingToTheZeroSides();
        FinishRotation();
        ObstaclesRotation();
    }
    public void RotationFinish()
    {
        FinishRotationB = true;
    }
    void MovingForward()
    {
        Vector3 movement = new Vector3(0f, 0f, ComplexityLvlArray[ComplexityLvl]);
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
    void MovingToTheSides()
    {
        transform.position = new Vector3(offset, transform.position.y, transform.position.z);
        rotate -= offsetEnd - offset;
        Neck.transform.rotation = Quaternion.Euler(0, 0, rotate * 5);
        if (rotate > 0)
        {
            rotate -= Time.fixedDeltaTime * 5f;
        }
        else if (rotate < -0.1)
        {
            rotate += Time.fixedDeltaTime * 5f;
        }
        else rotate = 0;
        offsetEnd = offset;
        if (Input.touchCount > 0.1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    t = 0;
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    offset = 4f * touch.deltaPosition.x * 0.003f + offsetSave;
                    if (offset > 2.5f) offset = 2.5f;
                    if (offset < -2.5f) offset = -2.5f;
                    offsetSave = offset;
                    break;
                case TouchPhase.Ended:
                    if (offset > 2.5f) offset = 2.5f;
                    if (offset < -2.5f) offset = -2.5f;
                    offset = offsetSave;
                    break;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            offset -= Time.deltaTime * 5f;
            offsetSave = offset;
            offsetEnd = offset;
        }
        if (Input.GetKey(KeyCode.D))
        {
            offset += Time.deltaTime * 5f;
            offsetSave = offset;
            offsetEnd = offset;
        }
    }
    void MovingToTheZeroSides()
    {
        rotate -= offsetEnd - offset;
        Neck.transform.rotation = Quaternion.Euler(0, 0, rotate * 5);
        if (rotate > 0)
        {
            rotate -= Time.fixedDeltaTime * 5f;
        }
        else if (rotate < -0.1)
        {
            rotate += Time.fixedDeltaTime * 5f;
        }
        else rotate = 0;
        offsetEnd = offset;
        offset -= Time.deltaTime;
        if (offset > 0)
        {
            offset -= Time.deltaTime * 5f;
        }
        else if (offset < -0.1)
        {
            offset += Time.deltaTime * 5f;
        }
        else offset = 0;
        transform.position = new Vector3(offset, transform.position.y, transform.position.z);
    }

    void FinishRotation()
    {
        if (FinishRotationB)
        {
            print(transform.rotation.y);
            if (transform.rotation.y < 45)
            {
                RotationFinishF += Time.fixedDeltaTime * 0.1f;
                print(RotationFinishF);
                float Rot = Mathf.Lerp(0f, 45f, RotationFinishF);
                print(Rot);
                Quaternion target = Quaternion.Euler(0f, Rot, 0f);
                transform.rotation = target;
            }
            else
            {
                FinishRotationB = false;
            }
        }
    }
    public void ObstRot()
    {
        ObstaclesRotationB = true;
        ObstRotB = true;
    }
    void ObstaclesRotation()
    {
        if (ObstaclesRotationB)
        {
            if(ObstRotB)
            {
                a += Time.deltaTime * 3f;
                float rot = Mathf.Lerp(0f, -30f, a);
                Neck.transform.rotation = Quaternion.Euler(rot, 0f, 0f);
                if (a >= 1)
                {
                    ObstRotB = false;
                    a = 0;
                }
            }
            else
            {
                b += Time.deltaTime * 3f;
                float rot = Mathf.Lerp(-30f, 0f, b);
                Neck.transform.rotation = Quaternion.Euler(rot, 0f, 0f);
                if (b >= 1){
                    ObstaclesRotationB = false;
                    b = 0;
                }
            }
        }
    }
    public void FinishBoost()
    {
        ComplexityLvlArray[ComplexityLvl] = 2.0f;
    }
}