using System;

public class LibrariesContainer
{
    /*public static LibrariesContainer instance;

    void Awake()
    {
        instance = this;
        instance.Initialize();
    }*/

    public PrefabLibrary prefabLibrary;
    public SpriteLibrary spriteLibrary;
    public CardBaseLibrary cardLibrary;

    internal void Initialize()
    {
        prefabLibrary = new PrefabLibrary();
        prefabLibrary.Initialize();

        spriteLibrary = new SpriteLibrary();
        spriteLibrary.Initialize();

        cardLibrary = new CardBaseLibrary();
        cardLibrary.Initialize();
    }
}