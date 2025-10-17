# Guide - Filtrage de Propriétés Imbriquées (Nested Properties)

## 🎯 Vue d'ensemble

Le système de filtrage dynamique supporte maintenant **les propriétés imbriquées** en utilisant la notation slash (`/`) pour naviguer dans les relations entre objets.

## 📝 Syntaxe

**Format:** `"Parent/Child"` ou `"Parent/Child/GrandChild"`

**Exemples:**
- `"Teacher/FirstName"` - Accède au prénom de l'enseignant
- `"Type/Name"` - Accède au nom du type
- `"Student/Address/City"` - Accède à la ville de l'adresse de l'étudiant

## 🔍 Cas d'Utilisation

### **Exemple 1: Filtrer les créneaux par nom d'enseignant**

**Modèle Slot:**
```csharp
public class Slot
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public UserApp Teacher { get; set; }  // Navigation property
    public Guid TypeId { get; set; }
    public TypeSlot Type { get; set; }    // Navigation property
}
```

**Requête JSON:**
```json
{
  "filters": {
    "Teacher/FirstName": {
      "value": "John",
      "matchMode": "contains"
    }
  }
}
```

**SQL Généré:**
```sql
SELECT * FROM Slots s
INNER JOIN Users u ON s.TeacherId = u.Id
WHERE LOWER(u.FirstName) LIKE '%john%'
```

---

### **Exemple 2: Filtrer par type de créneau**

**Requête JSON:**
```json
{
  "filters": {
    "Type/Name": {
      "value": "Cours individuel",
      "matchMode": "equals"
    }
  }
}
```

**SQL Généré:**
```sql
SELECT * FROM Slots s
INNER JOIN TypeSlots t ON s.TypeId = t.Id
WHERE LOWER(t.Name) = LOWER('cours individuel')
```

---

### **Exemple 3: Filtrer par plusieurs critères imbriqués**

**Requête JSON:**
```json
{
  "filters": {
    "Teacher/FirstName": {
      "value": "John",
      "matchMode": "contains"
    },
    "Teacher/Email": {
      "value": "@fake.com",
      "matchMode": "endswith"
    },
    "Type/Name": {
      "value": "Cours individuel",
      "matchMode": "equals"
    }
  }
}
```

**SQL Généré:**
```sql
SELECT * FROM Slots s
INNER JOIN Users u ON s.TeacherId = u.Id
INNER JOIN TypeSlots t ON s.TypeId = t.Id
WHERE LOWER(u.FirstName) LIKE '%john%'
  AND LOWER(u.Email) LIKE '%@fake.com'
  AND LOWER(t.Name) = LOWER('cours individuel')
```

---

### **Exemple 4: Multi-niveaux (3 niveaux)**

**Modèle Booking:**
```csharp
public class Booking
{
    public Guid StudentId { get; set; }
    public UserApp Student { get; set; }
}

public class UserApp
{
    public List<Address> Addresses { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Country { get; set; }
}
```

**Requête JSON:**
```json
{
  "filters": {
    "Student/Address/City": {
      "value": "Paris",
      "matchMode": "equals"
    }
  }
}
```

**Note:** Pour les collections (comme `Addresses`), vous devrez ajuster votre requête pour utiliser `.Any()`.

---

## 🎨 Exemples Complets

### **Cas 1: Filtrer les créneaux par enseignant et type**

```json
{
  "first": 0,
  "rows": 20,
  "sorts": [
    {
      "field": "DateFrom",
      "order": 1
    }
  ],
  "filters": {
    "Teacher/LastName": {
      "value": "Dupont",
      "matchMode": "equals"
    },
    "Type/Name": {
      "value": "Cours",
      "matchMode": "contains"
    },
    "DateFrom": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    }
  }
}
```

**Résultat:** Tous les créneaux de l'enseignant "Dupont" qui sont de type contenant "Cours" et qui commencent après le 1er janvier 2024.

---

### **Cas 2: Recherche multi-critères sur les réservations**

```json
{
  "first": 0,
  "rows": 50,
  "filters": {
    "Student/FirstName": {
      "value": "Jean",
      "matchMode": "contains"
    },
    "Slot/Teacher/Email": {
      "value": "@school.edu",
      "matchMode": "endswith"
    },
    "Slot/Type/Name": {
      "value": "Cours individuel",
      "matchMode": "equals"
    }
  }
}
```

