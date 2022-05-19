using Assets.scripts.GameLogic.Models;
using C2GNet;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.scripts.GameLogic.Managers
{
    public class CharacterManager
    {
        private static CharacterManager _instance;
        public static CharacterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CharacterManager();

                }
                return _instance;
            }
        }

        public List<Character> characterList;
        public async  Task CreateCharacter() { 
             
        }
        /**
         * ��ӽ�ɫ
         * @param Creature
         */
        public void AddCharacter(Character character)
        {
            this.characterList.Add(character);
        }

        /**
         * ���
         */
        public void Clear()
        {
            characterList=null;
        }

        /**
         * ������ɫ
         */
        public async void CreateCharacter(NRoom nRoom)
        {
            //let teamArr = TeamType2.Blue == teamType2 ? BattleManager.Instance.MyTeam : BattleManager.Instance.EnemyTeam;
            //let roomUsers = TeamType2.Blue == teamType2 ? User.Instance.room.my : User.Instance.room.enemy;

            //for (let i = 0; i < teamArr.length; i++)
            //{
            //    let characterNode = teamArr[i] as Node;
            //    if (!roomUsers[i])
            //    {
            //        return;
            //    }
            //    let cId = roomUsers[i].cCharacterId;
            //    let characterDefine = DataManager.Instance.characters[cId];

            //    let resource = characterDefine.Resource;
            //    console.log('cId=' + cId + ',resource=' + resource)
            //   let prefab = await LoadResUtil.loadPrefab(resource);
            //    let node = instantiate(prefab) as Node;
            //    characterNode.addChild(node);

            //    //������ɫ
            //    let character = new Creature(teamType2, node, characterDefine, roomUsers[i].user, CreatureType.Character);
            //    CreatureManager.Instance.AddCreature(node, character);
            //    CharacterManager.Instance.AddCharacter(character);
            //    //��ǰ��ɫ
            //    if (BattleGlobal.battleMode == BattleMode.Battle)
            //    {    //�Ծ�ģʽ
            //        if (User.Instance.user.id == character.user.id)
            //        {
            //            BattleManager.Instance.currentCharacter = character;
            //        }
            //    }
            //    else if (BattleGlobal.battleMode == BattleMode.Live)
            //    {    //�ۿ�ֱ��ģʽ
            //        if (BattleGlobal.targetLiveUserId == character.user.id)
            //        {
            //            BattleManager.Instance.currentCharacter = character;
            //        }
            //    }
            //}
        }
    }
}
   