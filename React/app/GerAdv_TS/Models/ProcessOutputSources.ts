import { IProcessOutputSources } from '../ProcessOutputSources/Interfaces/interface.ProcessOutputSources';
export interface ProcessOutputSources
{
    id: number;
	nome : string;

}


export function ProcessOutputSourcesEmpty(): IProcessOutputSources {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function ProcessOutputSourcesTestEmpty(): IProcessOutputSources {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


