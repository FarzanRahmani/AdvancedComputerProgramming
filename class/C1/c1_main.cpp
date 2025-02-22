#include<iostream>
#include<vector>

// using namespace std;

int main(int argc, char const *argv[])
{
    // using namespace std;     cout << "Hello world" <<  endl;
    std::cout << "Hello world" << std::endl; // instead of print


    int n = 5;
    std::cout << "Hello world" <<  n << std::endl;
    std::cin >> n ; // scanf  *** cin endl nemikhad ***
    std::string s = "Salam chetori";
    std::cout << s.size() << std::endl;
    std::string s2 = s + " khaste hastam !";
    std::cout << s2 << std::endl;
    std::cin >> s2;
    std::cout << "I got this string: " << s2 << std::endl;
    std::cout << "I got this string: " << s2 << s2 << s2 << s2 << "\r\n";
    // endl --> windows:"\r\n" -- linux:"\n"

    std::vector<int> mynums;
    mynums.push_back(5); // append
    mynums.push_back(3);

    //for(auto i: mynums)
    for(int n: mynums)
    {
        std::cout << n << std::endl;
    }

    for (int i = mynums.size() -1 ; i >= 0; i--)
    {
        std::cout << mynums[i] << std::endl;
    }
    



    // tamrin 
    std::vector<int> nums;
    int temp;
    std::cin >> temp;
    while(temp != -1)
    {
        nums.push_back(temp);
        std::cin >> temp;
    }
    for(int i = nums.size()-1 ; i>=0 ; i--)
    {
        std::cout << nums[i] << std::endl;
    }
    // tamrin





    return 0;
}
