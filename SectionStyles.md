# Plugin — Section Styles Reference

Section header styles taken from **rust.facepunch.com/changes** — used as reference for the Carbon plugin UI.

The vanilla in-game panel has 3 sections (Added / Removed / Changed).  
The plugin expands this to **5 sections** matching the Facepunch website format.

---

## Section Definitions

### 1. Features
```
Icon:       add_circle
Web color:  #8ec62f
Web bg:     linear-gradient(to right, rgba(93,114,57, 0.4) → transparent)
```
| | Web | Unity RGBA (0–1) |
|-|-----|-----------------|
| **Text color** | `#8ec62f` | `0.557 0.776 0.184 1.0` |
| **BG color** | `rgba(93,114,57, 0.4)` | `0.365 0.447 0.224 0.4` |

---

### 2. Improvements
```
Icon:       arrow_circle_up
Web color:  #f5d254
Web bg:     linear-gradient(to right, rgba(215,170,12, 0.4) → transparent)
```
| | Web | Unity RGBA (0–1) |
|-|-----|-----------------|
| **Text color** | `#f5d254` | `0.961 0.824 0.329 1.0` |
| **BG color** | `rgba(215,170,12, 0.4)` | `0.843 0.667 0.047 0.4` |

---

### 3. Fixed
```
Icon:       handyman
Web color:  #65b6ed
Web bg:     linear-gradient(to right, rgba(80,147,197, 0.4) → transparent)
```
| | Web | Unity RGBA (0–1) |
|-|-----|-----------------|
| **Text color** | `#65b6ed` | `0.396 0.714 0.929 1.0` |
| **BG color** | `rgba(80,147,197, 0.4)` | `0.314 0.576 0.773 0.4` |

---

### 4. Known Issues
```
Icon:       error
Web color:  #e9b476
Web bg:     linear-gradient(to right, rgba(215,132,34, 0.4) → transparent)
```
| | Web | Unity RGBA (0–1) |
|-|-----|-----------------|
| **Text color** | `#e9b476` | `0.914 0.706 0.463 1.0` |
| **BG color** | `rgba(215,132,34, 0.4)` | `0.843 0.518 0.133 0.4` |

---

### 5. Removed
```
Icon:       remove_circle
Web color:  #e27575
Web bg:     linear-gradient(to right, rgba(199,42,42, 0.4) → transparent)
```
| | Web | Unity RGBA (0–1) |
|-|-----|-----------------|
| **Text color** | `#e27575` | `0.886 0.459 0.459 1.0` |
| **BG color** | `rgba(199,42,42, 0.4)` | `0.780 0.165 0.165 0.4` |

---

## Web header layout (reference)

```css
.changes-row-header {
    font-family: "Open Sans", sans-serif;
    font-size: 16px;
    align-items: center;
    display: flex;
    flex-direction: row;
    padding: 1rem 1.5rem;
    margin: 0;
}
```

> CUI panels don't support gradients — use the solid left-edge color at `0.4` alpha as the header background.

---

## Quick reference table

| # | Section | Text color (Unity) | BG color (Unity) | Config key |
|---|---------|-------------------|------------------|------------|
| 0 | **Features** | `0.557 0.776 0.184 1` | `0.365 0.447 0.224 0.4` | `"Features"` |
| 1 | **Improvements** | `0.961 0.824 0.329 1` | `0.843 0.667 0.047 0.4` | `"Improvements"` |
| 2 | **Fixed** | `0.396 0.714 0.929 1` | `0.314 0.576 0.773 0.4` | `"Fixed"` |
| 3 | **Known Issues** | `0.914 0.706 0.463 1` | `0.843 0.518 0.133 0.4` | `"KnownIssues"` |
| 4 | **Removed** | `0.886 0.459 0.459 1` | `0.780 0.165 0.165 0.4` | `"Removed"` |

---

## Planned config structure

```json
{
  "PatchName": "My Server Update",
  "ChangelistTitle": "Season 1",
  "Date": "2025",
  "GamemodeShortname": "hardcore",

  "Features":     [],
  "Improvements": [],
  "Fixed":        [],
  "KnownIssues":  [],
  "Removed":      []
}
```

---

## Vanilla vs plugin comparison

| Vanilla in-game | Plugin |
|----------------|--------|
| Added (green) | Features (green `#8ec62f`) |
| Changed (blue) | Improvements (yellow `#f5d254`) + Fixed (blue `#65b6ed`) |
| — | Known Issues (orange `#e9b476`) |
| Removed (red) | Removed (red `#e27575`) |

> Vanilla uses 3 sections fed by `BaseGameMode` prefab data.  
> Plugin uses 5 sections fed by JSON config — no gamemode system required.
