# Tables créées par Identity Framework

**Identity Framework** gère l'aspect authentification des utilisateurs et la gestion des rôles. Voici les principales tables créées par ce framework :

### AspNetUsers
* Cette table contient les informations des utilisateurs de l'application. Elle stocke des données telles que l'ID utilisateur, le nom d'utilisateur, le mot de passe haché, ainsi que des informations de sécurité (comme les questions de récupération de mot de passe) et d'autres propriétés telles que l'email, les numéros de téléphone et les tokens associés.

### AspNetRoles
* Cette table contient les rôles attribués aux utilisateurs. Par exemple, un rôle peut être "Administrateur", "Utilisateur", etc. Chaque ligne dans cette table contient l'ID et le nom d'un rôle.

### AspNetUserRoles
* Cette table fait le lien entre les utilisateurs et les rôles. Elle associe chaque utilisateur à un ou plusieurs rôles via leurs identifiants respectifs (User ID et Role ID).

### AspNetUserClaims
* Cette table stocke les revendications ("claims") associées à chaque utilisateur. Les revendications sont des déclarations à propos d'un utilisateur (par exemple, son âge ou ses droits). Chaque entrée dans cette table contient le type et la valeur de la revendication pour un utilisateur donné.

### AspNetUserLogins
* Cette table contient les informations de connexion externe d'un utilisateur (par exemple, via Google ou Facebook). Chaque entrée stocke l'ID de l'utilisateur, le fournisseur de connexion, et l'ID fourni par ce dernier.

### AspNetUserTokens
* Cette table stocke les tokens d'authentification associés aux utilisateurs. Cela inclut des tokens comme les tokens d'accès ou de rafraîchissement. Chaque entrée contient l'ID utilisateur, le type de token, et sa valeur.

### AspNetRoleClaims
* Cette table contient les revendications associées aux rôles. Cela permet d'attacher certaines revendications à un rôle particulier, qui s'appliquent ensuite à tous les utilisateurs appartenant à ce rôle.

---

# Tables créées par IdentityServer4

En complément de **Identity Framework**, **IdentityServer4** gère l'authentification et l'autorisation des applications clientes et des API. Les tables suivantes sont générées par **IdentityServer4** :

### ApiResources
* Cette table contient des informations sur les API que vous protégez avec **IdentityServer4**. Elle stocke des informations comme le nom de l'API, une description, et son statut (active ou non).

### ApiScopes
* Elle définit les scopes d'autorisation que les clients peuvent demander pour accéder aux ressources API. Les scopes déterminent le niveau de privilèges requis pour accéder à certaines parties d'une API.

### Clients
* Cette table contient des informations sur les clients (applications) qui interagissent avec **IdentityServer4**. Les clients peuvent être des applications web, mobiles ou des services backend. Cette table stocke des informations comme l'ID client, les secrets, les URI de redirection, et les types de flux OAuth2 supportés.

### ClientSecrets
* Cette table stocke les secrets associés à chaque client. Ces secrets sont utilisés lors de la vérification de l'identité du client pendant les requêtes d'authentification.

