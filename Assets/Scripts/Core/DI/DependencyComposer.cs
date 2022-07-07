using Core.Enemies;
using Core.Infrastructure;
using Core.Joystick;
using Core.Level;
using Core.UI;
using UnityEngine;

namespace Core.DI
{
    public class DependencyComposer : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private UISceneData _uiSceneData;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private LifecycleContainer _lifecycleContainer;

        private void Awake()
        {
            ComposeDependencies();
        }

        private void ComposeDependencies()
        {
            var moveJoystick = new MoveJoystick(_uiSceneData, _staticData);
            var player = new Player(_sceneData);
            var playerMove = new PlayerMove(player, moveJoystick, _staticData);
            var enemyContainer = new EnemyContainer();
            var enemyFactory = new EnemyFactory(enemyContainer, _staticData);
            var levelLoader = new LevelLoader(_staticData, enemyContainer, enemyFactory, player);
            var enemyBehavior = new EnemyBehavior(enemyContainer, player, _staticData, levelLoader);

            var startWindow = new StartWindow(_uiSceneData, levelLoader);
            var finishWindow = new FinishWindow(_uiSceneData, levelLoader);

            _lifecycleContainer.Add(moveJoystick, playerMove, enemyBehavior, levelLoader, startWindow);
        }
    }
}