**Résultat:** Toutes les réservations d'étudiants dont le prénom contient "Jean", avec des créneaux dont l'enseignant a un email se terminant par "@school.edu" et de type "Cours individuel".

---

### **Cas 3: Filtrer par multiples IDs de types**

```json
{
  "filters": {
    "Type/Id": {
      "value": ["guid1", "guid2", "guid3"],
      "matchMode": "any"
    }
  }
}
```

**Résultat:** Tous les créneaux dont le type correspond à l'un des GUIDs spécifiés.

---

## 📊 Match Modes Supportés sur Propriétés Imbriquées

| Match Mode | Type Supporté | Exemple | Description |
|------------|---------------|---------|-------------|
| `equals` | Tous | `Teacher/Email` = "john@mail.com" | Égalité stricte (case-insensitive pour strings) |
| `notequals` | Tous | `Type/Name` != "Test" | Différent de |
| `contains` | String | `Teacher/FirstName` contient "John" | Contient (case-insensitive) |
| `startswith` | String | `Type/Name` commence par "Cours" | Commence par |
| `endswith` | String | `Teacher/Email` finit par "@fake.com" | Se termine par |
| `gt` | Nombres, Dates | `Teacher/DateOfBirth` > "1990-01-01" | Plus grand que |
| `gte` | Nombres, Dates | `Slot/DateFrom` >= "2024-01-01" | Plus grand ou égal |
| `lt` | Nombres, Dates | `Type/CreatedAt` < "2024-01-01" | Plus petit que |
| `lte` | Nombres, Dates | `Student/Age` <= 25 | Plus petit ou égal |
| `any` | Tous | `Type/Id` dans [guid1, guid2] | IN clause |

---

## 🔧 Utilisation dans les Contrôleurs

### **Exemple: Contrôleur Slots avec filtres imbriqués**

```csharp
[HttpPost("filter")]
public async Task<ActionResult<ResponseDTO<List<SlotResponseDTO>>>> FilterSlots(
    [FromBody] DynamicFilters<Slot> filters)
{
    var query = context.Slots
        .Where(s => s.ArchivedAt == null)
        .Include(s => s.Teacher)
        .Include(s => s.Type)
        .ApplyDynamicWhere(filters)
        .ApplySorts(filters);
    
    var slots = await query.ToListAsync();
    
    return Ok(new ResponseDTO<List<SlotResponseDTO>>
    {
        Status = 200,
        Data = slots.Select(s => new SlotResponseDTO(s)).ToList()
    });
}
```

**Important:** N'oubliez pas d'inclure (`.Include()`) les propriétés de navigation que vous filtrez!

---

### **Exemple: Contrôleur Bookings avec filtres imbriqués**

```csharp
[HttpPost("filter")]
public async Task<ActionResult> FilterBookings([FromBody] DynamicFilters<Booking> filters)
{
    var query = context.Bookings
        .Where(b => b.ArchivedAt == null)
        .Include(b => b.Student)
        .Include(b => b.Slot)
            .ThenInclude(s => s.Teacher)
        .Include(b => b.Slot)
            .ThenInclude(s => s.Type)
        .ApplyDynamicWhere(filters)
        .ApplySorts(filters);
    
    var bookings = await query.ToListAsync();
    
    return Ok(bookings);
}
```

---

## ⚡ Performances et Optimisations

### **1. Inclure les Relations**
```csharp
// ❌ MAUVAIS - Génère des requêtes N+1
var query = context.Slots.ApplyDynamicWhere(filters);

// ✅ BON - Charge les relations en une seule requête
var query = context.Slots
    .Include(s => s.Teacher)
    .Include(s => s.Type)
    .ApplyDynamicWhere(filters);
```

### **2. Index sur les Propriétés Filtrées**
Créez des index sur les colonnes fréquemment utilisées dans les filtres:
```sql
CREATE INDEX IX_Users_FirstName ON Users(FirstName);
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_TypeSlots_Name ON TypeSlots(Name);
```

