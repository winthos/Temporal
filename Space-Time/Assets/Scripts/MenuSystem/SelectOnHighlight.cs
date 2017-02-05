using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class SelectOnHighlight : EventTrigger
{
  public override void OnSelect(BaseEventData data)
  {
    this.gameObject.GetComponent<Button>().OnSubmit(data);
  }
}