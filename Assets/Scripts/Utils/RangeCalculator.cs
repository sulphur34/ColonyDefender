namespace Utils
{
    public static class RangeCalculator
    {
        public static Range GetRangeByDivider(float value, float divider)
        {
            float maximum = GetMaxInRange(value, divider);
            float minimum = maximum - divider + 1;

            return new Range(minimum, maximum);
        }

        private static float GetMaxInRange(float value, float divider)
        {
            float maximum = value;

            while (maximum % divider != 0)
            {
                maximum++;
            }

            return maximum;
        }
    }
}