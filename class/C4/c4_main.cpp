#include<vector>
#include<string>
#include<iostream>

using namespace std;

class University
{
public:
    University() // default constructor
    {}
    University(const string& name, const string& address) // parameter constructor
    {
        m_sName = name;
        m_sAddress = address;
    }

    void PrintInfo()
    {
        cout << "University Info\n";
        cout << "The name of uni is " << m_sName << endl;
        cout << "The address of uni is " << m_sAddress << endl;
        cout << "--------------------------------------------------------------------------------" << endl;
    }

    string get_name()
    {
        return m_sName;
    }

    string get_address()
    {
        return m_sAddress;
    }
private:
    string m_sName;
    string m_sAddress;
};

class Instructor
{
public:
    Instructor() // default constuctor
    {}
    Instructor(const University& univ, string name, int id, string department) // parameter constructor
    {
        m_uUniversity = univ;
        m_sName = name;
        m_nId = id;
        m_sDepartment = department;
    }

    void PrintInfo()
    {
        cout << "Instructor Info \n" << "Uni: " << m_uUniversity.get_name() << "\n" << "Name: " << m_sName << endl << "Instructors ID : " << 
        m_nId << "\n" << "Department of " << m_sDepartment << endl;
        cout << "--------------------------------------------------------------------------------\n";
    }

    string get_name()
    {
        return m_sName;
    }

private:
    University m_uUniversity;
    string m_sName;
    int m_nId;
    string m_sDepartment;
};

class Course
{
public:
    Course(const University& univ, const Instructor& instructor, const string& name, double grade, int unit)
    : m_uUNiversity(univ)
    , m_iInstructor(instructor)
    , m_sName(name)
    , m_nGrade(grade)
    , m_nUnit(unit)
    {}
    void PrintInfo()
    {
        cout << "Course Info:\n";
        cout << m_sName << " course is instructed at " << m_uUNiversity.get_name() <<  " in " << endl << 
        m_uUNiversity.get_address() << " by " << 
        m_iInstructor.get_name() << " which has " << m_nUnit << " units " << "and its geade is " << m_nGrade << endl;
    }

    string get_name()
    {
        return m_sName;
    }

    void set_grade(double grade)
    {
        m_nGrade = grade;
    }
private:
    University m_uUNiversity;
    Instructor m_iInstructor;
    string m_sName;
    double m_nGrade;
    int m_nUnit;
};

class Student
{
public:
    Student() // default constructor
    {}    
    Student(const University& univ, const string& name, int id, const string& major) // parameter constructor
    {
        m_uUniversity = univ;
        m_sName = name;
        m_nId = id;
        m_sMajor = major;
    }

    void PrintInfo()
    {
        cout << "Student Info: \n" << "Name: " << m_sName << endl << "ID: " << m_nId << endl << "Major: " << m_sMajor << endl << "Uni: " << m_uUniversity.get_name() << endl;
        // for(Course& c : m_vCourses)
        //     c.PrintInfo();
        cout << "--------------------------------------------------------------------------------\n"; 
    }

    void RegisterCourse(const Course& course)
    {
        m_vCourses.push_back(course);
    }

    void RegisterGrade(const string& course,double grade)
    {
        for(Course& c : m_vCourses)
            if (c.get_name() == course) 
                c.set_grade(grade);
    }

    void PrintTranscript()
    {
        cout << "Student transcript:\n";
        cout << "The transcript of " << m_sName << " with " << m_nId << " ID " << " who studies at " << endl <<
        m_uUniversity.get_name() << " is as follows: \n" ;
        cout << "Major: " << m_sMajor << endl;
        cout << "Courses are as follows: " << endl;
        for(Course& c : m_vCourses)
            c.PrintInfo();
        cout << "--------------------------------------------------------------------------------\n"; 
    }

private:
    vector<Course> m_vCourses;
    University m_uUniversity;
    string m_sName;
    int m_nId;
    string m_sMajor;
};


int main(int argc, char const *argv[])
{
    University iust("Iran University of Science and Technology", "Median resalat....");
    Instructor ostad_hoseini(iust, "hosseini", 923423, "Math");
    Course math101(iust, ostad_hoseini, "Math 101", 0, 3);
    Student sara(iust, "sara pejmani", 98342342, "EE");
    sara.RegisterCourse(math101);
    sara.RegisterGrade("Math 101", 19.8);
    sara.PrintTranscript();
    iust.PrintInfo();
    ostad_hoseini.PrintInfo();
    math101.PrintInfo();
    cout << "--------------------------------------------------------------------------------" << endl;
    sara.PrintInfo();


    University UT("University Tehran", "Median enqelab....");
    Instructor ostad_poureza(UT, "poureza", 914569, "Physics");
    Course Physics202(UT, ostad_poureza, "Physics 202", 0, 4);
    Student somaye(UT, "somaye somayei", 9897954, "ME");
    somaye.RegisterCourse(Physics202);
    somaye.RegisterGrade("Physics 202", 17.5);
    somaye.PrintTranscript();
    UT.PrintInfo();
    ostad_poureza.PrintInfo();
    Physics202.PrintInfo();
    cout << "--------------------------------------------------------------------------------" << endl;
    somaye.PrintInfo();

    return 0;
}
