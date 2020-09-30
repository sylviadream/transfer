class Program
	{
		static void Main(string[] args)			
		{
            string input = "-1+(2+3.5)*2";
            double returnvalue = new Program().Calculate(input);      
        }

        // 指针
        double num = 0.0;
        int i = 0;
        public double Calculate(String formule)
        {
            CultureInfo provider = new CultureInfo("en-GB");
            int len;
            if (formule.Length == 0)
            {
                return 0;
            }
            
            char sign = '+';
            string valueStr = "";
            Stack<double> stack = new Stack<double>();
            for (i=0; i < formule.Length; i++)
            {
                if (Char.IsDigit(formule, i) || formule[i] == '.')
                {
                   var temp = formule[i];
                    valueStr = valueStr + formule[i];                  
                }


                if (formule[i] == '(')
                {
                    int j = i;
                    int cnt = 0;
                    for (j = i; j < formule.Length; j++)
                    {
                        if (formule[j] == '(') cnt++;
                        if (formule[j] == ')') cnt--;
                        if (cnt == 0) break;
                    }
                    num = Calculate(formule.Substring(i + 1, j - i-1) );
                    i = j+1;
                }
                if ((!Char.IsDigit(formule, i) && formule[i] != ' ' && formule[i] != '.' ) == true || i == formule.Length - 1)
                {
                    if (valueStr.Length!=0)
                    { 
                    num = Double.Parse(valueStr, provider);
                    }
                    valueStr = "";
                    
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    if (sign == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    if (sign == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }
                    sign = formule[i];
                }
            }
            double result = 0;
            foreach (double x in stack)
            {
                result += x;
            }
            return result;
        }
    }
