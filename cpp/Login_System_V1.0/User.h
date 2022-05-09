#pragma once

#ifndef USER_H_
#define USER_H_


#include <string>
#include <fstream>
#include <direct.h>
#include "define.h"


bool ExistDir(std::string fileName);



class IRegistration
{
public:
	virtual bool RegisterUser(const std::string userName, const std::string password) = 0;
};

class Registration : public IRegistration
{
public:
	Registration();
	Registration(const std::string userName, const std::string password); 
	bool RegisterUser(const std::string userName, const std::string password) override;

private:
	void CreateUserFile(const std::string userName);
	void WritePasswordToFile(const std::string userName, const std::string password);
	bool CreateUsersFolder();
};



class ILogin
{
public:
	virtual bool LoginUser(const std::string userName, const std::string password) = 0;
};

class Login : public ILogin
{
public:
	Login();
	Login(const std::string userName, const std::string password);
	bool LoginUser(const std::string userName, const std::string password) override;
};



class User
{
public:
	bool RegisterUser(const std::string userName, const std::string password);
	bool LoginUser(const std::string userName, const std::string password);
	void ExitAccount();

	std::string GetUserName() { return this->userName; }
	std::string GetUserPassword() { return this->password; }

private:
	Registration regUser;
	Login loginUser;

	bool CoreRegisterUser(IRegistration* regUser);
	bool CoreLoginUser(ILogin* loginUser);

	void SaveUserData(const std::string userName, const std::string password);

	std::string userName = WARRNING_EMPTY_DATA;
	std::string password = WARRNING_EMPTY_DATA;

};

#endif // !USER_H_