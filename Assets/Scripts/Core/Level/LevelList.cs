using System.Collections.Generic;
using UnityEngine;

namespace Core.Level
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "Game Configs/LevelList", order = 0)]
    public class LevelList : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levels = new List<LevelConfig>();
        public List<LevelConfig> Levels => _levels;
    }
}