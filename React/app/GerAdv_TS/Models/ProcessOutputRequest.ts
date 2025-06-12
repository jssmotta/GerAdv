import { IProcessOutputRequest } from '../ProcessOutputRequest/Interfaces/interface.ProcessOutputRequest';
export interface ProcessOutputRequest
{
    id: number;
	processoutputengine : number;
	operador : number;
	processo : number;
	ultimoidtabelaexo : number;
	nomeprocessoutputengine?: string;
	nomeoperador?: string;
	nropastaprocessos?: string;

}


export function ProcessOutputRequestEmpty(): IProcessOutputRequest {
// 20250604
    
    return {
        id: 0,
		processoutputengine: 0,
		operador: 0,
		processo: 0,
		ultimoidtabelaexo: 0,
    };
}

export function ProcessOutputRequestTestEmpty(): IProcessOutputRequest {
// 20250604
    
    return {
        id: 1,
		processoutputengine: 1,
		operador: 1,
		processo: 1,
		ultimoidtabelaexo: 1,
    };
}


