namespace Beathoven.Utils
{
    abstract class AbstractFactory<T, E>
    {

        public abstract T Create(E enumerator);
    }
}