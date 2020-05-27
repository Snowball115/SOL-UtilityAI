using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    // The team of this agent
    public Enums.Teams _Team;

    // Civilian or Soldier
    public Enums.AgentRoles _Role;

    // The player to which this agent belongs
    public Player _PlayerOwner;

    // Agent statistics template
    public soAgentStatsTemplate _AgentStats;

    // NavMeshAgent component
    public NavMeshAgent _NavAgent { get; private set; }

    // Utility AI component
    public UtilityAgent _UtilityAgent { get; private set; }

    // Agent senses component
    public AgentSenses _Senses { get; private set; }

    // Agent inventory component
    public AgentInventory _Inventory { get; private set; }

    // Data stored from AgentStats template
    [System.Serializable]
    public struct AgentData
    {
        public float Health;
        public float Attack;
        public float AttackRange;
        public float MoveSpeed;
        public float Food;
        public float Energy;
    };

    public AgentData _AgentData;


    void Awake()
    {
        _NavAgent = GetComponent<NavMeshAgent>();
        _UtilityAgent = GetComponent<UtilityAgent>();
        _Senses = GetComponent<AgentSenses>();
        _Inventory = GetComponent<AgentInventory>();
    }

    void Start()
    {
        // Assign values from the template to the data
        _AgentData.Health = _AgentStats.HealthPoints;
        _AgentData.Attack = _AgentStats.AttackPoints;
        _AgentData.AttackRange = _AgentStats.AttackRange;
        _AgentData.MoveSpeed = _AgentStats.MoveSpeed;
        _AgentData.Food = _AgentStats.FoodPoints;
        _AgentData.Energy = _AgentStats.EnergyPoints;

        _NavAgent.speed = _AgentData.MoveSpeed;

        // Change material colour depending on the player team
        if (_Team == Enums.Teams.BLUE) GetComponent<MeshRenderer>().material.color = Color.blue;
        else GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        // Slowly consume food (only civilians)
        if (_Role == Enums.AgentRoles.CIVILIAN && _AgentData.Food > 0) _AgentData.Food -= Time.deltaTime * 0.35f;

        //if (_AgentData.Energy > 0) _AgentData.Energy -= 0.02f;
    }

    // Agent eats food
    public void EatFood()
    {
        while (_AgentData.Food <= 100.0f && _PlayerOwner._PlayerInventory.FoodCount > 0)
        {
            _AgentData.Food++;
            _PlayerOwner.RemoveFromInventory(Enums.ResourceType.FOOD);
        }
    }

    // Heal agent
    public void Heal()
    {
        if (_AgentData.Health < _AgentStats.HealthPoints)
        {
            _AgentData.Health += 1.0f;
        }
    }

    // Attack enemy soldier or building
    public void Attack(float attackPower, GameObject target)
    {
        if (target.GetComponent<Building>()) target.GetComponent<Building>().GetDamaged(attackPower);

        else target.GetComponent<AgentController>().GetHurt(attackPower);
    }

    // Retrieve damage
    public void GetHurt(float damage)
    {
        _AgentData.Health -= damage;

        if (_AgentData.Health <= 0) Die();
    }

    // Destroy agent on death (also remove from agent manager and player agents list)
    private void Die()
    {
        _UtilityAgent._AgentManager.RemoveAgent(_UtilityAgent);
        _PlayerOwner._PlayerAgents.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
