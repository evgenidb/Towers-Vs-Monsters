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
        public static int Length { get; private set; } = 10;

        public HashSet<Monster> Monsters { get; private set; }
        public HashSet<Bullet> Bullets { get; private set; }
        public Tower Tower { get; private set; }

        public Lane()
        {
            Monsters = new HashSet<Monster>();
            Bullets = new HashSet<Bullet>();
            Tower = new Tower();
        }

        public void ChangeLanesLength(int newLength)
        {
            Length = newLength;

            // Remove Monsters all out of the lane
            foreach (var monster in Monsters)
            {
                if (true)
                {
                    Monsters.Remove(monster);
                }
            }

            // Remove Bullets all out of the lane
            foreach (var bullet in Bullets)
            {
                if (true)
                {
                    Bullets.Remove(bullet);
                }
            }
        }

        public void MoveMonsters()
        {
            foreach (var monster in Monsters)
            {
                monster.LanePosition -= 1;
                if (!IsInsideLane(monster))
                {
                    Monsters.Remove(monster);
                }
            }
            Monsters.RemoveWhere(
                monster => !IsInsideLane(monster));
        }

        public void MoveBullets()
        {
            foreach (var bullet in Bullets)
            {
                bullet.LanePosition += 1;
            }
            Bullets.RemoveWhere(
                bullet => !IsInsideLane(bullet));
        }

        public void SpawnMonster(Monster monster)
        {
            monster.LanePosition = Length;

            // Check if the space is occupied by another bullet
            // Don't add the new one in this case.
            foreach (var otherMonster in Bullets)
            {
                if (otherMonster.LanePosition == monster.LanePosition)
                {
                    return;
                }
            }

            Monsters.Add(monster);
        }

        public void ShootBullet(Bullet bullet)
        {
            bullet.LanePosition = 1;

            // Check if the space is occupied by another bullet
            // Don't add the new one in this case.
            foreach (var otherBullet in Bullets)
            {
                if (otherBullet.LanePosition == bullet.LanePosition)
                {
                    return;
                }
            }
            
            Bullets.Add(bullet);
        }

        public bool IsInsideLane(ILaneObject laneObject)
        {
            var lanePosition = laneObject.LanePosition;

            var pastTowerCheck = 0 <= lanePosition;
            var pastLengthCheck = lanePosition <= Length;

            return pastTowerCheck && pastLengthCheck;
        }
    }
}
