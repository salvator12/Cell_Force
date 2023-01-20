using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CellForce.Data
{
    [CreateAssetMenu(fileName = "levelData", menuName = "levelData")]
    public class levelData : ScriptableObject
    {
        public SceneAsset level;
        public bool islocked;
    }
}

