public struct Range
{
    public Range(float minimum, float maximum)
    {
        Minimum = minimum; 
        Maximum = maximum;
    }

    public float Minimum { get; private set; }
    public float Maximum { get; private set; }

}
