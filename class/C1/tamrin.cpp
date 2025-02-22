#include<iostream>
#include<vector>

int main()
{
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
    return 0;
}

