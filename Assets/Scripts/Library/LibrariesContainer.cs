using System;

public class LibrariesContainer
{
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