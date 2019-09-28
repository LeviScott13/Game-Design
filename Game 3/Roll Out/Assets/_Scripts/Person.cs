//Levi Sutton

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : IComparable<Person>
{
    public string names
    {
        get; set;
    }
    public int score
    {
        get; set;
    }
    public Person(string n, int scores)
    {
        names = n;
        score = scores;
    }

    public string toString()
    {
        string text = "  " + names + " " + "\t" + " " + score;
        return text;
    }

    public int CompareTo(Person other)
    {
        return this.score - other.score;
    }
}
