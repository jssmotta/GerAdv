import { IApenso2 } from '../Apenso2/Interfaces/interface.Apenso2';
export interface Apenso2
{
    id: number;
	processo : number;
	apensado : number;
	nropastaprocessos?: string;

}


export function Apenso2Empty(): IApenso2 {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		apensado: 0,
    };
}

export function Apenso2TestEmpty(): IApenso2 {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		apensado: 1,
    };
}


