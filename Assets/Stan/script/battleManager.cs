// using System.Collections;
// using TMPro;
// using UnityEngine;

// public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };

// public class battleManager : MonoBehaviour
// {
//     public GameObject playerPrefab;
//     public GameObject enemyPrefab;

//     public Transform playerBattleStation;
//     public Transform enemyBattleStation;

//     unit playerUnit;
//     unit enemyUnit;

//     public TMP_Text dialogueText;

//     public battleState state;
//     // public AttackEffect attackEffect;
//     public GameObject healEffect;

//     //Declaring audioClips for SFX
//     public AudioSource SFX_AudioSource;
//     public AudioClip lightningSound;
//     public AudioClip fireSound;
//     public AudioClip healSound;
//     //if you want more sounds, just add more of these lines above

//     private string currentMolecule;

//     public void setMolecule(string molecule)
//     {
//         currentMolecule = molecule;
//     }

//     void Start()
//     {
//     Debug.Log("Battle Manager Started");
//     // if (attackEffect == null)
//     //     Debug.LogError("Attack Effect is not assigned.");
//     state = battleState.START;
//     StartCoroutine(SetupBattle());
//     }

//     IEnumerator SetupBattle() 
//     {
//         GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
//         playerUnit = playerGO.GetComponent<unit>();

//         GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
//         enemyUnit = enemyGO.GetComponent<unit>();

//         dialogueText.text = "A "+ enemyUnit.unitName + " will challenge your chemistry knowledge";

//         // playerHUD.SetHUD(playerUnit);
//         // enemyHUD.SetHUD(enemyUnit);

//         yield return new WaitForSeconds(2f);
        
//         state = battleState.PLAYERTURN;
//         playerTurn();
//     }

//     IEnumerator playerAttack()
//     {
//         int dmgModifier = calculateDamageModifier(currentMolecule);

//         if (dmgModifier >= +2)
//         {
//             dialogueText.text = "Your hand overflows with chemical magics!";
//         } 
//         else if (dmgModifier < 0)
//         {
//             dialogueText.text = "You created a simple compound.";
//         } 
//         else 
//         {
//             dialogueText.text = "From your hands come chemical creations";
//         }

//         bool isDead = enemyUnit.TakeDamage(playerUnit.damage + dmgModifier);
//         // attackEffect.TriggerAttackEffect(true); 

//         yield return new WaitForSeconds(0.5f);

//         if(isDead)
//         {
//             state = battleState.WON;
//             // enemyHUD.setHP(0);
//             dialogueText.text = enemyUnit.unitName + " has feinted.";
//             endBattle();
//         } 
//         else
//         {
//             state = battleState.ENEMYTURN;
//             // enemyHUD.setHP(enemyUnit.currentHP); 
//             yield return new WaitForSeconds(2f);
//             StartCoroutine(EnemyTurn());
//         }
//     }

//     IEnumerator playerHeal()
//     {
//         playerUnit.Heal(15);
//         state = battleState.ENEMYTURN;
//         // playerHUD.setHP(playerUnit.currentHP); 
//         dialogueText.text = "You reconsider your options.";

//         // Activate heal effect
//         healEffect.SetActive(true);

//         yield return new WaitForSeconds(2f);
        
//         // Deactivate heal effect
//         healEffect.SetActive(false);

//         StartCoroutine(EnemyTurn());
//     }

//     IEnumerator EnemyTurn()
//     {
//         int dmgModifier = Random.Range(4, -5);

//         if (dmgModifier >= 3)
//         {
//             dialogueText.text = enemyUnit.unitName + " critically strikes!";
//         } 
//         else if (dmgModifier < 0)
//         {
//             dialogueText.text = enemyUnit.unitName + " deals some chip damage.";
//         } 
//         else 
//         {
//             dialogueText.text = enemyUnit.unitName + " lands an attack!";
//         }
        

//         yield return new WaitForSeconds(1f);

//         bool isDead = playerUnit.TakeDamage(enemyUnit.damage + dmgModifier);
//         // playerHUD.setHP(playerUnit.currentHP); 
//         // attackEffect.TriggerAttackEffect(false); 
//         SFX_AudioSource.PlayOneShot(fireSound, 0.2f);
        
//         yield return new WaitForSeconds(1f);
        
//         if(isDead)
//         {
//             state = battleState.LOST;
//             endBattle();
//         } 
//         else 
//         {
//             state = battleState.PLAYERTURN;
//             playerTurn();
//         }
//     }

//     private int calculateDamageModifier(string molecule)
//     {
//         int dmgModifier = 0;
//         switch(molecule)
//         {
//             case "O2":
//             case "HCl":
//             case "NaCl":
//                 dmgModifier = -3;
//                 break;
//             case "H2O":
//                 dmgModifier = -1;
//                 break;
//             case "SO3":
//             case "ClO3":
//             case "NO3":
//             case "CO3":
//                 dmgModifier = +1;
//                 break;
//             case "CH4":
//                 dmgModifier = +3;
//                 break;
//             case "C2H4":
//             case "C2H6":
//                 dmgModifier = +5;
//                 break;
//             case "C3H8":
//                 dmgModifier = +20;
//                 break;
//             default:
//                 dmgModifier = 0;
//                 break;
//         }

//         return dmgModifier;
//     }

//     void endBattle()
//     {
//         if (state == battleState.WON)
//         {
//             dialogueText.text = "You are a great chemist!";
//         } else if (state == battleState.LOST)
//         {
//             dialogueText.text = "Study harder next time.";
//         }
//     }

//     void playerTurn()
//     {
//         dialogueText.text = "Craft a valid molecule to attack";
//         // Move turn token above player's head?
//     }

//     public void onAttackButton()
//     {
//         if (state != battleState.PLAYERTURN)
//             return;

//         StartCoroutine( playerAttack() );
//         SFX_AudioSource.PlayOneShot(lightningSound, 0.1f);
        
//     }

//     public void onHealButton()
//     {
//         if (state != battleState.PLAYERTURN)
//             return;

//         StartCoroutine( playerHeal() );
        
//         SFX_AudioSource.PlayOneShot(healSound, 0.5f);
//     }
// }
