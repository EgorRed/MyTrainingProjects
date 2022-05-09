#include "User.h"

bool ExistDir(std::string fileName)
{
	char* name = &fileName[0];
	struct stat s;
	if (stat(name, &s)) return false;
	return s.st_mode;
}


Registration::Registration()
{
	if (!ExistDir(NAME_FOLDER_WITH_USERS)) CreateUsersFolder();
}


Registration::Registration(const std::string userName, const std::string password) : Registration()
{
	RegisterUser(userName, password);
}


bool Registration::RegisterUser(const std::string userName, const std::string password) 
{
	if (!ExistDir(NAME_FOLDER_WITH_USERS "\\" + userName + ".txt"))
	{
		CreateUserFile(userName);
		WritePasswordToFile(userName, password);
		return true;
	}
	return false;
}


void Registration::CreateUserFile(const std::string userName)
{
	std::ofstream userTXT;
	userTXT.open(NAME_FOLDER_WITH_USERS "\\" + userName + ".txt");
	userTXT.close();	
}


void Registration::WritePasswordToFile(const std::string userName, const std::string password)
{
	std::ofstream userTXT;
	userTXT.open(NAME_FOLDER_WITH_USERS "\\" + userName + ".txt");
	userTXT << password;
	userTXT.close();
}


bool Registration::CreateUsersFolder()
{	
	int result = _mkdir(NAME_FOLDER_WITH_USERS);
	return result;
}



Login::Login() 
{
	
}

Login::Login(const std::string userName, const std::string password)
{
	LoginUser(userName, password);
}


bool Login::LoginUser(const std::string userName, const std::string password)
{
	if (!ExistDir(NAME_FOLDER_WITH_USERS)) throw std::exception("The folder with users is missing!");

	if (ExistDir(NAME_FOLDER_WITH_USERS "\\" + userName + ".txt"))
	{
		std::string buff;
		std::ifstream userTXT(NAME_FOLDER_WITH_USERS "\\" + userName + ".txt");

		userTXT >> buff;
		if (buff == password)
		{
			userTXT.close();
			return true;
		}
		userTXT.close();
	}
	return false;
}



bool User::RegisterUser(const std::string userName, const std::string password)
{
	SaveUserData(userName, password);
	bool managedToRegister = CoreRegisterUser(&this->regUser);
	return managedToRegister;
}


bool User::LoginUser(const std::string userName, const std::string password)
{
	SaveUserData(userName, password);
	bool managedToLogin = CoreLoginUser(&this->loginUser);
	return managedToLogin;
}


void User::ExitAccount()
{
	this->userName = WARRNING_EMPTY_DATA;
	this->password = WARRNING_EMPTY_DATA;
}


bool User::CoreRegisterUser(IRegistration* regUser)
{
	bool managedToRegister = regUser->RegisterUser(this->userName, this->password);
	return managedToRegister;
}

bool User::CoreLoginUser(ILogin* loginUser)
{
	bool managedToLogin = loginUser->LoginUser(this->userName, this->password);
	return managedToLogin;
}

void User::SaveUserData(const std::string userName, const std::string password)
{
	this->userName = userName;
	this->password = password;
}
