namespace Beathoven.Core.Clef
{
    using Beathoven.Utils;

    class ClefFactory : AbstractFactory<IClef, ClefsEnumeration>
    {
        public override IClef Create(ClefsEnumeration cleffEnumeration)
        {
            switch (cleffEnumeration)
            {
                case ClefsEnumeration.G:
                    return new G_Clef();
                case ClefsEnumeration.F:
                    return new F_Clef();
                case ClefsEnumeration.C:
                default:
                    return new C_Clef();
            }

        }
    }
}