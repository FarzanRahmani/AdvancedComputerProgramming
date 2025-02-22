#include<string>
#include<vector>
#include<iostream>

using namespace std;

class Student
{
public:
    Student(string firstName, string lastName, int stdId, string major) // constructor
        : m_firstName(firstName)
        , m_lastName(lastName)
        , m_stdId(stdId)
        , m_major(major)
    {
        // m_firstName = firstName;
    }

    Student(const Student& other) // constructor copy  // ya joloye har tabe get ye const bezar ya inja const ro baradr
    {
        m_firstName = other.get_firstname();
        m_lastName = other.get_lastname();
        m_stdId = other.get_stdId();
        m_major = other.get_major();
        // for (int i = 0; i < other.m_vGrades.size(); i++)
        // {
        //     m_vGrades.push_back(other.m_vGrades[i]);
        //     m_vCourseUnit.push_back(other.m_vCourseUnit[i]);
        //     m_vCourses.push_back(other.m_vCourses[i]);
        // }
        m_vGrades = other.m_vGrades;
        m_vCourseUnit = other.m_vCourseUnit;
        m_vCourses = other.m_vCourses;
    } // TODO

    // void PrintCompareTranscript(Student& other)
    // {
    //     cout << "The transcripts of " << get_fullName() << " versus " << other.get_fullName() << " are as follows:" << endl;
    //     cout <<  get_fullName() << "                        " <<   other.get_fullName() << endl;
    //     cout << "course    " <<  "unit    "  <<  "grade                " <<  "course    " <<  "unit    "  <<  "grade" << endl;
    //     cout << "--------------------------           --------------------------------" << endl;
    //     for (int i = 0; i < other.m_vCourseUnit.size(); i++)
    //     {
    //         cout << m_vCourses[i] << "        "  << m_vCourseUnit[i] <<  "       "  << m_vGrades[i] << "                    " << other.m_vCourses[i] << "        "  << other.m_vCourseUnit[i] <<  "       "  << other.m_vGrades[i] << endl;
    //     }
    //     cout << endl;
    // } // TODO
    void PrintCompareTranscript(Student& other)
    {
        cout << "The transcripts of " << get_fullName() << " versus " << other.get_fullName() << " are as follows:" << endl;
        cout <<  get_fullName() << "                         " <<   other.get_fullName() << endl;
        cout << "course    " <<  "unit    "  <<  "grade                " <<  " course    " <<  "unit    "  <<  "grade" << endl;
        cout << "--------------------------           --------------------------------" << endl;
        for (int i = 0; i < other.m_vCourseUnit.size(); i++)
        {
            cout << m_vCourses[i] << "\t  "  << m_vCourseUnit[i] <<  "\t  "  << m_vGrades[i] << "\t\t\t" << other.m_vCourses[i] << "\t  "  << other.m_vCourseUnit[i] <<  " \t " << " " << other.m_vGrades[i] << endl;
        }
        cout << endl;
    } // TODO

    void RegisterGrade(string course, int units, double grade)
    {
        //TODO update grades
        m_vCourseUnit.push_back(units);
        m_vCourses.push_back(course);
        m_vGrades.push_back(grade);
    }

    void PrintTranscript()
    {
        cout <<  "The transcript of " << m_firstName << " " << m_lastName  << " who studies " << m_major << " is as follows:" << endl;
        cout << "course    " <<  "unit    "  <<  "grade" << endl;
        cout << "-----------------------------" << endl;
        for (int i = 0; i < m_vCourseUnit.size(); i++)
        {
            cout << m_vCourses[i] << "        "  << m_vCourseUnit[i] <<  "       "  << m_vGrades[i] << endl;
        }
        cout << endl;
    } 

    string get_fullName()
    {
        return (m_firstName + " " + m_lastName);
    } // TODO

    int get_stdId() const
    {
        return m_stdId;
    }

    string get_major() const
    {
        return m_major;
    } // TODO

    string get_firstname() const
    {
        return m_firstName;
    }

    string get_lastname() const
    {
        return m_lastName;
    }

    void PrintFailedCourses()
    {
        cout << "Failed courses are:" << endl;
        for (int i = 0; i < m_vCourseUnit.size() ; i++)
        {
            if(m_vGrades[i] < 10)
                cout << m_vCourses[i] << endl;
        }
        cout << endl;
    } // TODO

    double get_GPA()
    {
        int units = 0 ;
        double sum = 0.0;
        for (int i = 0; i < m_vCourseUnit.size(); i++)
            units += m_vCourseUnit[i];
        for (int i = 0; i < m_vGrades.size(); i++)
            sum += m_vGrades[i]*m_vCourseUnit[i];
        double gpa = sum/units;
        return gpa;
    }

    void set_firstName(string firstName)
    {
        this->m_firstName = firstName;
    } // TODO

    void set_lastName(string lastName)
    {
        (*this).m_lastName = lastName;
    } // TODO

    void set_stdId(int stdId) 
    {
        this->m_stdId = stdId;
    } 

    void set_major(string major) 
    {
        m_major = major;
    } // TODO



private:
    string m_firstName;
    string m_lastName;
    int m_stdId;
    string m_major;
    vector<int> m_vCourseUnit;
    vector<double> m_vGrades;
    vector<string> m_vCourses;
};


int main(int argc, char const *argv[])
{
    Student mn("Aysa", "Mayahinia", 99521231, "Computer");
    mn.RegisterGrade("AP", 3, 18);
    mn.RegisterGrade("DS", 3, 18.5);
    mn.RegisterGrade("FC", 3, 18);
    mn.RegisterGrade("CL", 3, 8);
    mn.RegisterGrade("AL", 3, 9);

    cout << mn.get_firstname() << endl;
    cout << mn.get_lastname() << endl;
    cout << mn.get_fullName() << endl;
    cout << mn.get_major() << endl;
    cout << mn.get_stdId() << endl;
    cout << mn.get_GPA() << endl;
    cout << endl;

    mn.PrintTranscript();
    mn.PrintFailedCourses();

    Student nz(mn);
    nz.set_firstName("Aylin");
    nz.set_lastName("Naebzadeh");
    nz.set_stdId(99521111);
    nz.set_major("Mechanic");

    nz.PrintCompareTranscript(mn);
    cout << nz.get_GPA() << endl;



    return 0;
}
