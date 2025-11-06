# Novely.Tools.Passwords

[![NuGet](https://img.shields.io/nuget/v/Novely.Tools.Passwords.svg?style=flat-square)](https://www.nuget.org/packages/Novely.Tools.Passwords)
[![Build Status](https://img.shields.io/github/actions/workflow/status/HueMathias/Novely.Tools.Passwords/dotnet.yml?branch=master&style=flat-square)](https://github.com/HueMathias/Novely.Tools.Passwords/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE)


**Novely.Tools.Passwords** est un package NuGet .NET qui permet de **vérifier la robustesse des mots de passe** de manière simple, configurable et sécurisée.

---

## Fonctionnalités principales

- Vérification des critères classiques :  
  - Longueur minimale  
  - Lettres majuscules et minuscules  
  - Chiffres  
  - Caractères spéciaux  
- Retour d’un objet `NovelyPasswordResult` avec :  
  - `Success` → booléen indiquant si le mot de passe est valide  
  - `Errors` → liste des éléments non respectés  
- API **fluent** pour configurer les options facilement  
- Prêt à être utilisé dans vos applications web, API ou projets internes  

---

## Installation

Vous pouvez installer le package via NuGet :

```bash
dotnet add package Novely.Tools.Passwords
```

Ou via le Package Manager :

```bash
Install-Package Novely.Tools.Passwords
```

## Exemple d'utilisation

```csharp
var result = new NovelyPassword()
                .SetMinLength(10)
                .UseDigits()
                .UseSpecialChars()
                .Check("Test123!");

Console.WriteLine(result.Success); // False
Console.WriteLine(string.Join("\n", result.Errors));
```