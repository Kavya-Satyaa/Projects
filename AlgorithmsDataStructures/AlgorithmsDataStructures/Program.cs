// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//ARRAYS

// 1.Inserting at end of an array
int[] intArray= new int[6];
//Number of elements are kept track using length
int length = 0;
for (int i = 0; i < 3; i++)
{
    intArray[i] = i + 1;
    length++;
}
//Adding number at end of array using length
intArray[length] = 8;
length++;


// 2. Inserting at start of array

for(int i=3;i>=0;i--)
{
    intArray[i+1] = intArray[i];   //Assign all values to next index
}
//Insert at first position
intArray[0] = 8;


// 3. Inserting at any position  (Here at index 2 we place number 8)
for(int i=4;i>=2;i--)
{
    intArray[i+1]=intArray[i];
}
intArray[2] = 8;


