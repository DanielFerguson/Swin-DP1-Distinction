using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour {

    // Base resource directory paths
    private static string accSprite = "Sprites/Characters/ACC";
    private static string csSprite = "Sprites/Characters/CS";
    private static string medSprite = "Sprites/Characters/MED";
    private static string teaSprite = "Sprites/Characters/TEA";

    // Base Classes
    public class BaseClass {
        public readonly string _spriteLocation;
        public readonly float _speed;
        public readonly int _level;
        public readonly int _debtAdd;
        public readonly int _creditsReq;

        public BaseClass(string Sprite, float Speed, int Level, int DebtAdd, int CreditsRequired) {
            _spriteLocation = Sprite;
            _speed = Speed;
            _level = Level;
            _debtAdd = DebtAdd;
            _creditsReq = CreditsRequired;
        }
    }
    public class ClassManager {
        public readonly BaseClass _TAFE;
        public readonly BaseClass _DIPL;
        public readonly BaseClass _BACH;
        public readonly BaseClass _HONR;
        public readonly BaseClass _PHD;

        public readonly string _name;
        public readonly string _acronym;
        
        public ClassManager(string NAME, string ACRO, BaseClass TAFE, BaseClass DIPL, BaseClass BACH, BaseClass HONR, BaseClass PHD)
        {
            _TAFE = TAFE;
            _DIPL = DIPL;
            _BACH = BACH;
            _HONR = HONR;
            _PHD = PHD;
        }
    }

    // Game Classes
    public static ClassManager Accounting = new ClassManager(
        NAME: "Accounting",
        ACRO: "ACC",
        TAFE: new BaseClass(accSprite, 1f, 0, 500, 25),
        DIPL: new BaseClass(accSprite, 3f, 1, 100, 50),
        BACH: new BaseClass(accSprite, 5f, 2, 150, 100),
        HONR: new BaseClass(accSprite, 6f, 3, 150, 150),
        PHD: new BaseClass(accSprite, 8f, 4, 350, 200));

    public static ClassManager ComputerScience = new ClassManager(
        NAME: "Computer Science",
        ACRO: "CS",
        TAFE: new BaseClass(csSprite, 1f, 0, 500, 25),
        DIPL: new BaseClass(csSprite, 2f, 1, 100, 50),
        BACH: new BaseClass(csSprite, 4f, 2, 200, 100),
        HONR: new BaseClass(csSprite, 8f, 3, 100, 150),
        PHD: new BaseClass(csSprite, 13f, 4, 600, 200));

    public static ClassManager Medicine = new ClassManager(
        NAME: "Medicine",
        ACRO: "MED",
        TAFE: new BaseClass(medSprite, 1f, 0, 500, 25),
        DIPL: new BaseClass(medSprite, 1f, 1, 300, 50),
        BACH: new BaseClass(medSprite, 4f, 2, 1000, 100),
        HONR: new BaseClass(medSprite, 11f, 3, 200, 150),
        PHD: new BaseClass(medSprite, 26f, 4, 2000, 200));

    public static ClassManager Teaching = new ClassManager(
        NAME: "Teaching",
        ACRO: "ART",
        TAFE: new BaseClass(teaSprite, 1f, 0, 500, 25),
        DIPL: new BaseClass(teaSprite, 4f, 1, 50, 50),
        BACH: new BaseClass(teaSprite, 5f, 2, 100, 100),
        HONR: new BaseClass(teaSprite, 5f, 3, 100, 150),
        PHD: new BaseClass(teaSprite, 5f, 4, 250, 200));
}
