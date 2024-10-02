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