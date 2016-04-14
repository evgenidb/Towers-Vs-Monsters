using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TowersVsMonsters.GameClasses.UserCommands;
using TowersVsMonsters.GameClasses.UserCommands.Enums;
using TowersVsMonsters.GameClasses.UserCommands.Interfaces;
using static TowersVsMonsters.GameClasses.GameObjectFactory;

namespace TowersVsMonsters.GameClasses
{
    public class MenuBar
    {
        #region Private Properties
        private LinkedList<Bullet> Bullets { get; set; }
        #endregion


        public int BulletsPreviewLength { get; private set; }
        public IEnumerable<Bullet> BulletsPreview
        {
            get
            {
                return Bullets;
            }
        }

        public int AutoDiscardTime { get; private set; }
        public int ShootTimeout { get; private set; }

        private int MenuFrameCounter { get; set; }
        private bool LockMenu { get; set; }
        public bool IsMenuLocked
        {
            get
            {
                var isLocked =
                    LockMenu &&
                    (MenuFrameCounter < ShootTimeout);

                LockMenu = isLocked;

                return isLocked;
            }
        }

        public MenuBar()
        {
            LockMenu = false;
            Bullets = new LinkedList<Bullet>();
            ResetMenuFrameCounter();
        }

        public void SetAutoDiscardTime(int discardTime)
        {
            AutoDiscardTime = discardTime;
            ResetMenuFrameCounter();
        }

        public void SetShootTimeout(int shootTime)
        {
            ShootTimeout = shootTime;
            ResetMenuFrameCounter();
        }

        public void ResetMenuFrameCounter()
        {
            MenuFrameCounter = 0;
        }

        public void SetPreviewLength(int newLength)
        {
            BulletsPreviewLength = newLength;
            // If there are too many bullets
            while (Bullets.Count > newLength)
            {
                RemoveBullet();
            }
            // If there are not enough bullets
            while (Bullets.Count < newLength)
            {
                var randomBullet = RandomBullet();
                AddBullet(randomBullet);
            }
        }

        public void AddBullet(Bullet bullet)
        {
            if (Bullets.Count >= BulletsPreviewLength)
            {
                return;
            }

            Bullets.AddLast(bullet);
        }

        private void RemoveBullet()
        {
            if (Bullets.Count < BulletsPreviewLength)
            {
                return;
            }

            Bullets.RemoveLast();
        }

        public void Update(int currentFrame, IUserCommand command)
        {
            MenuFrameCounter += 1;
            if (IsMenuLocked)
            {
                return;
            }

            if (command?.CommandType == UserCommandType.DiscardBullet)
            {
                var discardCommand =
                    command as DiscardBulletCommand;

                var replacementBullet =
                    discardCommand.ReplacementBullet;

                DiscardBullet(replacementBullet);
                return;
            }

            if (MenuFrameCounter % AutoDiscardTime == 0)
            {
                var replacementBullet = RandomBullet();
                DiscardBullet(replacementBullet);
                return;
            }
        }

        public void DiscardBullet(Bullet replacementBullet)
        {
            GetBullet(replacementBullet);

            Score.UpdateScore(Score.BulletDiscardedPoints);
        }

        public Bullet UseBullet(Bullet replacementBullet)
        {
            if (IsMenuLocked)
            {
                return null;
            }
            ResetMenuFrameCounter();
            LockMenu = true;
            return GetBullet(replacementBullet);
        }

        private Bullet GetBullet(Bullet replacementBullet)
        {
            ResetMenuFrameCounter();

            Bullets.AddLast(replacementBullet);
            var bullet = Bullets.First;
            Bullets.RemoveFirst();
            return bullet.Value;
        }
    }
}
