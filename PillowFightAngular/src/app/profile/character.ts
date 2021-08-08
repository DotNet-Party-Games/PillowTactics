import internal from "stream";
import { IArmor } from "./armor";
import { IWeapon } from "./weapon";

export interface ICharacter
{
    name: string;
    class: string;
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    weapon: IWeapon;
    armor: IArmor;
}