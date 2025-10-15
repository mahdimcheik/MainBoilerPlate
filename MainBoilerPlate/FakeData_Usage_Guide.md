# Guide d'utilisation - Générateur de Données Fictives

## 📋 Vue d'ensemble

Le contrôleur `FakeDataController` utilise la bibliothèque **Bogus** pour générer des données de test réalistes. Ce système permet de peupler rapidement votre base de données avec des utilisateurs, adresses, créneaux et autres données pour le développement et les tests.

## 🚀 Installation

Le package **Bogus v35.6.4** est déjà installé et configuré dans le projet.

## 📡 Endpoints Disponibles

### 1. Générer des Utilisateurs Fictifs
**Endpoint:** `POST /fakedata/users?count=10`

Génère des utilisateurs avec différents rôles :
- **Students** (Étudiants)
- **Teachers** (Enseignants)
- **Admins** (Administrateurs)

**Paramètres:**
- `count` (optionnel, défaut: 10) - Nombre d'utilisateurs par rôle (max: 100)

**Exemple de requête:**
```http
POST /fakedata/users?count=20
```

**Réponse:**
```json
{
  "message": "Utilisateurs fictifs créés avec succès",
  "status": 201,
  "data": {
    "students": 20,
    "teachers": 20,
    "admins": 4,
    "total": 44
  }
}
```

### 2. Générer des Adresses Fictives
**Endpoint:** `POST /fakedata/addresses?addressesPerUser=2`

Génère des adresses pour tous les utilisateurs existants.

**Paramètres:**
- `addressesPerUser` (optionnel, défaut: 2) - Nombre d'adresses par utilisateur (max: 10)

**Exemple de requête:**
```http
POST /fakedata/addresses?addressesPerUser=3
```

**Réponse:**
```json
{
  "message": "Adresses fictives créées avec succès",
  "status": 201,
  "data": {
    "totalAddresses": 132,
    "users": 44
  }
}
```

### 3. Générer des Types de Créneaux
**Endpoint:** `POST /fakedata/type-slots?count=5`

Génère différents types de créneaux (Cours individuel, Cours collectif, etc.).

**Paramètres:**
- `count` (optionnel, défaut: 5) - Nombre de types à générer (max: 20)

**Exemple de requête:**
```http
POST /fakedata/type-slots?count=6
```

**Réponse:**
```json
{
  "message": "Types de créneaux créés avec succès",
  "status": 201,
  "data": {
    "totalCreated": 6
  }
}
```

### 4. Générer des Créneaux Fictifs
**Endpoint:** `POST /fakedata/slots?slotsPerTeacher=10`

Génère des créneaux pour tous les enseignants existants.

**Paramètres:**
- `slotsPerTeacher` (optionnel, défaut: 10) - Nombre de créneaux par enseignant (max: 50)

**Exemple de requête:**
```http
POST /fakedata/slots?slotsPerTeacher=15
```

**Réponse:**
```json
{
  "message": "Créneaux fictifs créés avec succès",
  "status": 201,
  "data": {
    "totalSlots": 300,
    "teachers": 20
  }
}
```

### 5. Générer Toutes les Données en Une Fois
**Endpoint:** `POST /fakedata/all`

Génère un jeu complet de données :
- 20 utilisateurs par rôle (Students, Teachers, Admins)
- 2 adresses par utilisateur
- 6 types de créneaux
- 15 créneaux par enseignant

**Exemple de requête:**
```http
POST /fakedata/all
```

**Réponse:**
```json
{
  "message": "Toutes les données fictives ont été générées avec succès",
  "status": 201,
  "data": {
    "users": {
      "students": 20,
      "teachers": 20,
      "admins": 4,
      "total": 44
    },
    "addresses": {
      "totalAddresses": 88,
      "users": 44
    },
    "typeSlots": {
      "totalCreated": 6
    },
    "slots": {
      "totalSlots": 300,
      "teachers": 20
    }
  }
}
```

### 6. Supprimer Toutes les Données Fictives
**Endpoint:** `DELETE /fakedata/clear`

Supprime tous les utilisateurs avec un email `@fake.com` et leurs données liées :
- Adresses associées
- Créneaux créés par les enseignants
- Réservations associées

**Exemple de requête:**
```http
DELETE /fakedata/clear
```

**Réponse:**
```json
{
  "message": "Données fictives supprimées avec succès",
  "status": 200,
  "data": {
    "deletedUsers": 44
  }
}
```

## 🎯 Scénarios d'Utilisation

### Scénario 1: Configuration Initiale Complète
```bash
# Générer toutes les données en une seule commande
POST /fakedata/all
```

### Scénario 2: Génération Progressive
```bash
# 1. Générer 30 utilisateurs par rôle
POST /fakedata/users?count=30

# 2. Ajouter 3 adresses par utilisateur
POST /fakedata/addresses?addressesPerUser=3

# 3. Créer 8 types de créneaux
POST /fakedata/type-slots?count=8

# 4. Générer 20 créneaux par enseignant
POST /fakedata/slots?slotsPerTeacher=20
```

