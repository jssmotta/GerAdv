import { IProPartes } from '../ProPartes/Interfaces/interface.ProPartes';
export interface ProPartes
{
    id: number;
	processo : number;
	parte : number;
	nropastaprocessos?: string;

}


export function ProPartesEmpty(): IProPartes {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		parte: 0,
    };
}

export function ProPartesTestEmpty(): IProPartes {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		parte: 1,
    };
}


