using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ExitDoors : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text goalText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private int requiredPoints = 4;
    private SpriteRenderer gateRenderer;
    private bool won;

    private void Awake()
    {
        gateRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        winPanel.SetActive(false);
    }

    private void Update()
    {
        if (won) return;
        bool ready = player.GetPoints() >= requiredPoints;
        gateRenderer.color = ready ? Color.green : Color.red;
        goalText.text = ready
            ? "Wyjœcie machen - bramka touchen"
            : "Zbierz " + requiredPoints + " pkt";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (won) return;
        PlayerController visitor =
            other.GetComponentInParent<PlayerController>();
        if (visitor != player) return;
        if (player.GetPoints() < requiredPoints) return;

        won = true;
        goalText.text = "Poziom zjedzony";
        winPanel.SetActive(true);
        player.enabled = false;
        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        body.linearVelocity = Vector2.zero;
        body.simulated = false;
    }
}

