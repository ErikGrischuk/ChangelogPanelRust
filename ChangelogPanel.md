# Client Prefab — `ChangelogPanel`

Extracted from `BuildPlayer-AssetScene-bootstrap` via **UABEANext** (workspace ver 6000.3.15x1).  
PathID: **250076** (MonoBehaviour), **18726** (GameObject).

---

## In-game appearance

![ChangelogPanel in-game — Hardcore server](https://github.com/ErikGrischuk/ChangelogPanelRust/blob/main/image.png)

- Appears in the **top-left** of the screen, directly below the toggle button
- Dark semi-transparent background
- Title: **"CHANGELOG"** at top
- Three sections with colored headers + icon: **ADDED** (green), **REMOVED** (red), **CHANGED** (blue)
- Items are plain text with `- ` prefix (dash, not bullet)
- Font size is very small (10 px)

---

## GameObject (`GameObjectChangelogPanel`)

| Field | Value | Notes |
|-------|-------|-------|
| PathID | `18726` | |
| Layer | `5` | UI |
| **m_IsActive** | **`false`** | Hidden by default — opened via button `Open(true)` |
| Components | 7 | see table below |

### Component list

| # | PathID | Type |
|---|--------|------|
| 0 | 179398 | **RectTransform** (= MainPanelRectTransform) |
| 1 | 78886 | CanvasRenderer |
| 2 | 268690 | Image (panel background) |
| 3 | 257519 | — |
| 4 | 268653 | — |
| 5 | **250076** | **ChangelogPanel** (MonoBehaviour) |
| 6 | 221310 | — |

---

## MonoScript metadata (`ChangelogPanel`)

| Field | Value |
|-------|-------|
| PathID (sharedAssets) | `310` |
| m_ClassName | `"ChangelogPanel"` |
| m_Namespace | `""` |
| m_AssemblyName | `"Assembly-CSharp"` |
| m_ExecutionOrder | `0` |

---

## ChangelogPanel MonoBehaviour — field references

| Field | PathID | Points to |
|-------|--------|-----------|
| `AddedHeader` | `60685` | GameObject **"Added"** |
| `RemovedHeader` | `46900` | GameObject **"Removed"** |
| `ChangedHeader` | `43724` | GameObject **"Changed"** |
| `AddedContent` | `272688` | RustText — added items |
| `RemovedContent` | `264847` | RustText — removed items |
| `ChangedContent` | `232401` | RustText — changed items |
| `MainPanelRectTransform` | `179398` | Root panel rect |
| `ContentPanelRectTransform` | `147142` | Scrollable content rect |

---

## MainPanelRectTransform (PathID 179398)

| Property | Value | Notes |
|----------|-------|-------|
| AnchorMin | `(0, 1)` | Top-left |
| AnchorMax | `(0, 1)` | Top-left |
| AnchoredPosition | `(0, -20)` | 20 px below top edge |
| **SizeDelta** | **380 × 322.07 px** | |
| Pivot | `(0, 1)` | Top-left |
| Children | `133092`, `147142` | Header + content panel |
| Parent | `153319` | |

---

## ContentPanelRectTransform (PathID 147142)

| Property | Value | Notes |
|----------|-------|-------|
| AnchorMin | `(0, 1)` | Top-left |
| AnchorMax | `(0, 1)` | Top-left |
| AnchoredPosition | `(190, -174.035)` | Centered horizontally (380/2) |
| **SizeDelta** | **370 × 286.07 px** | |
| Pivot | `(0.5, 0.5)` | Center |

### Children (6) — layout order

| PathID | Name | Role |
|--------|------|------|
| `189922` | — | AddedHeader area |
| `178080` | — | AddedContent text |
| `156467` | — | RemovedHeader area |
| `172900` | — | RemovedContent text |
| `161314` | — | ChangedHeader area |
| `152124` | — | ChangedContent text |

---

## Section header GameObjects

| Name | PathID | m_IsActive |
|------|--------|-----------|
| `"Added"` | `60685` | `true` |
| `"Removed"` | `46900` | `true` |
| `"Changed"` | `43724` | `true` |

---

## RustText (content blocks)

All three content RustText components share the same settings:

| Property | Value | Notes |
|----------|-------|-------|
| **m_fontSize** | **10.0** | Very small — compact list |
| m_fontColor | `rgba(0.969, 0.922, 0.882, 0.796)` | Warm off-white, ~80% opacity |
| m_fontColor hex | `#F7EBE1CB` approx | |
| Font asset PathID | `8661589141018520030` | |
| HorizontalAlignment | `1` | Left |
| VerticalAlignment | `256` | Top |
| m_TextWrappingMode | `1` | Wrap enabled |
| **IsLocalized** | **`1`** | Uses token system |
| **Token** | `"changelog_hardcore_*"` | e.g. `changelog_hardcore_added_1` |
| AutoSetHeight | `1` | Panel height auto-adjusts to content |
| AutoSizeParent | `0` | |
| MinWidth | `30.0` | |
| MaxWidth | `Infinity` | |
| m_isRichText | `1` | Rich text tags supported |

> **Localization tokens**: content is not hardcoded — it pulls from Rust's phrase table.  
> Example tokens from the server-side JSON:
> - `changelog_hardcore_added_2` → `"Limit of 5 sleeping bags + beds"`
> - `changelog_hardcore_remove_1` → `"Contact system"`
> - `changelog_hardcore_changed_0` → `"Blueprints wipe monthly"`

---

## Summary for plugin reimplementation

```
Panel default state:  hidden (m_IsActive = false)
Shown by:             button OnPressed → Open(true)
Closed by:            button OnReleased → Close(false)

Panel size:           380 × 322 px
Position:             top-left, 20 px below screen top
Content area:         370 × 286 px, center pivot

Sections:             Added (green) / Removed (red) / Changed (blue)
Item prefix:          "- " (dash + space)
Item font size:       10 px
Item font color:      rgba(0.969, 0.922, 0.882, 0.796)
Content source:       localization token system (changelog_hardcore_*)
Height:               auto-sized to content (AutoSetHeight = 1)
```
