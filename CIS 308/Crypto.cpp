#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

int main()
{
    // Read number
    int n = 79;
    cin >> n;
    string str;
    // Convert decimal to binary
    while (n)
    {
        if (n & 1)
        {
            str += '1';
        }
        else
        {
            str += '0';
        }
        n >>= 1;
    }
    // reverse string
    reverse(begin(str), end(str));
    // get length
    // and numbers
    int len = str.length();
    string ans = "";
    // For first one list numbers
    ans += to_string(len);
    cout << str[0] << "    ";
    cout << ans << endl;
    for (int i = 1; i < len; i++)
    {
        cout << str[i] << "    ";
        // Zero calls for square
        if (str[i] == '0')
        {
            ans.insert(ans.begin() + 0, '(');
            ans.push_back(')');
            ans += "^2";
        }
        // One calls for square + multiply
        else
        {
            ans.insert(ans.begin() + 0, '(');
            ans.push_back(')');
            ans += "^2";
            ans.push_back('*');
            ans += to_string(len);
        }
        cout << ans << endl;
    }
    return 0;
}