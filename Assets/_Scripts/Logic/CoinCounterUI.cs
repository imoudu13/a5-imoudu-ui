using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SeriealizeField] private TextMeshProUGUI current;
    [SeriealizeField] private TextMeshProUGUI toUpdate;
    [SeriealizeField] private Transform coinTextContainer;
    [SeriealizeField] private float duration;
    
    private float containerInitPosition;
    private float moveAmount;
}