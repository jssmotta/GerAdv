import { Auditor } from "./Auditor";

import { IProcessOutputRequest } from "../ProcessOutputRequest/Interfaces/interface.ProcessOutputRequest";
export interface ProcessOutputRequest
{
    id: number;
	processoutputengine : number;
	operador : number;
	processo : number;
	ultimoidtabelaexo : number;
	auditor?: Auditor | null;
}

export function ProcessOutputRequestEmpty(): IProcessOutputRequest {
// 20250125
    return {
        id: 0,
		processoutputengine: 0,
		operador: 0,
		processo: 0,
		ultimoidtabelaexo: 0,
		auditor: null
    };
}
