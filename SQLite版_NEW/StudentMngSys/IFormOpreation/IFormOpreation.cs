using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJWUIData;

namespace TJWCommon
{
    public delegate void UnDisplayEventHandler(object sender, System.EventArgs e);
    public interface IFormOpreation
    {
        void Clear();

        int InputCheck(DataWork param);

        event UnDisplayEventHandler UnDisplaying;

    }
}
