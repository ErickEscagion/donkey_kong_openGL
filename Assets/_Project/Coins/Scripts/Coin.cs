using System;
using UnityEngine;

namespace _Project.Coins.Scripts
{
    [Serializable]
    public class Coin
    {
        public bool active = true;
        public float size;
        public Color color;
        public Vector2 origin;
    }
}