### PersistedGrants
* Cette table stocke les tokens (comme les tokens d'accès et de rafraîchissement) ainsi que les autorisations de consentement des utilisateurs. Les informations sont persistées pour permettre la gestion à long terme des tokens et leur révocation.

### DeviceFlowCodes
* Cette table est utilisée pour stocker les codes liés au flux d'authentification des appareils (Device Flow). Elle contient les informations nécessaires pour authentifier les appareils, souvent utilisés dans des scénarios où l'interface utilisateur est limitée (comme pour des téléviseurs ou des consoles).

### IdentityResources
* Cette table contient les ressources d'identité (comme "openid", "profile", "email") qui représentent les informations utilisateur que vous pouvez protéger et émettre sous forme de tokens d'identité.


### __EFMigrationsHistory
Cette table suit l'historique des migrations appliquées à la base de données via Entity Framework.

#### Propriétés principales
- **MigrationId** : Identifiant unique de la migration.
- **ProductVersion** : Version du produit utilisée pour la migration.

---

### DeviceCodes
Cette table stocke les codes utilisés dans le flux d'authentification des appareils pour permettre l'accès avec des appareils à entrée limitée (Device Flow).

#### Propriétés principales
- **DeviceCode** : Code d'authentification de l'appareil.
- **UserCode** : Code d'autorisation de l'utilisateur.
- **ClientId** : Identifiant du client associé.
- **SubjectId** : Identifiant du sujet (utilisateur).
- **Data** : Données supplémentaires relatives au flux d'authentification.

---

### Keys
Cette table stocke les clés cryptographiques utilisées pour signer et chiffrer les tokens JWT (JSON Web Tokens).

#### Propriétés principales
- **Id** : Identifiant de la clé.
- **Algorithm** : Algorithme de chiffrement utilisé.
- **Data** : Données de la clé (clé publique ou privée).
- **Expiration** : Date d'expiration de la clé.

---

### PersistedGrants
Cette table stocke les tokens persistés et les autorisations de consentement.

#### Propriétés principales
- **Key** : Identifiant unique du token.
- **Type** : Type de token (ex. token d'accès, token de rafraîchissement).
- **SubjectId** : Identifiant de l'utilisateur associé.
- **ClientId** : Identifiant du client.

---

### sqlite_sequence
Table utilisée par SQLite pour gérer l'auto-incrémentation des colonnes dans d'autres tables.

---

### PushedAuthorizationRequests
Stocke les requêtes d'autorisation poussées dans le cadre de certains flux OAuth2.

#### Propriétés principales
- **RequestId** : Identifiant unique de la requête.
- **ClientId** : Identifiant du client.
- **Data** : Données de la requête d'autorisation poussée.

---

### ServerSideSessions
Cette table stocke les sessions utilisateur côté serveur.

#### Propriétés principales
- **SessionId** : Identifiant unique de la session.
- **SubjectId** : Identifiant du sujet (utilisateur).
- **ClientId** : Identifiant du client.
- **Data** : Données supplémentaires associées à la session.

---

### ApiResourceClaims
Cette table stocke les revendications ("claims") associées aux ressources API.

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### ApiResourceProperties
Stocke les propriétés supplémentaires associées aux ressources API.

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Key** : Clé de la propriété.
- **Value** : Valeur de la propriété.

---

### ApiResourceScopes
Stocke les associations entre les ressources API et les scopes qu'elles supportent.

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Scope** : Nom du scope associé.

---

### ApiResourceSecrets
Cette table stocke les secrets associés aux ressources API pour sécuriser l'accès à ces dernières.

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Secret** : Secret utilisé pour sécuriser la ressource API.

---

### ApiScopeClaims
Stocke les revendications ("claims") associées aux scopes API.

#### Propriétés principales
- **ApiScopeId** : Identifiant du scope.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### ApiScopeProperties
Stocke des propriétés supplémentaires associées aux scopes API.

#### Propriétés principales
- **ApiScopeId** : Identifiant du scope.
- **Key** : Clé de la propriété.
- **Value** : Valeur de la propriété.

---

### ClientClaims
Cette table stocke les revendications associées aux clients OAuth2.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### ClientCorsOrigins
Stocke les origines CORS autorisées pour les clients OAuth2.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Origin** : Origine CORS autorisée.

---

### ClientGrantTypes
Stocke les types de flux d'autorisation supportés par chaque client (ex. authorization_code, client_credentials).

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **GrantType** : Type de flux d'autorisation supporté.

---

### ClientIdPRestrictions
Stocke les restrictions des fournisseurs d'identité pour chaque client OAuth2.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Provider** : Fournisseur d'identité restreint.

---

### ClientPostLogoutRedirectUris
Stocke les URI de redirection après la déconnexion des clients.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **PostLogoutRedirectUri** : URI de redirection après la déconnexion.

---

### ClientProperties
Stocke des propriétés supplémentaires associées aux clients OAuth2.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Key** : Clé de la propriété.
- **Value** : Valeur de la propriété.

---

### ClientRedirectUris
Stocke les URI de redirection des clients utilisées lors des flux d'autorisation.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **RedirectUri** : URI de redirection.

---

### ClientScopes
Stocke les scopes autorisés pour chaque client.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Scope** : Nom du scope autorisé.

---

### ClientSecrets
Stocke les secrets utilisés pour authentifier les clients.

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Secret** : Secret utilisé pour l'authentification.
- **Expiration** : Date d'expiration du secret.

---

### IdentityProviders
Cette table stocke des informations sur les fournisseurs d'identité externes utilisés pour l'authentification des utilisateurs.

#### Propriétés principales
- **Name** : Nom du fournisseur d'identité (ex. Google, Facebook).
- **Type** : Type de fournisseur (OAuth2, OpenID Connect, etc.).

---

### IdentityResourceClaims
Stocke les revendications associées aux ressources d'identité (ex. profil, email).

#### Propriétés principales
- **IdentityResourceId** : Identifiant de la ressource d'identité.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### IdentityResourceProperties
Stocke des propriétés supplémentaires associées aux ressources d'identité.

#### Propriétés principales
- **IdentityResourceId** : Identifiant de la ressource d'identité.
- **Key** : Clé de la propriété.
- **Value** : Valeur de la propriété.

---

# Configuration avec Duende IdentityServer

La configuration de **Duende IdentityServer** avec **ASP.NET Identity** et **Entity Framework** implique l'intégration de deux types de stores : le **ConfigurationStore** et l'**OperationalStore**. Ces stores assurent la persistance des données relatives aux clients, aux API, aux scopes et aux tokens.

Voici un exemple de configuration en C# utilisant **SQLite** pour la persistance :

```csharp
// partie qui configure authentification
services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// partie qui configure la pertie auhtentification
services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlite(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlite(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
    })
// a utiliser en dev uniquement
    .AddDeveloperSigningCredential();

```


### __EFMigrationsHistory
Cette table suit l'historique des migrations appliquées à la base de données via Entity Framework.

#### Exemple de classe C#
```csharp
public class MigrationHistory
{
    public string MigrationId { get; set; }
    public string ProductVersion { get; set; }
}
```

#### Propriétés principales
- **MigrationId** : Identifiant unique de la migration.
- **ProductVersion** : Version du produit utilisée pour la migration.

---

### DeviceCodes
Cette table stocke les codes utilisés dans le flux d'authentification des appareils pour permettre l'accès avec des appareils à entrée limitée (Device Flow).

#### Exemple de classe C#
```csharp
public class DeviceCode
{
    public string DeviceCode { get; set; }
    public string UserCode { get; set; }
    public string ClientId { get; set; }
    public string SubjectId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime Expiration { get; set; }
    public string Data { get; set; }
}
```

#### Propriétés principales
- **DeviceCode** : Code d'authentification de l'appareil.
- **UserCode** : Code d'autorisation de l'utilisateur.
- **ClientId** : Identifiant du client associé.
- **SubjectId** : Identifiant du sujet (utilisateur).
- **Data** : Données supplémentaires relatives au flux d'authentification.

---

### Keys
Cette table stocke les clés cryptographiques utilisées pour signer et chiffrer les tokens JWT (JSON Web Tokens).

#### Exemple de classe C#
```csharp
public class Key
{
    public string Id { get; set; }
    public string Algorithm { get; set; }
    public string Data { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Expiration { get; set; }
}
```

#### Propriétés principales
- **Id** : Identifiant de la clé.
- **Algorithm** : Algorithme de chiffrement utilisé.
- **Data** : Données de la clé (clé publique ou privée).
- **Expiration** : Date d'expiration de la clé.

---

### PersistedGrants
Cette table stocke les tokens persistés et les autorisations de consentement.

#### Exemple de classe C#
```csharp
public class PersistedGrant
{
    public string Key { get; set; }
    public string Type { get; set; }
    public string SubjectId { get; set; }
    public string ClientId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime Expiration { get; set; }
    public string Data { get; set; }
}
```

#### Propriétés principales
- **Key** : Identifiant unique du token.
- **Type** : Type de token (ex. token d'accès, token de rafraîchissement).
- **SubjectId** : Identifiant de l'utilisateur associé.
- **ClientId** : Identifiant du client.

---

### PushedAuthorizationRequests
Stocke les requêtes d'autorisation poussées dans le cadre de certains flux OAuth2.

#### Exemple de classe C#
```csharp
public class PushedAuthorizationRequest
{
    public string RequestId { get; set; }
    public string ClientId { get; set; }
    public string Data { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime Expiration { get; set; }
}
```

#### Propriétés principales
- **RequestId** : Identifiant unique de la requête.
- **ClientId** : Identifiant du client.
- **Data** : Données de la requête d'autorisation poussée.

---

### ServerSideSessions
Cette table stocke les sessions utilisateur côté serveur.

#### Exemple de classe C#
```csharp
public class ServerSideSession
{
    public string SessionId { get; set; }
    public string SubjectId { get; set; }
    public string ClientId { get; set; }
    public string Data { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime Expiration { get; set; }
}
```

#### Propriétés principales
- **SessionId** : Identifiant unique de la session.
- **SubjectId** : Identifiant du sujet (utilisateur).
- **ClientId** : Identifiant du client.
- **Data** : Données supplémentaires associées à la session.

---

### ApiResourceClaims
Cette table stocke les revendications ("claims") associées aux ressources API.

#### Exemple de classe C#
```csharp
public class ApiResourceClaim
{
    public int ApiResourceId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
}
```

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### ApiResourceProperties
Stocke les propriétés supplémentaires associées aux ressources API.

#### Exemple de classe C#
```csharp
public class ApiResourceProperty
{
    public int ApiResourceId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
```

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Key** : Clé de la propriété.
- **Value** : Valeur de la propriété.

---

### ApiResourceScopes
Stocke les associations entre les ressources API et les scopes qu'elles supportent.

#### Exemple de classe C#
```csharp
public class ApiResourceScope
{
    public int ApiResourceId { get; set; }
    public string Scope { get; set; }
}
```

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Scope** : Nom du scope associé.

---

### ApiResourceSecrets
Cette table stocke les secrets associés aux ressources API pour sécuriser l'accès à ces dernières.

#### Exemple de classe C#
```csharp
public class ApiResourceSecret
{
    public int ApiResourceId { get; set; }
    public string Secret { get; set; }
    public DateTime Expiration { get; set; }
}
```

#### Propriétés principales
- **ApiResourceId** : Identifiant de la ressource API.
- **Secret** : Secret utilisé pour sécuriser la ressource API.
- **Expiration** : Date d'expiration du secret.

---

### ClientClaims
Cette table stocke les revendications associées aux clients OAuth2.

#### Exemple de classe C#
```csharp
public class ClientClaim
{
    public int ClientId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
}
```

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Type** : Type de la revendication.
- **Value** : Valeur de la revendication.

---

### ClientCorsOrigins
Stocke les origines CORS autorisées pour les clients OAuth2.

#### Exemple de classe C#
```csharp
public class ClientCorsOrigin
{
    public int ClientId { get; set; }
    public string Origin { get; set; }
}
```

#### Propriétés principales
- **ClientId** : Identifiant du client.
- **Origin** : Origine CORS autorisée.

