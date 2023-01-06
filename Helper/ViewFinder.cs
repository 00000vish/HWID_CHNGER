using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWID_CHANGER.Helper
{
    public static class ViewFinder
    {
        private static MetroWindow? _view;
        public static void SetView(MetroWindow view)
        {
            _view = view;
        }

        public static MetroWindow? GetView()
        {
            return _view;
        }
    }
}
