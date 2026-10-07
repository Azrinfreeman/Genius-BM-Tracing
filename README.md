# Genius Bahasa Melayu

A Unity tracing-game adaptation with an album for choosing shapes, guided path tracing, audio feedback, completion rewards, and locally saved progress. The project builds on **English Alphabet Tracing A–Z 1.0.5 by Indie Studio / Baraa Nasser**; its included framework and original credits are preserved.

The repository name reflects the project's intended Bahasa Melayu identity. The included package still contains English alphabet assets and speech filenames; complete Malay localization and lesson coverage were not verified during this source review.

## Features in the source

- Album/group selection and a tracing scene with mouse/touch input handling.
- Path filling with pencil/color selection and guidance graphics.
- Audio clips for shape speech and correct, incorrect, locked, and completion feedback.
- Timer-based star rewards and a completion dialog.
- Saved shape stars, path colors, and lock status through Unity `PlayerPrefs`; completion can unlock the next configured shape.
- A custom background controller that selects among three background groups based on the selected shape or album group.

This is a prototype. Serialized lesson configuration, input behavior, localization, and platform builds still require Unity verification. See [validation notes](docs/VALIDATION.md).

## Open the project

1. Clone the complete repository and open its root through Unity Hub.
2. Use **Unity 2022.3.46f1**, recorded in [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt).
3. Allow asset import and [package resolution](Packages/manifest.json). The manifest includes URP 14.0.11, TextMesh Pro 3.0.6, and uGUI 1.0.0.
4. Inspect the `Logo`, `Album`, and `Game` scenes under `Assets/English Alphabet A-Z/Scenes/`, starting with `Logo` for the intended launch flow.
5. Confirm the build scene order and references in Unity before making a platform build. The tracked EditorBuildSettings file is binary; this review found those three embedded scene paths but did not fully deserialize its settings.

The source uses Unity's legacy `Input` API for pointer/touch handling. Confirm the project's input configuration and device behavior in the Editor rather than assuming import alone establishes compatibility.

## Source guide

| Area | Source |
| --- | --- |
| Tracing, shape navigation, and completion | [GameManager.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/GameManager.cs) |
| Shape configuration and selected shape | [ShapesManager.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/ShapesManager.cs) |
| Saved stars, colors, and lock status | [DataManager.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/DataManager.cs) |
| Timer and star feedback | [Timer.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/Timer.cs), [WinDialog.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/WinDialog.cs) |
| Album scrolling | [ScrollSlider.cs](Assets/English%20Alphabet%20A-Z/Scripts/Game/ScrollSlider.cs) |
| Background selection | [BackgroundController.cs](Assets/BackgroundController.cs) |

## Included package credits

The original [package ReadMe](Assets/English%20Alphabet%20A-Z/ReadMe.txt) identifies Indie Studio and developer Baraa Nasser. Keep those notices and applicable asset terms when reusing the project. This documentation adds no repository-wide license and does not establish redistribution rights for the included package or media.
