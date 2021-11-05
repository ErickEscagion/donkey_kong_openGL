using System;
using UnityEngine;

namespace Project.Core.Scripts
{
    [Serializable]
    public class Enemy
    {
        public string name;
        public int lastPointIndex;
        public float animationTime ;
        public float size;
        public Color color;
        public Vector2 origin;
        public Vector2[] points;
    }
}
