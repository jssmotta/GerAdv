import { IApenso } from '../Apenso/Interfaces/interface.Apenso';
export interface Apenso
{
    id: number;
	processo : number;
	apensox : string;
	acao : string;
	dtdist : string;
	obs : string;
	valorcausa : number;
	nropastaprocessos?: string;

}


export function ApensoEmpty(): IApenso {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		apensox: '',
		acao: '',
		dtdist: '',
		obs: '',
		valorcausa: 0,
    };
}

export function ApensoTestEmpty(): IApenso {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		apensox: 'X',
		acao: 'X',
		dtdist: 'X',
		obs: 'X',
		valorcausa: 1,
    };
}


