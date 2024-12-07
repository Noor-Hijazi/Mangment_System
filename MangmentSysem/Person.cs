namespace MangmentSystem
{

    public  class Person
    {
        public string Name { get; protected  set; }
        public int Age { get; protected set; } 

    
        
        public Person(string name, int age)
        {
         
            Name = name;
            Age = age;
        }



        public void setName(string name)
        {
            this.Name = name;
        }   
        public void setAge(int age)
        {
            this.Age = age;
        }
        public override string ToString()
        {
            return $" {Name} - {Age}  ";
        }

    }
}