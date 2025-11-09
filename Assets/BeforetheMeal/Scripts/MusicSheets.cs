using System.Collections.Generic;
using UnityEngine;


public class MusicSheets : MonoBehaviour

{
    public enum beattype
    {
        None,
        Single,
        Double,
        Middle
    }

    public List<beattype> level = new();
   
}
