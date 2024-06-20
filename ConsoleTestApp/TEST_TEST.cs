namespace ConsoleTestApp
{
    internal static class TEST_TEST
    {
        public static void TEST()
        {
            int num = 111;
            object o = num;
            
            string str1 = o as string; // No errors: str1 <== null

            string str2 = (string)o; // Error: Unable to cast object
        }
    }
}
