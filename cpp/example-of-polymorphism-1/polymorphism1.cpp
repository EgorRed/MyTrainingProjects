#include <iostream>

/*
*  Example of polymorphism.
*  method "Use()" from the class "Player" works correctly with any other class object, which implements the interface "IWeapon".
*/


class IWeapon
{
public:
    virtual void Use() = 0;
};


class Gun : public IWeapon
{
public:
    void Use() override
    {
        std::cout << " Gun - Use()  " << std::endl;
    }
};


class ColdWeapon : public IWeapon
{
public:
    void Use() override
    {
        std::cout << " ColdWeapon - Use()" << std::endl;
    }
};


class Player
{
public:
    void PlayerUse(IWeapon* weapon)
    {
        weapon.Use();
    }
};


int main()
{

    Gun pistol;
    ColdWeapon knife;

    Player p;
    p.PlayerUse(&pistol);
    p.PlayerUse(&knife);

    return 0;

}
