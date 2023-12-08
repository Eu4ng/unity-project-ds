using UnityEngine;
using UnityEngine.UI;

public class CharacterDataUI : PollingUI
{
    /* 컴포넌트 */
    PlayerState m_PlayerState;
    
    [SerializeField] Image[] m_CharacterImages;
    [SerializeField] Text m_CharacterName;
    [SerializeField] Text m_CharacterLevel;

    // Attribute
    [SerializeField] Text m_CharacterAttack;
    [SerializeField] Text m_CharacterDefense;
    [SerializeField] Text m_CharacterMaxHealth;
    [SerializeField] Text m_CharacterAttackSpeed;
    [SerializeField] Text m_CharacterMoveSpeed;

    [SerializeField] UCharacterData m_CharacterData;

    protected override void Awake_Event()
    {
        base.Awake_Event();

        m_PlayerState = GlobalGameManager.Instance.GetPlayerState();
    }

    public void SelectCharacter(int _id)
    {
        m_PlayerState.SelectCharacter(_id);
    }

    protected override void Refresh()
    {
        if (m_PlayerState is null) return;
        m_CharacterData = m_PlayerState.CharacterData;

        foreach (var characterImage in m_CharacterImages)
        {
            characterImage.sprite = m_CharacterData.Definition.Icon;
        }
        
        // Character Data
        if(m_CharacterName)
            m_CharacterName.text = $"{m_CharacterData.Definition.DisplayName}";
        
        if(m_CharacterLevel)
            m_CharacterLevel.text = $"Lv.{m_CharacterData.Level + 1}";

        // Attribute
        if(m_CharacterAttack)
            m_CharacterAttack.text = $"{m_CharacterData.Attribute.Attack:D0}";
        if(m_CharacterDefense)
            m_CharacterDefense.text = $"{m_CharacterData.Attribute.Defense:D0}";
        if(m_CharacterMaxHealth)
            m_CharacterMaxHealth.text = $"{m_CharacterData.Attribute.MaxHealth:D0}";
        if(m_CharacterAttackSpeed)
            m_CharacterAttackSpeed.text = $"{m_CharacterData.Attribute.AttackSpeed:F2}";
        if(m_CharacterMoveSpeed)
            m_CharacterMoveSpeed.text = $"{m_CharacterData.Attribute.MovementSpeed:F2}";
    }
}
