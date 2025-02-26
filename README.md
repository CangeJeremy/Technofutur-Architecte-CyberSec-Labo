# Labo Architecte Cybersec - Technofutur TIC


- Diagramme Entité - Association
- Schéma Relationnel
- Description des fonctionnalités
- Déploiement
- Rapport de sécurité

Le projet présent dans ce repository n'est pas terminé. Certaines améliorations sont à apporter et des features manquantes sont à implémenter. Ce projet n'a été crée que pour présenter les compétences acquises lors de la formation afin de valider celle-ci.


## Diagramme Entité - Association & Schéma Relationnel
[<img src="EA - Labo.png">]()

## Description des fonctionnalités
Cette application vise à être une alternative à des services tel que bitwarden. Ce projet se basant sur la même logique permet à des utilisateurs de s'inscrire et de se connecter avec un compte "master" (combo email + password).
De la les utilisateurs ont accès à leur profil (Edition (non implémenté)) mais également à une interface pour gérer leurs mots de passes (Ajout, Edition & Suppression (Edition & Suppression non implémentés)).

## Déploiement
### Prérequis :
- Compte microsoft azure
- Visual studio avec .NET installé
- Le projet de ce repository

### Créer une app service sur Azure
- Se connecter au Portail Azure.
- Aller dans "App Services" > "Créer".
- Renseigner les informations suivantes :
    - Nom : unique (ex: monappmvc.azurewebsites.net)
    - Système d’exploitation : Windows
    - Pile de runtime : .NET 8
    - Plan App Service : sélectionner ou créer un plan (ex : "F1 - Gratuit" pour tester)

- Clique sur "Créer" et attends quelques instants.

### Déployer depuis Visual studio
- Ouvrir le projet dans Visual studio
- Faire un clic droit sur le projet > publier
- Choisir Azure > Azure App Service (Windows)
- Se connecter à son compte Azure
- Sélectionner l'App Service créée précédemment
- Cliquer sur "Publier"

#### Pour la base de donnée :
- Dans Azure, créer une Azure SQL Database
- Noter le nom du serveur, utilisateur et mot de passes
- Mettre à jour la chaîne de connexion dans appsettings.json

## Rapport de sécurité
Ci-dessous les sécurité mises en place dans le projet.

- Hash du mot de passe utilisateur à l'inscription
- Encryption / Decryption des mots de passes entrés par l'utilisateur dans le Système
- Utilisation des Sessions avec timeout
- Création d'un Schéma DB et d'un Role DB autre que DBO.