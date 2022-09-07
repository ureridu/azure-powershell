<!-- region Generated -->
# Az.Automanage
This directory contains the PowerShell module for the Automanage service.

---
## Status
[![Az.Automanage](https://img.shields.io/powershellgallery/v/Az.Automanage.svg?style=flat-square&label=Az.Automanage "Az.Automanage")](https://www.powershellgallery.com/packages/Az.Automanage/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Automanage`, see [how-to.md](how-to.md).
<!-- endregion -->

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 54ad712dbb6f83113574e2c81558cb146740912a
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/automanage/resource-manager/Microsoft.Automanage/stable/2022-05-04/automanage.json

# title: Databricks
# subject-prefix: $(service-name)

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

```
