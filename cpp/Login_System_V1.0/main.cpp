#include <iostream>
#include <fstream>

#include "User.h"

using namespace std;


int main()
{	
	User us;
	string userName, password;
	int choice;

	cout << "+-------------------------+" << endl;
	cout << "| 1 - Registration        |" << endl;
	cout << "| 2 - Login in            |" << endl;
	cout << "+-------------------------+" << endl;
	cout << "===> ";
	cin >> choice;

	bool result;

	switch (choice)
	{
	case 1:
		cout << "Enter login: ";
		cin >> userName;
		cout << endl;

		cout << "Enter password: ";
		cin >> password;
		cout << endl;

		result = us.RegisterUser(userName, password);
		if (result)
		{
			cout << "Account \"" << userName << "\" registered" << endl;
		}
		else
		{
			cout << "Such an account is already registered!\n";
		}
		break;
		
	case 2:
		cout << "Enter login: ";
		cin >> userName;
		cout << endl;

		cout << "Enter password: ";
		cin >> password;
		cout << endl;

		result = us.LoginUser(userName, password);
		if (result)
		{
			cout << "Successful login to the account \"" << us.GetUserName() << "\"" << endl;
		}
		else
		{
			cout << "There is no such account!";
		}
		break;
	default:
		cout << "Wrong command!" << endl;
		break;
	}
	system("pause");
}