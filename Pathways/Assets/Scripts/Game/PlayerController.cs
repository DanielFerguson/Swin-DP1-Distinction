using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



    [System.Serializable]
    public class PlayerLogicAbstraction
    {

        // UI Elements
        [Header("UI Elements")]
        [SerializeField]
        public Text Course;
        public Text Credits;
        public Text Debt;
        public bool hasWon = false;

        private float playerSpeed = 120f;
        private float rotateSpeed = 120f;

        private Class.ClassManager _playerClass;
        private string playerName;
        private int playerLevel = 0;
        private int playerDebt;
        private int unitCreditsRequired;
        private bool canMove = true;
        internal PlayerChoice _playerChoice;

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public float PlayerSpeed
        {
            get
            {
                return playerSpeed;
            }
        }

        public float RotateSpeed
        {
            get
            {
                return rotateSpeed;
            }
        }

        public int UnitCreditsRequired
        {
            get
            {
                return unitCreditsRequired;
            }
            set
            {
                unitCreditsRequired = value;
            }
        }

        public int PlayerDebt
        {
            get
            {
                return playerDebt;
            }
            set
            {
                playerDebt = value;
            }
        }

        public bool CanMove
        {
            get
            {
                return canMove;
            }
            set
            {
                canMove = value;
            }
        }

        public Class.ClassManager PlayerClass
        {
            get
            {
                return _playerClass;
            }
        }

        public PlayerLogicAbstraction(string name)
        {

            playerName = name;

            // Load selected character choice & class
            LoadPlayerChoice();

            // Load selected class attributes
            SetupPlayer();

        }

        // Game Manager Checks
        public void CheckDegree()
        {
            // Check to see if the player has recieved all their units
            if (unitCreditsRequired <= 0)
            {
                // Update Player Level. Also check to see if they have completed their degree
                if (playerLevel < 4) playerLevel++;
                else CheckIfWon();

                // Update Required Unit Credits with degree requirements
                UpdateRequiredUnitCredits(playerLevel);

                // Change UI status of Player degree
                UpdateDegree(playerLevel);
            }
        }

        public void CheckIfWon()
        {
            // Does the player have no debt?
            if (playerDebt <= 0) hasWon = true;

            // Does the player have a PHD and all necessary credits?
            if (playerLevel == 4 && unitCreditsRequired <= 0) hasWon = true;
        }

        public void UpdateRequiredUnitCredits(int _playerLevel)
        {
            int newCreditRequirements = 0;

            // Get Unit Credit Requirements for the next degree level
            switch (_playerLevel)
            {
                // DIPLOMA
                case 1:
                    newCreditRequirements = _playerClass._DIPL._creditsReq;
                    break;

                // BACHELORS
                case 2:
                    newCreditRequirements = _playerClass._BACH._creditsReq;
                    break;

                // HONORS
                case 3:
                    newCreditRequirements = _playerClass._HONR._creditsReq;
                    break;

                // PHD
                case 4:
                    newCreditRequirements = _playerClass._PHD._creditsReq;
                    break;
            }

            unitCreditsRequired += newCreditRequirements;

            // Update UI to reflect new requirements
            Credits.text = "Credits Needed: " + unitCreditsRequired;
        }

        public void UpdateDegree(int _playerLevel)
        {
            switch (_playerLevel)
            {
                case 1:
                    Course.text = "DIPLOMA";
                    playerDebt += _playerClass._DIPL._debtAdd;
                    break;

                case 2:
                    Course.text = "BACHELORS";
                    playerDebt += _playerClass._BACH._debtAdd;
                    break;

                case 3:
                    Course.text = "HONORS";
                    playerDebt += _playerClass._HONR._debtAdd;
                    break;

                case 4:
                    Course.text = "PHD";
                    playerDebt += _playerClass._PHD._debtAdd;
                    break;
            }

            Debt.text = "Debt: " + playerDebt.ToString();
        }

        // Internal Tools
        public void LoadPlayerChoice()
        {
            switch (playerName)
            {
                case "Player 1":
                    // Get Player 1 Class
                    switch (PlayerPrefs.GetString("Player1Class"))
                    {
                        case "Accounting":
                            _playerChoice = PlayerChoice.Accounting;
                            _playerClass = Class.Accounting;
                            break;
                        case "ComputerScience":
                            _playerChoice = PlayerChoice.ComputerScience;
                            _playerClass = Class.ComputerScience;
                            break;
                        case "Medical":
                            _playerChoice = PlayerChoice.Medical;
                            _playerClass = Class.Medicine;
                            break;
                        case "Teaching":
                            _playerChoice = PlayerChoice.Teaching;
                            _playerClass = Class.Teaching;
                            break;
                    }
                    break;

                case "Player 2":
                    // Get Player 2 Class
                    switch (PlayerPrefs.GetString("Player2Class"))
                    {
                        case "Accounting":
                            _playerChoice = PlayerChoice.Accounting;
                            _playerClass = Class.Accounting;
                            break;
                        case "ComputerScience":
                            _playerChoice = PlayerChoice.ComputerScience;
                            _playerClass = Class.ComputerScience;
                            break;
                        case "Medical":
                            _playerChoice = PlayerChoice.Medical;
                            _playerClass = Class.Medicine;
                            break;
                        case "Teaching":
                            _playerChoice = PlayerChoice.Teaching;
                            _playerClass = Class.Teaching;
                            break;
                    }
                    break;
            }
        }

        public void SetupPlayer()
        {
            //    Renderer.sprite = Resources.Load<Sprite>(_playerClass._TAFE._spriteLocation);       // Sprite

            playerLevel = PlayerClass._TAFE._level;                                           // Level
            playerSpeed = playerSpeed * PlayerClass._TAFE._speed;                              // Speed
            PlayerDebt = PlayerClass._TAFE._debtAdd;                                           // Debt
            UnitCreditsRequired = PlayerClass._TAFE._creditsReq;                               // Required Unit Scores
        }


    }
