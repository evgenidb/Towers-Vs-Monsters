using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersVsMonsters.GameClasses
{
    public class MenuBar
    {
        #region Private Properties
        private LinkedList<Bullet> Bullets { get; set; }
        #endregion


        public int BulletsPreviewLength { get; private set; } = 5;
        public IEnumerable<Bullet> BulletsPreview
        {
            get
            {
                return Bullets;
            }
        }

        public MenuBar()
        {
            Bullets = new LinkedList<Bullet>();
        }

        public void ChangePreviewLength(int newLength)
        {
            BulletsPreviewLength = newLength;
            while (Bullets.Count > newLength)
            {
                RemoveBullet();
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

        public void DiscardBullet(Bullet replacementBullet)
        {
            GetBullet(replacementBullet);
        }

        public Bullet GetBullet(Bullet replacementBullet)
        {
            Bullets.AddLast(replacementBullet);
            var bullet = Bullets.First;
            Bullets.RemoveFirst();
            return bullet.Value;
        }
    }
}
