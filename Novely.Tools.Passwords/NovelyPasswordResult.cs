namespace Novely.Tools.Passwords;

/// <summary>
/// Résultat de la vérification d'un mot de passe selon les options définies.
/// </summary>
public class NovelyPasswordResult
{
    /// <summary>
    /// Indique si le mot de passe est valide.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Liste des erreurs ou recommandations si le mot de passe est invalide.
    /// </summary>
    public List<string> Errors { get; set; } = new List<string>();
}
