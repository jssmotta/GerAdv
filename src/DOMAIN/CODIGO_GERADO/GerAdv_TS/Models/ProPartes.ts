import { IProPartes } from "../ProPartes/Interfaces/interface.ProPartes";
export interface ProPartes
{
    id: number;
	processo : number;
	parte : number;
}

export function ProPartesEmpty(): IProPartes {
// 20250125
    return {
        id: 0,
		processo: 0,
		parte: 0,
    };
}
