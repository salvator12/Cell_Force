using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CellForce.Data
{
    [CreateAssetMenu(fileName = "StageData", menuName = "StageData")]
    public class StageData : ScriptableObject
    {
        public string nameStage;
        public List<levelData> levelStage;
        public List<powerUps> powerUps;
    }
}

