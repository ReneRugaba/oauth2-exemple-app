namespace ClientCodeApp.exemple.Data;

public class TokenIntrospectionResponse
{
    public bool Active { get; set; }            // Indique si le token est valide et actif
    public string? Scope { get; set; }          // Liste des scopes associés au token
    public string? ClientId { get; set; }       // L'ID du client ayant demandé le token
    public string? Username { get; set; }       // Le nom d'utilisateur associé au token, si applicable
    public string? TokenType { get; set; }      // Le type de token (ex: "Bearer")
    public string? Sub { get; set; }            // L'identifiant du sujet (généralement l'ID de l'utilisateur)
    public long? Exp { get; set; }              // Timestamp UNIX indiquant l'expiration du token
    public long? Iat { get; set; }              // Timestamp UNIX de l'émission du token
    public long? Nbf { get; set; }              // Timestamp UNIX avant lequel le token n'est pas encore valide
    public string? Iss { get; set; }            // L'émetteur du token (serveur d'autorisation)
    public string? Aud { get; set; }            // L'audience du token (l'API ou les ressources protégées)
    public string? Jti { get; set; }            // Identifiant unique du token (Token ID)
    public string? Alg { get; set; }            // L'algorithme de signature du token
}


