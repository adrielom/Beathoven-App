namespace Beathoven.Collection.Cleff
{
    using Beathoven.Utils;

    class CleffFactory : AbstractFactory<ICleff, CleffsEnumeration>
    {
        public override ICleff Create(CleffsEnumeration cleffEnumeration)
        {
            switch (cleffEnumeration)
            {
                case CleffsEnumeration.G:
                    return new G_Cleff();
                case CleffsEnumeration.F:
                    return new F_Cleff();
                case CleffsEnumeration.C:
                default:
                    return new C_Cleff();
            }

        }
    }
}