### Scénario 3: Nettoyage et Régénération
```bash
# 1. Supprimer les anciennes données
DELETE /fakedata/clear

# 2. Régénérer de nouvelles données
POST /fakedata/all
```

## 📊 Types de Données Générées

### Utilisateurs
Chaque utilisateur fictif comprend :
- **Prénom & Nom** (français réalistes)
- **Email** : `prenom.nom@fake.com`
- **Mot de passe** : `FakePassword123!`
- **Date de naissance** (entre 18 et 58 ans)
- **Genre** (aléatoire parmi Male, Female, Other)
- **Statut** : Confirmed
- **Téléphone** (format français)
- **Titre professionnel**
- **Description** (paragraphe aléatoire)
- **Consentements** : Activés

### Rôles Distribués
- **Students** : `count` utilisateurs
- **Teachers** : `count` utilisateurs
- **Admins** : `count / 5` utilisateurs (minimum 1)

### Adresses
Chaque adresse comprend :
- **Rue** (adresse française réaliste)
- **Ville** (ville française)
- **État/Région**
- **Pays** : "France"
- **Code postal** (format français)
- **Informations complémentaires**
- **Coordonnées GPS** (latitude/longitude)

### Types de Créneaux
Types prédéfinis :
1. Cours individuel
2. Cours collectif
3. Atelier pratique
4. Conférence
5. Tutorat
6. Session de questions-réponses
7. Cours intensif
8. Cours de révision
9. Mentorat

Chaque type avec :
- **Couleur** (hexadécimale aléatoire)
- **Icône** (FontAwesome)

### Créneaux
Chaque créneau comprend :
- **Date de début** (dans les 60 prochains jours)
- **Date de fin** (1 à 3 heures après le début)
- **Horaires** : entre 8h et 21h
- **Enseignant** (assigné aléatoirement)
- **Type de créneau** (assigné aléatoirement)

## ⚠️ Important

### Prérequis
Avant de générer des données, assurez-vous que les données de base sont présentes :
- ✅ Genres (Male, Female, Other)
- ✅ Statuts de compte (Pending, Confirmed, Banned)
- ✅ Rôles (SuperAdmin, Admin, Teacher, Student)

Ces données sont automatiquement créées lors des migrations.

### Identification des Données Fictives
Tous les utilisateurs générés ont un email se terminant par `@fake.com`, ce qui permet :
- De les identifier facilement
- De les supprimer en masse avec `/fakedata/clear`
- De ne pas interférer avec les utilisateurs réels

### Limites de Sécurité
- Maximum **100 utilisateurs** par rôle par appel
- Maximum **10 adresses** par utilisateur
- Maximum **20 types** de créneaux
- Maximum **50 créneaux** par enseignant

## 🔧 Utilisation avec Swagger

1. Accédez à l'interface Swagger (généralement à la racine de votre API)
2. Localisez la section **FakeData**
3. Dépliez l'endpoint souhaité
4. Cliquez sur "Try it out"
5. Ajustez les paramètres si nécessaire
6. Cliquez sur "Execute"

## 💡 Conseils

### Pour le Développement
```bash
# Configuration rapide pour le développement
POST /fakedata/all
```

### Pour les Tests
```bash
# Configuration personnalisée pour les tests
POST /fakedata/users?count=5
POST /fakedata/addresses?addressesPerUser=1
POST /fakedata/type-slots?count=3
POST /fakedata/slots?slotsPerTeacher=5
```

### Nettoyage Régulier
```bash
# Avant chaque série de tests
DELETE /fakedata/clear
POST /fakedata/all
```

## 🎨 Personnalisation

Si vous souhaitez personnaliser les données générées, modifiez le fichier :
```
MainBoilerPlate/Services/FakeDataService.cs
```

Vous pouvez ajuster :
- Les noms et prénoms (locale Bogus)
- Les types de créneaux
- Les couleurs et icônes
- Les plages horaires
- Les durées des créneaux

## 📝 Logs et Erreurs

Les erreurs courantes :

### "Les données de base doivent être présentes..."
**Solution** : Exécutez les migrations de base de données

### "Aucun enseignant trouvé..."
**Solution** : Générez d'abord les utilisateurs avec `/fakedata/users`

### "Aucun type de créneau trouvé..."
**Solution** : Générez d'abord les types avec `/fakedata/type-slots`

## 🚀 Workflow Recommandé

### Premier Lancement
1. `POST /fakedata/all` - Génération complète

### Tests Quotidiens
1. `DELETE /fakedata/clear` - Nettoyage
2. `POST /fakedata/all` - Régénération

### Tests Spécifiques
1. `POST /fakedata/users?count=X` - Nombre précis d'utilisateurs
2. Ajustez selon vos besoins de test