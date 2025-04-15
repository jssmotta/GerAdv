import { IUltimosProcessos } from "../UltimosProcessos/Interfaces/interface.UltimosProcessos";
export interface UltimosProcessos
{
    id: number;
	processo : number;
	quando : string;
	quem : number;
}

export function UltimosProcessosEmpty(): IUltimosProcessos {
// 20250125
    return {
        id: 0,
		processo: 0,
		quando: '',
		quem: 0,
    };
}
