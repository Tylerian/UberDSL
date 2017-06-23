using UIKit;
using System.Collections.Generic;
using System.Text;

namespace UberDSL
{
    class TestShit
    {
        public void Test()
        {
            var viewA = new UIView();
            var viewB = new UIView();
            var viewC = new UIView();

            UberDSL.Constrain(viewA, viewB, (viewa, viewb) =>
            {
                viewa.Top.Equal(viewb.Left + 25);
            });


        }
    }
}
