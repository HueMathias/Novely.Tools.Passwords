using System.Text.RegularExpressions;

namespace Novely.Tools.Passwords;

/// <summary>
/// Options configurables pour l'évaluation d'un mot de passe.
/// Permet d'activer ou désactiver certaines règles et de définir les paramètres.
/// Version prête pour une utilisation fluent.
/// </summary>
public class NovelyPassword
{
    /// <summary>
    /// Longueur minimale du mot de passe (par défaut 8).
    /// </summary>
    public int MinLength { get; private set; } = 8;

    /// <summary>
    /// Indique si le mot de passe doit contenir au moins une lettre majuscule.
    /// </summary>
    public bool RequireUppercase { get; private set; } = true;

    /// <summary>
    /// Indique si le mot de passe doit contenir au moins une lettre minuscule.
    /// </summary>
    public bool RequireLowercase { get; private set; } = true;

    /// <summary>
    /// Indique si le mot de passe doit contenir au moins un chiffre.
    /// </summary>
    public bool RequireDigits { get; private set; } = true;

    /// <summary>
    /// Indique si le mot de passe doit contenir au moins un caractère spécial.
    /// </summary>
    public bool RequireSpecialChars { get; private set; } = true;

    /// <summary>
    /// Constructeur par défaut, initialise les options avec les valeurs recommandées.
    /// </summary>
    public NovelyPassword()
    {
        MinLength = 8;
        RequireUppercase = true;
        RequireLowercase = true;
        RequireDigits = true;
        RequireSpecialChars = true;
    }

    #region Fluent
    public NovelyPassword SetMinLength(int length)
    {
        MinLength = length;
        return this;
    }

    public NovelyPassword UseUppercase(bool required = true)
    {
        RequireUppercase = required;
        return this;
    }

    public NovelyPassword UseLowercase(bool required = true)
    {
        RequireLowercase = required;
        return this;
    }

    public NovelyPassword UseDigits(bool required = true)
    {
        RequireDigits = required;
        return this;
    }

    public NovelyPassword UseSpecialChars(bool required = true)
    {
        RequireSpecialChars = required;
        return this;
    }
    #endregion

    /// <summary>
    /// Vérifie si le mot de passe respecte toutes les règles définies dans les options.
    /// </summary>
    /// <param name="password">Le mot de passe à vérifier</param>
    /// <returns>Un objet <see cref="NovelyPasswordResult"/></returns>
    public NovelyPasswordResult Check(string password)
    {
        var result = new NovelyPasswordResult { Success = true };

        if (string.IsNullOrEmpty(password))
        {
            result.Success = false;
            result.Errors.Add("Le mot de passe ne peut pas être vide.");
            return result;
        }

        if (password.Length < MinLength)
        {
            result.Success = false;
            result.Errors.Add($"Le mot de passe doit contenir au moins {MinLength} caractères.");
        }

        if (RequireUppercase && !password.Any(char.IsUpper))
        {
            result.Success = false;
            result.Errors.Add("Le mot de passe doit contenir au moins une lettre majuscule.");
        }

        if (RequireLowercase && !password.Any(char.IsLower))
        {
            result.Success = false;
            result.Errors.Add("Le mot de passe doit contenir au moins une lettre minuscule.");
        }

        if (RequireDigits && !password.Any(char.IsDigit))
        {
            result.Success = false;
            result.Errors.Add("Le mot de passe doit contenir au moins un chiffre.");
        }

        if (RequireSpecialChars && !Regex.IsMatch(password, @"[\W_]"))
        {
            result.Success = false;
            result.Errors.Add("Le mot de passe doit contenir au moins un caractère spécial.");
        }

        return result;
    }
}
