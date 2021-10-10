﻿﻿# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.1] - 2021-10-9

### Added

- Added Scene Loading capabilities
- Added Loading Screens 
- Added a menu item to create a basic player controller

### Changed

- Made the `Singleton` add object to `DontDestroyOnLoad`

- Renamed `SLManager` to `SaveLoadManager`

- Renamed `SLSystem` to `SaveLoadSystem`

- Renamed `AstroUtils.asmdef` to `AstroTurffx.AstroUtils.asmdef`

## [0.1.0] - 2021-9-19
### Added
- Base package structure
- A changelog
- [GitHub repo](https://github.com/AstroTurffx/AstroUtils)
- Added [documentaion](https://github.com/AstroTurffx/AstroUtils/wiki)
- Added an [attributes](https://github.com/AstroTurffx/AstroUtils/wiki/Attributes) page
- Added the `ReadOnly` attribute 
- Added the `Fold` attribute
- Added a custom inspector for the `Fold` attribute
- Added an abstract `Singleton` class
- Added a `SLSystem`

### Changed
- Change the package namespace from `AstroUtils` to `AstroTurffx.AstroUtils`
- Git ignore to ignore only `.meta` files