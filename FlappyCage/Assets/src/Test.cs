using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    BoxCollider box;

    byte number;
    float numDot;
    bool b;
    char c;
    string str;
    short s;
    long l;
    byte by;
    uint ui;
    ulong ul;

    int counter;

    // Use this for initialization
    void Start()
    {
        box = GetComponent<BoxCollider>();

        counter = 0;

        number = 10;


        print("number = " + number);
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter % 3 == 0)
        {
            print("number = " + funkyFunc(7));

        }
        else
        {
            print("number = " + funkyFunc(1));
            gameObject.transform.position = new Vector3(number, number * 0.5f, number * 2);
        }

        int index = 0;

        while (index < 5)
        {
            print("Loop time");
            index++;
        }

        index = 0;

        do
        {
            index += 2;
            print(index);
        } while (index < 10);

        for (int i = 0; i < 15; i += 3)
        {
            print("i = " + i);
        }


    }

    int funkyFunc(int n)
    {
      return  number += (byte)n;
    }

}
