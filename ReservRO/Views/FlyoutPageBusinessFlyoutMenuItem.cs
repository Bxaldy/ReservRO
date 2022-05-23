using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservRO.Views
{
    public class FlyoutPageBusinessFlyoutMenuItem
    {
        public FlyoutPageBusinessFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutPageBusinessFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}