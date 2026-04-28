# BVE5-Motor-Assistance
[[中文版](https://github.com/xiangao0904/BVE5-Motor-Assistance/blob/master/README-CN.md)]
> **⚠️ Note: This repository is deprecated.** > The remade version is available at: [Motor-Sound-Editor](https://github.com/xiangao0904/Motor-Sound-Editor)

## Introduction
**BVE5-Motor-Assistance** is an assistant tool specifically developed for BVE Trainsim 5, designed to help developers manage and edit train motor sound projects more efficiently.

**Development Status:** Please note that both implementations provided in this repository are currently **unfinished**:
* **WPF Version**: A traditional implementation based on the Windows platform.
* **Avalonia Version**: A cross-platform preview implementation based on the Avalonia UI framework.

## Core Features
* **Sound Project Management**: Supports defining core parameters such as project name and maximum train speed.
* **Configuration File Handling**: Built-in logic for reading and modifying `settings.cfg` files.
* **Multilingual Support**: Integrated resource files for Simplified Chinese, Japanese, and English.

## Tech Stack
* **Development Platform**: .NET 8.0
* **UI Frameworks**: 
    * Avalonia UI (v11.2.1): Used for cross-platform desktop development.
    * WPF: UI implementation for the Windows platform.
* **Architectural Pattern**: MVVM (using CommunityToolkit.Mvvm).

## Directory Structure
* `BVE5-Motor-Assistance/`: WPF version source code.
* `Avalonia-BVE5-Motor-Assistance/`: Avalonia version source code, including various assets (fonts, icon resources).

## Development Assets
The project utilizes the following custom fonts:
* **Dosis**
* **SmileySans**
* **Source Han Sans**

---
*Note: This project is no longer maintained. Please refer to the remade version.*
