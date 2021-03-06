using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.scripts.Core.GameLogic;
using Assets.scripts.GameLogic.Managers;
using Assets.scripts.Managers;
using Assets.scripts.Models;
using C2BNet;
using UnityEngine;
using static Assets.scripts.Utils.enums.BattleModeEnum;

namespace Assets.scripts.GameLogic
{
    public class GameCoreLogic:IGameCoreLogic
    {

        public void update(IList<FrameHandle> frameHandles)
        {
            var characterList = CharacterManager.Instance.characterList;

            foreach (FrameHandle fh in frameHandles)
            {
                if (fh.UserId == User.Instance.user.Id)
                {
                    foreach (FrameHandle frameHandle in GameLogicManager.PredictedInput) {
                        if (frameHandle.OpretionId == fh.OpretionId) {
                            GameLogicManager.PredictedInput.Remove(frameHandle);
                        }
                    }
                }
            }


            foreach (var character in characterList) { 
                
                foreach (FrameHandle fh in frameHandles) {
                    if (fh.UserId == character.user.Id)
                    {
                        character.CharacterUpdate(fh);
                    }
                }
            }

            
                



           
        }

        
    }
}
