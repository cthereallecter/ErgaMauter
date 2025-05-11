# ErgaMauter's Paintings Mod

A custom Terraria mod for tModLoader 2025.3.3.1 that adds beautiful paintings to the game.

## Structure

This mod uses the namespace `ErgaMauter.Content` and follows a structured approach to adding paintings:

- `PaintingSystem.cs` - Central registry for all paintings and their properties
- `BasePaintingItem.cs` - Base class for all painting items
- `PaintingTile.cs` - Tile class that handles all painting placements

## Adding New Paintings

To add a new painting:

1. **Register the painting in PaintingSystem.cs**:
   ```csharp
   RegisterPainting("YourPaintingName", new PaintingData(
       width: 3,  // Width in tiles
       height: 3, // Height in tiles
       rarity: 1, // Item rarity
       mapColor: new Color(100, 100, 150), // Color on map
       value: 500 // Value in copper coins
   ));
   ```

2. **Create a new item class** (e.g., `YourPaintingNamePainting.cs`):
   ```csharp
   public class YourPaintingNamePainting : BasePaintingItem
   {
       public override string PaintingName => "YourPaintingName";

       public override void SetDefaults()
       {
           base.SetDefaults();
           Item.createTile = ModContent.TileType<Tiles.PaintingTile>();
           Item.placeStyle = X; // Increment this for each new painting
       }
   }
   ```

3. **Add localization entries** in `Localization/en-US.hjson`:
   ```
   YourPaintingNamePainting: "Display Name"
   ```
   ```
   YourPaintingNamePainting: "Tooltip description"
   ```

4. **Add texture files**:
   - Create an item texture: `Assets/Textures/Paintings/YourPaintingNameItem.png`
   - Create a tile texture: `Assets/Textures/Paintings/YourPaintingNameTile.png`

## Asset Organization

Textures should be organized as follows:
- `Assets/Textures/Paintings/` - Directory for all painting textures
  - Item textures: `[PaintingName]Item.png` (e.g., `StarryNightItem.png`)
  - Tile textures: `[PaintingName]Tile.png` (e.g., `StarryNightTile.png`)

## Texture Requirements

- **Item textures**: Standard item size (usually 32x32 pixels)
- **Tile textures**: 
  - Size depends on the painting dimensions
  - For a 3x3 painting: 48x48 pixels (3 tiles × 16 pixels per tile)
  - For a 4x3 painting: 64x48 pixels

## Building and Testing

1. Place the mod files in a folder named `ErgaMauter` in your tModLoader Mods folder
2. Build the mod using tModLoader
3. Enable the mod in tModLoader and start the game
4. Craft your paintings at a workbench using canvas and wooden frames