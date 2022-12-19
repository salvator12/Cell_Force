using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CellForce.Model;

namespace CellForce.Data
{
    [CreateAssetMenu(fileName = "PowerUpsData", menuName = "PowerUpsData")]
    public class powerUpsData : ScriptableObject
    {
        public powerUpsType type;
        public Sprite Icon;
        public float durationUse;
        public float chance;
        public float speed;
        public float fireRate;
        public float bulletAmount;
        public float startAngle;
        public float endAngle;
    }
}
