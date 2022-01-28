using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : CSingletonPersistent<InputManager>
{
    private PlayerControls playerControls; 
    public override void Awake() {
        base.Awake();
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
