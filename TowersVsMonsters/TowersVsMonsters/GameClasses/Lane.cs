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
        private HashSet<Bullet> BulletsCollection { get; set; }
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
                return BulletsCollection;
            }
        }
        public Tower Tower { get; private set; }

        public Lane()
        {
            MonsterCollection = new HashSet<Monster>();
            BulletsCollection = new HashSet<Bullet>();
            Tower = new Tower();
        }

        public void ChangeLanesLength(int newLength)
        {
            Length = newLength;

            // Remove Monsters all out of the lane
            foreach (var monster in MonsterCollection)
            {
                if (true)
                {
                    MonsterCollection.Remove(monster);
                }
            }

            // Remove Bullets all out of the lane
            foreach (var bullet in BulletsCollection)
            {
                if (true)
                {
                    BulletsCollection.Remove(bullet);
                }
            }
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
            foreach (var bullet in BulletsCollection)
            {
                bullet.LanePosition += 1;
            }
            BulletsCollection.RemoveWhere(
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
            foreach (var otherBullet in BulletsCollection)
            {
                if (otherBullet.LanePosition == bullet.LanePosition)
                {
                    return;
                }
            }

            BulletsCollection.Add(bullet);
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
    }
}
