namespace Bonyan.BNB;

[Serializable]
public class BnbExtraPropertyDictionary : Dictionary<string, object?>
{
    public BnbExtraPropertyDictionary()
    {
    }

    public BnbExtraPropertyDictionary(IDictionary<string, object?> dictionary)
        : base(dictionary)
    {
    }
}