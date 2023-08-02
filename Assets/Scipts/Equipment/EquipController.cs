using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    [SerializeField]
    public EquiqBehaviour currentBody;
    [SerializeField]
    public EquiqBehaviour currentHead;
    [SerializeField]
    public EquiqBehaviour currentExtra;
    [SerializeField]
    public EquiqBehaviour currentLegs;

    public Body[] myBody;

    public Head[] myHead;

    public Extra[] myExtra;

    public Legs[] myLegs;



    int bodyIndex = -1;
    int headIndex = -1;
    int extraIndex = -1;
    int legsIndex = -1;


    Dictionary<string, EquiqBehaviour> dic_Head = new Dictionary<string, EquiqBehaviour>();
    Dictionary<string, EquiqBehaviour> dic_Body = new Dictionary<string, EquiqBehaviour>();
    Dictionary<string, EquiqBehaviour> dic_Extra = new Dictionary<string, EquiqBehaviour>();
    Dictionary<string, EquiqBehaviour> dic_Legs = new Dictionary<string, EquiqBehaviour>();

    public DataEquip dataEquip;

    //Delegate//
    public static Action<string> changeEquip;

  


    public void Start()
    {
        // Body
        myBody = GameObject.FindObjectsOfType<Body>();
        for (int i = 0; i < myBody.Length; i++)
        {
            myBody[i].gameObject.SetActive(false);
            EquiqBehaviour  equiqBehaviour = myBody[i].GetComponent<EquiqBehaviour>();
            equiqBehaviour.Init(this);
            Data _data = dataEquip.datas.Find(x => x.ID == myBody[i].gameObject.name);
            equiqBehaviour.myData(_data);
            dic_Body[equiqBehaviour.mdata.ID] = equiqBehaviour;

        }
        SwithBody(DataAPIController.instance.GetSlotItem(DataPath.BODY_1));

        // Head
        myHead = GameObject.FindObjectsOfType<Head>();
        for (int i = 0; i < myHead.Length; i++)
        {
            myHead[i].gameObject.SetActive(false);
            EquiqBehaviour equiqBehaviour = myHead[i].GetComponent<EquiqBehaviour>();
            equiqBehaviour.Init(this);
            Data _data = dataEquip.datas.Find(x => x.ID == myHead[i].gameObject.name);
            equiqBehaviour.myData(_data);
            dic_Head[equiqBehaviour.mdata.ID] = equiqBehaviour;

        }
       SwitchHead(DataAPIController.instance.GetSlotItem(DataPath.HEAD_1));

        // Extra
        myExtra = GameObject.FindObjectsOfType<Extra>();
        for (int i = 0; i < myExtra.Length; i++)
        {
            myExtra[i].gameObject.SetActive(false);
            EquiqBehaviour equiqBehaviour = myExtra[i].GetComponent<EquiqBehaviour>();
            equiqBehaviour.Init(this);
            Data _data = dataEquip.datas.Find(x => x.ID == myExtra[i].gameObject.name);
            equiqBehaviour.myData(_data);
            dic_Extra[equiqBehaviour.mdata.ID] = equiqBehaviour;

        }
        SwitchExtra(DataAPIController.instance.GetSlotItem(DataPath.EXTRA_1));

        //Legs
        myLegs = GameObject.FindObjectsOfType<Legs>();
        for (int i = 0; i < myLegs.Length; i++)
        {
            myLegs[i].gameObject.SetActive(false);
            EquiqBehaviour equiqBehaviour = myLegs[i].GetComponent<EquiqBehaviour>();
            equiqBehaviour.Init(this);
            Data _data = dataEquip.datas.Find(x => x.ID == myLegs[i].gameObject.name);
            equiqBehaviour.myData(_data);
            dic_Legs[equiqBehaviour.mdata.ID] = equiqBehaviour;

        }
        SwitchLegs(DataAPIController.instance.GetSlotItem(DataPath.LEGS_1));
    }

    /// Chuyen doi Body
    public void SwithBody(string id)
    {
        bodyIndex++;
        if (bodyIndex == myBody.Length)
            bodyIndex = 0;

        if (currentBody != null)
        {
            currentBody.gameObject.SetActive(false);

        }
        if (id != null && !id.Equals(""))
        {
            currentBody = dic_Body[id];
        }
        else
        {
            currentBody = myBody[bodyIndex];
        }
        DataAPIController.instance.UpdateSlotItem(DataPath.BODY_1, currentBody.mdata.ID, null);
        currentBody.gameObject.SetActive(true);

    }

    /// Chuyen doi Head
    public void SwitchHead(string id)
    {

        headIndex++;
        if (headIndex == myHead.Length)
        {
            headIndex = 0;
        }
        if (currentHead != null)
        {
            currentHead.gameObject.SetActive(false);
        }
        if (id != null && !id.Equals(""))
        {
            currentHead = dic_Head[id];
        }
        else
        {
            currentHead = myHead[headIndex];
        }
        DataAPIController.instance.UpdateSlotItem(DataPath.HEAD_1, currentHead.mdata.ID, null);
        currentHead.gameObject.SetActive(true);
      
    }

    /// Chuyen Doi Extra
    public void SwitchExtra(string id)
    {
        extraIndex++;

        if (extraIndex == myExtra.Length)

        {
            extraIndex = 0;
        }

        if (currentExtra != null)
        {
            currentExtra.gameObject.SetActive(false);
        }
        if (id != null && !id.Equals(""))
        {
            currentExtra = dic_Extra[id];
        }
        else
        {
            currentExtra = myExtra[extraIndex];
        }
        DataAPIController.instance.UpdateSlotItem(DataPath.EXTRA_1, currentExtra.mdata.ID, null);
        currentExtra.gameObject.SetActive(true);

    }

    /// Chuyen doi Legs
    public void SwitchLegs(string id)
    {
        legsIndex++;
        if (legsIndex == myLegs.Length)
        {
            legsIndex = 0;
        }
        if (currentLegs != null)
        {
            currentLegs.gameObject.SetActive(false);
        }
        if (id != null && !id.Equals(""))
        {
            currentLegs = dic_Legs[id];
        }
        else
        {
            currentLegs = myLegs[legsIndex];
        }
        DataAPIController.instance.UpdateSlotItem(DataPath.LEGS_1, currentLegs.mdata.ID, null);
        currentLegs.gameObject.SetActive(true);
    }

    public void OnSwithEquip()
    {
        changeEquip = (string newEquip) => { changeEquip?.Invoke(newEquip); };

    }

}
public enum TypeEquip
{
    Body,
    Head,
    Extra,
    Legs

}