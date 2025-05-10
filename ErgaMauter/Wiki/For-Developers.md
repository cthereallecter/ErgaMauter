# For Developers

This page is intended for modders and developers who want to understand the code behind Erga Mauter Trials, contribute to the project, or create compatible mods.

## Repository Structure

```
ErgaMauter/
├── Content/
│   ├── Items/
│   │   ├── Accessories/
│   │   │   └── StuddedHoneycomb.cs
│   │   └── Weapons/
│   │       ├── AmethystRiftBlade.cs
│   │       └── FlamingFury.cs
├── build.txt
├── description.txt
└── changelog.txt
```

## Contributing Guidelines

We welcome contributions from the community! If you'd like to contribute:

1. **Fork the Repository**: Create your own fork of the project
2. **Create a Branch**: Make your changes in a new branch
3. **Follow Code Style**: Maintain the existing code style and patterns
4. **Add Comments**: Document your code thoroughly
5. **Test Thoroughly**: Ensure your changes work as expected
6. **Submit a Pull Request**: Describe your changes in detail

## Asset Creation

If you want to create assets for the mod:

- Sprites should be pixel art style consistent with Terraria's aesthetic
- Item sprites should be 32x32 pixels
- Accessory sprites should be 24x24 pixels
- Use a limited color palette similar to vanilla Terraria items

## Compatibility with Other Mods

When developing for compatibility:

- Use appropriate hooks rather than overwriting methods
- Check for the existence of other mods before accessing their content
- Use ModLoader's built-in compatibility functions

## Planned Code Improvements

- Implement a custom buff system
- Refactor weapon code to use inheritance for common functionality
- Improve dust effects system for better visual feedback

---

[Back to Home](Home)