### **3. Limiter la Profondeur**
Évitez les chemins trop profonds (> 3 niveaux) car cela génère des JOINs multiples:
```json
// ⚠️ À éviter si possible
"Order/Student/Address/City/Country/Region"

// ✅ Préférer
"Order/Student/Address/City"
```

---

## 🚨 Limitations et Considérations

### **1. Collections**
Les propriétés de navigation de type collection (List, ICollection) ne sont pas directement supportées avec cette syntaxe. Par exemple:

```csharp
// ❌ Ne fonctionne pas directement
"Addresses/City"  // Addresses est une List<Address>

// ✅ Solution: Utiliser une requête différente ou ajuster le modèle
```

### **2. Propriétés Nullables**
Attention aux propriétés nullables dans le chemin:
```csharp
// Si Teacher peut être null, cette requête pourrait échouer
"Teacher/FirstName"

// Solution: Filtrer d'abord les nulls dans votre contrôleur
var query = context.Slots
    .Where(s => s.Teacher != null)
    .ApplyDynamicWhere(filters);
```

### **3. Sensibilité à la Casse des Chemins**
Les noms de propriétés sont **insensibles à la casse**:
```json
// Tous fonctionnent
"Teacher/FirstName"
"teacher/firstname"
"TEACHER/FIRSTNAME"
```

---

## 🎓 Exemples Avancés

### **Exemple 1: Combinaison de filtres directs et imbriqués**
```json
{
  "filters": {
    "DateFrom": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    },
    "Teacher/FirstName": {
      "value": "John",
      "matchMode": "contains"
    },
    "Teacher/StatusId": {
      "value": ["guid1", "guid2"],
      "matchMode": "any"
    },
    "Type/Name": {
      "value": "Cours",
      "matchMode": "contains"
    }
  }
}
```

---

### **Exemple 2: Recherche complexe sur les utilisateurs**
```json
{
  "filters": {
    "FirstName": {
      "value": "John",
      "matchMode": "contains"
    },
    "Status/Name": {
      "value": "Confirmed",
      "matchMode": "equals"
    },
    "Gender/Name": {
      "value": "Male",
      "matchMode": "equals"
    }
  }
}
```

---

## 📈 Scénarios Réels

### **Scénario 1: Tableau de bord des créneaux**
Afficher tous les créneaux futurs d'enseignants actifs de type "Cours individuel":

```json
{
  "first": 0,
  "rows": 50,
  "sorts": [{"field": "DateFrom", "order": 1}],
  "filters": {
    "DateFrom": {
      "value": "2024-01-15T00:00:00Z",
      "matchMode": "gte"
    },
    "Teacher/StatusId": {
      "value": "confirmed-status-guid",
      "matchMode": "equals"
    },
    "Type/Name": {
      "value": "Cours individuel",
      "matchMode": "equals"
    }
  }
}
```

---

### **Scénario 2: Recherche d'enseignants par spécialité**
Trouver tous les créneaux d'enseignants dont l'email contient "math":

```json
{
  "filters": {
    "Teacher/Email": {
      "value": "math",
      "matchMode": "contains"
    },
    "DateFrom": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    }
  }
}
```

---

### **Scénario 3: Filtrer les réservations par ville de l'étudiant**
```json
{
  "filters": {
    "Student/FirstName": {
      "value": "Jean",
      "matchMode": "contains"
    }
  }
}
```

---

## ✅ Résumé

### **Ce qui fonctionne:**
- ✅ Propriétés imbriquées simple niveau: `"Teacher/FirstName"`
- ✅ Propriétés imbriquées multi-niveaux: `"Slot/Teacher/Email"`
- ✅ Tous les match modes sur propriétés imbriquées
- ✅ Case-insensitive pour les strings
- ✅ Support de tous les types (string, Guid, int, DateTime, etc.)

### **Syntaxe:**
- Utiliser `/` pour séparer les niveaux
- Insensible à la casse des noms de propriétés
- Nécessite `.Include()` dans le contrôleur

### **Performance:**
- Toujours inclure les relations avec `.Include()`
- Créer des index sur les colonnes fréquemment filtrées
- Limiter la profondeur du chemin (max 3-4 niveaux)