using ReservRO.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservRO.Views
{
    public class FlyoutPage1FlyoutMenuItem
    {
        public FlyoutPage1FlyoutMenuItem()
        {
            TargetType = typeof(FlyoutPage1FlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string ClientName { get; set; } = Utils.LogInUser.FirstName + " " + Utils.LogInUser.LastName;
    }
}