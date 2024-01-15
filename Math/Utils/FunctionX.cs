namespace Mathematics.Utils
{
    public delegate T FunctionX<T>(T x);
    /// <summary>
    /// Interface of a function of one variable
    /// </summary>
    public interface IFunctionX<T>
    {
        public T Apply(T x);
    }
}
