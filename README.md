# ChangelogPanelRust

> Vanilla Rust decompiled source — reference stubs for `ChangelogPanel` and `ChangelogButton`.

This repository serves as a **reference base** for building a custom [Carbon](https://carbonmod.gg) plugin that replicates the vanilla Rust in-game changelog UI for **personal or custom gamemode servers**.

---

## What this is

Rust ships a built-in changelog panel tied to its `BaseGameMode` system. The button appears at the bottom of the HUD when a gamemode (e.g. `hardcore`, `softcore`, `primitive`) is active, shows the mode's shortname, and opens a panel listing what was **added**, **removed**, and **changed** for that mode.

This repo contains the decompiled client-side stubs of those two classes — extracted from `Assembly-CSharp.dll` via dnSpy — as a clean starting point for reimplementing the same UI in a Carbon server plugin using LUI (Lightweight UI).

---

## Planned plugin — `ChangelogPanel` for Carbon

The target plugin built on top of these stubs will:

| Feature | Details |
|---------|---------|
| **HUD Button** | Persistent bottom-of-screen button matching the vanilla style; shows the configured gamemode shortname |
| **Changelog Panel** | Full in-game overlay with tabbed sections matching Facepunch's own changelog format |
| **Sections** | ✦ Features · ▲ Improvements · ✔ Fixed · ⚠ Known Issues · ✖ Removed |
| **Config-driven** | All entries (patch name, date, per-section lists) defined in a JSON config — no recompile needed |
| **Carbon LUI** | Built with Carbon's Lightweight UI framework; no Oxide dependency |
| **Commands** | `/changelog` chat command + `clp.open` / `clp.close` console commands |

### Default config example (Hardcore mode)

```json
{
  "Patch Name": "Hardcore Refresh",
  "Gamemode Shortname": "hardcore",
  "Features": [
    "Limit of 5 sleeping bags + beds",
    "Fog of war on map"
  ],
  "Removed": [
    "Contact system", "Team system", "Compass UI",
    "Safe zones", "MLRS", "Firearm crafting"
  ],
  "Improvements": [
    "Blueprints wipe monthly",
    "5x ammunition crafting cost",
    "2x building upkeep cost"
  ]
}
```

---

## Files in this repo

### Server-side (decompiled C#)

| File | Class | Description |
|------|-------|-------------|
| `ChangelogPanel.cs` | `ChangelogPanel` | MonoBehaviour — refs to the three changelog section headers and `RustText` content fields + layout `RectTransform`s |
| `ChangelogButton.cs` | `ChangelogButton` | MonoBehaviour — shows/hides the HUD button based on `BaseGameMode.GetActiveGameMode()` and sets the label to the mode's `shortname` |

### Client-side (Unity prefab data)

| File | Prefab | Description |
|------|--------|-------------|
| `client/Changelog.Toggle.md` | `Changelog.Toggle` | HUD button prefab — size (80×20 px), anchors, colors, event wiring, GameModeUIElement tags, **hold-to-show** behaviour |
| `client/ChangelogPanel.md` | `ChangelogPanel` | Panel prefab — size (380×322 px), layout, RustText font/color, localization token system, section structure |
| `assets/changelog_ingame.png` | — | In-game screenshot of the panel on a Hardcore server |

---

## Dependencies (vanilla client side)

- `Rust.UI.RustText` / `Rust.UI.RustButton`
- `Translate.Phrase`
- `BaseGameMode`
- `UnityEngine` — `MonoBehaviour`, `GameObject`, `RectTransform`, `CanvasGroup`

---

## Notes

- Decompiled from `Assembly-CSharp.dll` (Unity 2022.3) via dnSpy.
- Stubs only — no Unity project, no Rust SDK.
- Intended for reference and modding, not redistribution of Facepunch's code.

---

## License

Reference / research use only. Rust client source is © Facepunch Studios.
