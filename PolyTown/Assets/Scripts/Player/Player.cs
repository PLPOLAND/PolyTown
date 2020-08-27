﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Zasoby zasoby; // zasoby gracza
    public bool pause = false; // czy Gra jest zapauzowana

    private void Start() {
        pause = false;
        GameObject.Find("SaveMenager").GetComponent<SaveSystem>().tryToLoad();
    }

    public void load(Player p){
        this.zasoby = p.zasoby;
    }
    [Serializable]
    public class PlayerToSave : ISerializable{
        float maxPojemnosc;
        float drewno;
        float woda;
        float jagody;
        float pieniadze;

        public PlayerToSave(){

        }
        public PlayerToSave(SerializationInfo info, StreamingContext ctxt)
        {
            this.pieniadze = (float)info.GetValue("pieniadze", typeof(float));
            this.maxPojemnosc = (float)info.GetValue("maxPojemnosc", typeof(float));
            this.drewno = (float)info.GetValue("drewno", typeof(float));
            this.woda = (float)info.GetValue("woda", typeof(float));
            this.jagody = (float)info.GetValue("jagody", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("pieniadze", this.pieniadze);
            info.AddValue("maxPojemnosc", this.maxPojemnosc);
            info.AddValue("drewno", this.drewno);
            info.AddValue("woda", this.woda);
            info.AddValue("jagody", this.jagody);
        }

        public Player toPlayer(Player p){
            p.zasoby.setPieniadze(this.pieniadze);
            p.zasoby.setDrewno(this.drewno); 
            p.zasoby.setWoda(this.woda); 
            p.zasoby.setJagody(this.jagody); 
            p.zasoby.setMaxPojemnosc(this.maxPojemnosc); 
            return p;
        }
        public void fromPlayer(Player p){
            this.pieniadze = p.zasoby.getPieniadze();
            this.maxPojemnosc = p.zasoby.getPojemnosc();
            this.drewno = p.zasoby.getDrewno();
            this.woda = p.zasoby.getWoda();
            this.jagody = p.zasoby.getJagody();
        }
    }

}
