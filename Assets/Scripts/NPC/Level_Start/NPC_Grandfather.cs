using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Grandfather : NPC_Base
{
    private bool isFirst = false;

    private readonly string npc_talk_01 = "马超出操，操场操马。喂马吃马草。马妈妈超操心。炒炒码面,喂马超吃。马超不吃炒马面在操场出马操。吵马妈妈炒炒码面。马妈妈不爽。操起炒码面。骂操场出马操的。马超去吃马草。不知是操场出操的。马超吵了马妈妈。她喂马吃了炒马面。还是炒码面的马妈妈。骂操场出操的。马超他操马，超吵。而喂马超吃了马草。";
    private readonly string player_talk_01 = "爷爷，你这是在干嘛！？";
    private readonly string npc_talk_02 = string.Format("吔屎啦！{0}，你怎么还没有跑！敌军都兵临城下！赶紧拿上<color=red><b>[新手装备]</b></color>跑吧！", PlayerSetting.PlayerName);
    private readonly string player_talk_02 = "爷爷那你呢！？";
    private readonly string npc_talk_03 = "苟利国家生死以 岂能祸福趋避之！这本<color=red><b>[续命秘籍]</b></color>你拿着吧！";
    private readonly string npc_talk_04 = string.Format("{0}快跑吧！", PlayerSetting.PlayerName);

    private readonly string nextText = "下一步";
    private readonly string level = "溜了！溜了！";

    private ButtonClick nextButton = new ButtonClick();

    public override void Talk()
    {
        if (isFirst)
        {
            NPCTalk_04();
        }
        else
        {
            NPCTalk_01();
        }

    }

    void NPCTalk_01()
    {
        nextButton.text = nextText;
        nextButton.onClick = PlayerTalk_01;
        UIManager.Instance.TalkPanel.SetTalk(npcName, npc_talk_01, nextButton);
    }

    void PlayerTalk_01()
    {
        nextButton.onClick = NPCTalk_02;
        UIManager.Instance.TalkPanel.SetTalk(PlayerSetting.PlayerName, player_talk_01, nextButton);
    }

    void NPCTalk_02()
    {
        nextButton.text = level;
        nextButton.onClick =
            () => { isFirst = true; UIManager.Instance.TalkPanel.HidePanel(); };
        ButtonClick btn1 = new ButtonClick() { text = player_talk_02, onClick = NPCTalk_03 };
        UIManager.Instance.TalkPanel.SetTalk(npcName, npc_talk_02, btn1, nextButton);
    }

    void NPCTalk_03()
    {
        UIManager.Instance.TalkPanel.SetTalk(npcName, npc_talk_03, nextButton);
    }

    void NPCTalk_04()
    {
        UIManager.Instance.TalkPanel.SetTalk(npcName, npc_talk_04, nextButton);
    }
}
