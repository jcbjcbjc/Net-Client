using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C2BNet;

namespace Assets.scripts.Core.GameLogic
{
    public interface IGameCoreLogic
    {
        void update(IList<FrameHandle> frameHandles);
    }
}
