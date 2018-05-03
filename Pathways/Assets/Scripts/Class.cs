using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour {

    // Base resource directory paths
    private static string acBase = "Sprites/Characters/Accounting/";
    private static string csBase = "Sprites/Characters/ComputerScience/";
    private static string mdBase = "Sprites/Characters/Medicine/";
    private static string teBase = "Sprites/Characters/Teaching/";

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
        TAFE: new BaseClass(GetSpriteLocation(acBase, "AC-TAFE"), 1f, 0, 500, 25),
        DIPL: new BaseClass(GetSpriteLocation(acBase, "AC-DIPL"), 3f, 1, 100, 50),
        BACH: new BaseClass(GetSpriteLocation(acBase, "AC-BACH"), 5f, 2, 150, 100),
        HONR: new BaseClass(GetSpriteLocation(acBase, "AC-HONR"), 6f, 3, 150, 150),
        PHD: new BaseClass(GetSpriteLocation(acBase, "AC-PHD"), 8f, 4, 350, 200));

    public static ClassManager ComputerScience = new ClassManager(
        NAME: "Computer Science",
        ACRO: "CS",
        TAFE: new BaseClass(GetSpriteLocation(csBase, "CS-TAFE"), 1f, 0, 500, 25),
        DIPL: new BaseClass(GetSpriteLocation(csBase, "CS-DIPL"), 2f, 1, 100, 50),
        BACH: new BaseClass(GetSpriteLocation(csBase, "CS-BACH"), 4f, 2, 200, 100),
        HONR: new BaseClass(GetSpriteLocation(csBase, "CS-HONR"), 8f, 3, 100, 150),
        PHD: new BaseClass(GetSpriteLocation(csBase, "CS-PHD"), 13f, 4, 600, 200));

    public static ClassManager Medicine = new ClassManager(
        NAME: "Medicine",
        ACRO: "MED",
        TAFE: new BaseClass(GetSpriteLocation(mdBase, "MD-TAFE"), 1f, 0, 500, 25),
        DIPL: new BaseClass(GetSpriteLocation(mdBase, "MD-DIPL"), 1f, 1, 300, 50),
        BACH: new BaseClass(GetSpriteLocation(mdBase, "MD-BACH"), 4f, 2, 1000, 100),
        HONR: new BaseClass(GetSpriteLocation(mdBase, "MD-HONR"), 11f, 3, 200, 150),
        PHD: new BaseClass(GetSpriteLocation(mdBase, "MD-PHD"), 26f, 4, 2000, 200));

    public static ClassManager Teaching = new ClassManager(
        NAME: "Teaching",
        ACRO: "ART",
        TAFE: new BaseClass(GetSpriteLocation(teBase, "TE-TAFE"), 1f, 0, 500, 25),
        DIPL: new BaseClass(GetSpriteLocation(teBase, "TE-DIPL"), 4f, 1, 50, 50),
        BACH: new BaseClass(GetSpriteLocation(teBase, "TE-BACH"), 5f, 2, 100, 100),
        HONR: new BaseClass(GetSpriteLocation(teBase, "TE-HONR"), 5f, 3, 100, 150),
        PHD: new BaseClass(GetSpriteLocation(teBase, "TE-PHD"), 5f, 4, 250, 200));

    // Internal tools
    private static string GetSpriteLocation(string cBase, string spriteName)
    {
        return string.Concat(cBase, spriteName);
    }
}
