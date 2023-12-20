using Bonyan.Bnb.Localization;

namespace Bonyan.Bnb.ExceptionHandling;

public interface ILocalizeErrorMessage
{
    string LocalizeMessage(BnbLocalizationContext context);
}
