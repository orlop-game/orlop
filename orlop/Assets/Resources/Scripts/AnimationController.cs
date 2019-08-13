using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Direction = CommonUtil.Direction;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BaseActor))]
public class AnimationController : MonoBehaviour
{
    /**
 animationmanager:
- gets direction from camera
- movement frames cycle continues in sequence, regardless of direction
- transition frames? ask ayann
- priority:
- specialaction > attack > dash > movement > gem > standing

Effects:
gem equip effect
additional effects (buffs? etc? combat system needs work)
gem effect
combat effects
        
         * **/

    private static Dictionary<Direction, int> _directionToIndex = new Dictionary<Direction, int>
    {
        {Direction.FL, 1},
        {Direction.L, 2},
        {Direction.BL, 3},
        {Direction.B, 4},
        {Direction.BR, 5},
        {Direction.R, 6},
        {Direction.FR, 7},
        {Direction.F, 8},
    };

    private SpriteRenderer _spriteRenderer;
    private BaseActor _baseActor;
    // TODO : animation states, groups, animations (set of sprites)
    // get Ayann to create the sprite objects (slice them and set pivots)
    private Sprite[] _sprites;

    void Awake()
    {
        _spriteRenderer = this.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer;
        _baseActor = this.gameObject.GetComponent("BaseActor") as BaseActor;
    }

    // Start is called before the first frame update
    void Start()
    {
        _sprites = Resources.LoadAll<Sprite>("Images/Sprites/Lily/Lily_Test3");
        //_sprites = LoadNewSpriteList("Assets/Resources/Images/Sprites/Lily/Lily_Test3");
        print("SPRITES: " + _sprites.Length);
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.sprite = _sprites[_directionToIndex[_baseActor.GetDirection()]];
    }
}
