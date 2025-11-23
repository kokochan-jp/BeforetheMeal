using System.Collections.Generic;
using UnityEngine;


public class MusicSheets : MonoBehaviour

{
    public enum beattype
    {
        None,
        Quarter,
        Eighth,
        SecondEighth
    }

    public List<beattype> level = new();
   
}
