class Program
{
    public static void Main(string[] args)
    {
        // VARIABLE INITIALIZATION
        int gradePoint;
        int gradeInInt;
        int courseNumberInInt;
        float gradeCummulative = 0;
        float unitLoadSum = 0;
        String score;
        String result;

        Console.WriteLine("HELLO THERE, THIS IS A SIMPLE PROGRAM TO COMPUTE THE RESULT OF A STUDENT AND CALCULATE THE CGPA");
        courseInput:
        Console.WriteLine("How many courses are you offering");
        string courseNumberInString =  Console.ReadLine();
        bool check = int.TryParse(courseNumberInString, out courseNumberInInt);
        if (!check || courseNumberInString == ""){
                Console.WriteLine("INVALID INPUT");
            goto courseInput;
        }

        int[] calculatedGradeArray = new int[courseNumberInInt];
        string[] courseNameArray = new string[courseNumberInInt];
        string[] scoreArray = new string[courseNumberInInt];
        int[] gradeArray = new int[courseNumberInInt];
        int[] unitLoadArray = new int[courseNumberInInt];

        // DYNAMIC STUDENT INPUT
        for (int i = 0; i < courseNumberInInt; i++)
        {
            // COURSE NAME
            courseNameInput:
            Console.WriteLine("ENTER CODE FOR COURSE {0}", (i+1));
            String courseName = Console.ReadLine().ToUpper();
            if(courseName == ""){
                Console.WriteLine("COURSE NAME CANNOT BE EMPTY");
                goto courseNameInput;
            }
            courseNameArray[i] = courseName;

// SCORING SYSTEM
        gradeinput:
            Console.WriteLine("ENTER YOUR SCORE FOR {0}", courseName);
            string gradeInString = Console.ReadLine().ToUpper();
            bool gradeInputCheck = int.TryParse(gradeInString, out gradeInInt);
            
            if (!gradeInputCheck || gradeInString == "" || gradeInInt>100 || gradeInInt <0)
            {
                if(gradeInInt>100 || gradeInInt <0){
                    Console.WriteLine("INVALID SCORE, ENTER A SCORE BETWEEN 0 TO 100");
                    goto gradeinput;
                }
                Console.WriteLine("ENTER A VALID SCORE");
                goto gradeinput;
            }

            switch(gradeInInt){
                case int j when j>= 70:
                    gradePoint = 5;
                    score = "A";
                    break;
                case int j when j>= 60 && i<= 69:
                    gradePoint = 4;
                    score = "B";
                    break;
                case int j when j>= 50 && i<= 59:
                    gradePoint = 3;
                    score = "C";
                    break;
                case int j when j>= 45 && i<= 49:
                    gradePoint = 2;
                    score = "D";
                    break;
                case int j when j>= 40 && i<= 45:
                    gradePoint = 1;
                    score = "E";
                    break;
                default:
                    gradePoint = 0;
                    score = "F";
                    break;
            }
            gradeArray[i] = gradeInInt;
            scoreArray[i] = score;
// ENTER UNITLOAD
        unitloadinput:
        Console.WriteLine("ENTER THE UNIT LOAD FOR {0}", courseName);
        string unitLoadInString = Console.ReadLine();
        bool unitLoadCheck = int.TryParse(unitLoadInString, out int unitLoadInInt);
        if (!unitLoadCheck || unitLoadInString == "" || unitLoadInInt > 6 || unitLoadInInt <0)
            {
                if(unitLoadInInt > 6 || unitLoadInInt<0){
                   Console.WriteLine("INVALID INPUT, ENTER VALUE BETWEEN 1 TO 6");
                goto unitloadinput;
            }
                Console.WriteLine("ENTER A VALID UNITLOAD");
                goto unitloadinput;
            }
            unitLoadArray[i] = unitLoadInInt;


// CGPA CALCULATION
            int calculatedGradePoint = unitLoadInInt * gradePoint;
            calculatedGradeArray[i] = calculatedGradePoint;
        }
    for (int i = 0; i < courseNumberInInt; i++){
            gradeCummulative += calculatedGradeArray[i];
        }
    for (int i = 0; i < courseNumberInInt; i++)
{
            unitLoadSum += unitLoadArray[i];
        }

        float CGPA = (float)Math.Round(gradeCummulative / unitLoadSum * 100f) / 100f;
    switch(CGPA){
        case float i when i>= 4.50:
            result = "First class Upper";
            break;
        case float i when i>= 3.50 && i<= 4.49:
            result = "Second class Upper";
            break;
        case float i when i>= 2.40 && i<= 3.49:
            result = "Second class Lower";
            break;
        case float i when i>= 1.50 && i<= 2.29:
            result = "Third class";
            break;
        case float i when i>= 1.00 && i<= 1.49:
            result = "Pass";
            break;
        default:
            result = "Fail";
            break;
        }

// RESULT DISPLAY
        Console.WriteLine("YOUR RESULT IS");
        for (int i = 0; i < courseNumberInInt; i++)
        {
            Console.WriteLine("{0}.COURSE CODE:{1}   SCORE:{2}   GRADE:{3}",(i+1), courseNameArray[i], gradeArray[i], scoreArray[i]);
        }
        Console.WriteLine("CGPA: {0}   {1}", CGPA, result);

    }
}
