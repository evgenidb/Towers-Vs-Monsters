using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class Lane
    {
        #region Private Properties
        private HashSet<Monster> MonsterCollection{ get; set; }
        private HashSet<Bullet> BulletCollection { get; set; }
        #endregion


        public static int Length { get; private set; } = 10;

        public IEnumerable<Monster> Monsters
        {
            get
            {
                return MonsterCollection;
            }
        }

        public IEnumerable<Bullet> Bullets
        {
            get
            {
                return BulletCollection;
            }
        }
        public Tower Tower { get; private set; }

        public Lane()
        {
            MonsterCollection = new HashSet<Monster>();
            BulletCollection = new HashSet<Bullet>();
            Tower = new Tower();
        }

        public void ChangeLanesLength(int newLength)
        {
            Length = newLength;

            // Remove all Bullets outside the lane
            MonsterCollection.RemoveWhere(
                monster => !IsInsideLane(monster));

            // Remove all Bullets outside the lane
            BulletCollection.RemoveWhere(
                bullet => !IsInsideLane(bullet));
        }

        public void MoveMonsters()
        {
            foreach (var monster in MonsterCollection)
            {
                monster.LanePosition -= 1;
                if (!IsInsideLane(monster))
                {
                    MonsterCollection.Remove(monster);
                }
            }
            MonsterCollection.RemoveWhere(
                monster => !IsInsideLane(monster));
        }

        public void MoveBullets()
        {
            foreach (var bullet in BulletCollection)
            {
                bullet.LanePosition += 1;
            }
            BulletCollection.RemoveWhere(
                bullet => !IsInsideLane(bullet));
        }

        public void SpawnMonster(Monster monster)
        {
            monster.LanePosition = Length;
            
            // Check if the space is occupied by another bullet
            // Don't add the new one in this case.
            foreach (var otherMonster in MonsterCollection)
            {
                if (otherMonster.LanePosition == monster.LanePosition)
                {
                    return;
                }
            }

            MonsterCollection.Add(monster);
        }

        public void ShootBullet(Bullet bullet)
        {
            bullet.LanePosition = 1;

            // Check if the space is occupied by another bullet
            // Don't add the new one in this case.
            foreach (var otherBullet in BulletCollection)
            {
                if (otherBullet.LanePosition == bullet.LanePosition)
                {
                    return;
                }
            }

            BulletCollection.Add(bullet);
        }

        public bool IsInsideLane(ILaneObject laneObject)
        {
            var lanePosition = laneObject.LanePosition;

            var pastTowerCheck = 0 <= lanePosition;
            var pastLengthCheck = lanePosition <= Length;

            var isInside =
                pastTowerCheck &&
                pastLengthCheck;

            return isInside;
        }

        public void CollisionCheck()
        {
            var gameObjectsToRemove = new HashSet<ILaneObject>();
            
            foreach (var monster in MonsterCollection)
            {
                foreach (var bullet in BulletCollection)
                {
                    if (monster.LanePosition <= bullet.LanePosition)
                    {
                        if (monster.Color == bullet.Color)
                        {
                            gameObjectsToRemove.Add(monster);

                            // Killed a monster => scored
                            Score.UpdateScore(
                                Score.MonsterKilledPoints);
                        }

                        gameObjectsToRemove.Add(bullet);
                    }
                }
            }

            // Remove the objects
            MonsterCollection.RemoveWhere(
                monster => gameObjectsToRemove.Contains(monster));
            BulletCollection.RemoveWhere(
                bullet => gameObjectsToRemove.Contains(bullet));
        }
    }
}
