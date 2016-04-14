using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowersVsMonsters.GameClasses.Enums;
using TowersVsMonsters.GameClasses.UserCommands;
using TowersVsMonsters.GameClasses.UserCommands.Enums;
using TowersVsMonsters.GameClasses.UserCommands.Interfaces;
using static TowersVsMonsters.GameClasses.GameObjectFactory;
using static TowersVsMonsters.GameClasses.Enums.DifficultyLevel;
using TowersVsMonsters.Utils;

namespace TowersVsMonsters.GameClasses
{
    public class Level
    {
        #region Private Properties
        private List<Lane> laneCollection { get; set; }

        private int monsterSpeedTime;
        private int bulletSpeedTime;

        private int monsterSpawnTime;

        private DifficultyLevel difficultyLevel = Easy;
        #endregion

        public MenuBar Menu { get; set; }

        public IReadOnlyList<Lane> Lanes
        {
            get
            {
                return laneCollection;
            }
        }

        public int LanesLength
        {
            get { return Lane.Length; }
        }

        public int MonsterSpeedTime
        {
            get
            {
                return monsterSpeedTime;
            }

            set
            {
                if (value > 0)
                {
                    monsterSpeedTime = value;
                }
            }
        }

        public int BulletSpeedTime
        {
            get
            {
                return bulletSpeedTime;
            }

            set
            {
                if (value > 0)
                {
                    bulletSpeedTime = value;
                }
            }
        }

        public int MonsterSpawnTime
        {
            get
            {
                return monsterSpawnTime;
            }

            set
            {
                if (value > 0)
                {
                    monsterSpawnTime = value;
                }
            }
        }

        public DifficultyLevel DifficultyLevel
        {
            get
            {
                return difficultyLevel;
            }
        }

        public Level()
        {
            Menu = new MenuBar();
            laneCollection = new List<Lane>();
            SetDifficulty(Easy);
        }

        public void AddLane()
        {
            var lane = new Lane();
            laneCollection.Add(lane);
        }

        public void RemoveLastLane()
        {
            laneCollection.RemoveAt(
                index: laneCollection.Count - 1);
        }

        public void SetLaneCount(int laneCount)
        {
            // Add lanes if there are not enough
            while (Lanes.Count < laneCount)
            {
                AddLane();
            }

            // Remove lanes if there are too many
            while (laneCount < Lanes.Count)
            {
                RemoveLastLane();
            }
        }

        public void SetDifficulty(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                default:
                case Easy:
                    MonsterVariantsCount = 2;
                    MonsterSpeedTime = 5;
                    BulletSpeedTime = 1;
                    MonsterSpawnTime = MonsterSpeedTime * 4;

                    Menu.SetAutoDiscardTime(20);
                    Menu.SetShootTime(40);
                    Menu.SetPreviewLength(5);

                    SetLaneCount(2);
                    break;

                case Normal:
                    MonsterVariantsCount = 3;
                    MonsterSpeedTime = 4;
                    BulletSpeedTime = 1;
                    MonsterSpawnTime = MonsterSpeedTime * 4;

                    Menu.SetAutoDiscardTime(15);
                    Menu.SetShootTime(30);
                    Menu.SetPreviewLength(4);

                    SetLaneCount(3);
                    break;

                case Hard:
                    MonsterVariantsCount = 4;
                    MonsterSpeedTime = 4;
                    BulletSpeedTime = 1;
                    MonsterSpawnTime = MonsterSpeedTime * 3;

                    Menu.SetAutoDiscardTime(10);
                    Menu.SetShootTime(30);
                    Menu.SetPreviewLength(4);

                    SetLaneCount(4);
                    break;
            }
        }

        public void ChangeLanesLength(int newLength)
        {
            foreach (var lane in Lanes)
            {
                lane.ChangeLanesLength(newLength);
            }
        }

        public void Update(int currentFrame, IUserCommand command)
        {
            //  Move Game Objects
            foreach (var lane in Lanes)
            {
                if (currentFrame % MonsterSpeedTime == 0)
                {
                    lane.MoveMonsters();
                }

                if (currentFrame % BulletSpeedTime == 0)
                {
                    lane.MoveBullets();
                }
            }

            //  Update BulletBar
            Menu.Update(
                currentFrame: currentFrame,
                command: command);


            //  Spawn Enemies, Bullets, Etc.
            //      Spawn Monster
            if (currentFrame % MonsterSpawnTime == 0)
            {
                var randomLane =
                    Util.RandomElement(Lanes, Game.RandomGenerator);
                var randomMonster = RandomMonster();
                randomLane.SpawnMonster(randomMonster);
            }

            //      Shoot Bullet
            if (command?.CommandType == UserCommandType.Shoot)
            {
                var shootCommand = (command as ShootCommand);
                if (shootCommand != null)
                {
                    var bullet = shootCommand.Bullet;

                    var laneIndex = shootCommand.LaneIndex;
                    var lane = Lanes[laneIndex];

                    lane.ShootBullet(bullet);
                }
            }


            //  Collision Check
            foreach (var lane in Lanes)
            {
                lane.CollisionCheck();
            }
        }
    }
}
