using Assets.scripts.GameLogic;
using Assets.scripts.Managers;
using Assets.scripts.Message;
using Assets.scripts.Models;
using Assets.scripts.NetWork.NetClient;
using Assets.scripts.UI;
using Assets.scripts.UI.UIPanels;
using Assets.scripts.Utils;
using C2GNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.scripts.Utils.enums.BattleModeEnum;

namespace Assets.scripts.NetWork.Service
{
    public class MatchService
    {
        private static MatchService _instance;
        public static MatchService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MatchService();

                }
                return _instance;
            }
        }

        BaseUIForm uiMatchWait = null;
        
        public void init()
        {
            MessageCenter.AddMsgListener(MessageType.OnStartMatch, this.OnStartMatch, this);
            MessageCenter.AddMsgListener(MessageType.OnMatchResponse, this.OnMatchResponse, this);
        }

        /**
     * 开始匹配请求
     */
        public void SendStartMatch()
        {
            //LogUtil.log("SendStartMatch");
            var Net = new C2GNetMessage.Builder()
            {
                Request = new NetMessageRequest.Builder()
                {
                    StartMatchReq = new StartMatchRequest.Builder().Build(),
                }.Build()
            }.Build();

            NetGameClient.Instance.SendMessage(Net);

        }


        /** 
         * 开始匹配响应
         */
        private /*async*/ void OnStartMatch(object param)
        {
            var response = param as StartMatchResponse;
            //LogUtil.log("OnStartMatch:{0}", response.result,response.errormsg);
            if (response.Result == Result.Success)
            {
                uiMatchWait = UIManager.GetInstance().ShowUIForms("UIMatchWait") as UIMatchWait;  //打开匹配弹窗
            }
            else
            {
                TipsManager.Instance.showTips(response.Errormsg);
            }
        }

        /**
         * 匹配响应
         */
        public void OnMatchResponse(object param)
        {
            var response = param as MatchResponse;
            //LogUtil.log("OnMatchResponse:{0}", response.result, response.errormsg);
            TipsManager.Instance.showTips(response.Errormsg);
            if (this.uiMatchWait)
            {   //关闭匹配弹窗 
                this.uiMatchWait.Close();
                this.uiMatchWait = null;
            }
            if (response.Result == Result.Success)
            {  //匹配成功
                LocalStorageUtil.RemoveItem(LocalStorageUtil.allFrameHandlesKey);  //清除上一次的帧操作
                GameLogicGlobal.battleMode = BattleMode.Battle;  //设置为对局模式

                User.Instance.room = response.Room;
                RandomUtil.seed = response.Room.RandomSeed;   //设置战斗随机数种子
                                                              //director.loadScene('EnterGameLoad');
                                                              //SoundManager.Instance.PlayMusic(SoundDefine.Music_Select);
            }
        }
    }
}
