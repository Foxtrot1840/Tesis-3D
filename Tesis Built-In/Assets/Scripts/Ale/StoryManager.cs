using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
   //[SerializeField] private StoryMoment[] story = new StoryMoment[2];
   [SerializeField] private string[] story = new string[2];
   [SerializeField] private TextMeshProUGUI message;
   private int actualMoment;
   public static StoryManager instance;

   private void Awake()
   {
      if (instance == null) instance = this;
      else Destroy(this);
   }

   private void Start()
   {
      actualMoment = -1;
      ChangeStory();
   }

   public void ChangeStory()
   {
      actualMoment++;
      message.text = story[actualMoment];
      Invoke("TurnOffMessage",3);
   }

   private void TurnOffMessage()
   {
      message.text = "";
   }
   
}
