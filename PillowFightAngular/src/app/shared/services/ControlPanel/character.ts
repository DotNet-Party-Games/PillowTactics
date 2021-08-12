import { IArmor } from "./armor";
import { Class } from "./class";
import { IWeapon } from "./weapon";

export interface ICharacter
{
    id: number,
    name: string;
    characterClass: Class;
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    weapon: IWeapon;
    armor: IArmor;
}