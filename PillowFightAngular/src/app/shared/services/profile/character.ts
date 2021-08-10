import internal from "stream";
import { IArmor } from "./armor";
import { Class } from "./class";
import { IWeapon } from "./weapon";

export interface ICharacter
{
    name: string;
    class: Class;
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    weapon: IWeapon;
    armor: IArmor;
}