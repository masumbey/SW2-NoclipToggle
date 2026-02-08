<p align="center">
  <img src="https://camo.githubusercontent.com/15411371090ab808f4644366f83bf2871aeacd208b2879fbe87f562a20150a3d/68747470733a2f2f70616e2e73616d7979632e6465762f732f56596d4d5845" />
</p>

# Noclip Toggle – Admin Tool

A **simple**, **fast**, and **broadcast-style** personal noclip plugin for **Counter-Strike 2** using the **SwiftlyS2** framework.

When toggled, **everyone on the server sees a nice colored announcement** who enabled/disabled it.

## 🚀 Features

- **Personal toggle only** — admins toggle noclip just for themselves (no affecting others)
- **!nc** command (very short and memorable)
- **Dead check** — cannot use while dead
- **Broadcast message** to **all players** when someone toggles (with player name)
- **Beautiful colored chat messages** using Swiftly color tags
- **Full multi-language support** — every officially supported CS2 language included
- **No config file needed** — everything is controlled via translation files
- **Clean & lightweight** — minimal performance impact
- **No sv_cheats required**

## 🛡️ Requirements

- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) (latest version recommended)

## 🎮 Commands

| Command     | Description                                          | Who can use?          |
|-------------|------------------------------------------------------|-----------------------|
| `!nc`       | Toggles noclip mode for yourself                     | Players with permission |

## 🌍 Translations

The plugin comes with **full translation support** for **all languages officially supported by Counter-Strike 2**.

You can customize or fix any text you don't like:

- Folder: `resources/translations/`
- Files are in `.jsonc` format (comments allowed)

**Default English example (`en.jsonc`):**

```json
{
  "noclip.prefix":        "{Gold}[Server Name] {LightBlue}",
  "noclip.enable":        "{Green}{name} enabled noclip for themselves.",
  "noclip.disable":       "{Red}{name} disabled noclip for themselves.",
  "noclip.dead":          "{Red}You cannot use noclip command while dead!",
  "noclip.no_permission": "{Red}You don't have permission to use this command!"
}
