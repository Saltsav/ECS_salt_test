# Затраченное время 8-10 часов.

# видео - shorturl.at/cDQW0

# Системы которые не зависят от unity. Вся игровая логика выполняется в этих системах:
EcsSpawnLevelSystem
EcsSpawnPlayerSystem
EcsSetPositionToPlayerSystem
EcsActiveByDistanceSystem
EcsColorTriggerSystem
EcsEnableTriggersSystem
EcsMoveSystem

Системы сервисы:
EcsUnityTimeSystem - данная система зависит от unity в разрезе deltaTime. Необходимо пробросить с сервера время.
EcsUnityInputClickSystem - данная система зависит от unity в разрезе input данных (клик мыши). Необходимо пробросить с сервера input систему.

Cистемы отвечающие за создание/обновление объектов на стороне unity (к логике не имеют отношение):
EcsUnitySpawnObjectSystem
EcsUnityUpdateRotateSystem
EcsUnityUpdatePositionSystem
EcsUnityAnimatorSystem

# Краткое описание проекта.
Создать уровень можно на сцене CreateLevelsScene и серилизовать его в данные SceneData в классе LevelInfoSerialization.
Основная игровая сцена MainScene.

# Прочее
1) В системах логики специально сделан уход от UnityEngine.Vector3 на кастомную V3
2) В проекте не писалась логика плавного поворота юнита.
3) В проекте используется Zenject только для связки StartUpEcs, SceneData, FactoryMonoObject. В системах используется EcsLite.Di
4) Unity 2020.3.13f1


