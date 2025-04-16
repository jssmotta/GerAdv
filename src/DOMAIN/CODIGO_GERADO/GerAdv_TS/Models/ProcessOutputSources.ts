import { IProcessOutputSources } from "../ProcessOutputSources/Interfaces/interface.ProcessOutputSources";
export interface ProcessOutputSources
{
    id: number;
	nome : string;
}

export function ProcessOutputSourcesEmpty(): IProcessOutputSources {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
