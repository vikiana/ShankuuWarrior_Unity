using System;
using Assets.scripts.data;

public class LevelData 
{
    private BackgroundData  _backgrounds;
    private PowerupSetData  _powerups;
    private PlatformSetData _platforms;

    void initData ()
    {
        // create data structures
        _backgrounds = new BackgroundData();
        _powerups = new PowerupSetData();
        _platforms = new PlatformSetData();
        // initialize data
        //initFromXML(xml);
    }

}
