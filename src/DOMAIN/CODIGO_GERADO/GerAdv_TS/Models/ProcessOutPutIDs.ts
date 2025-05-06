import { IProcessOutPutIDs } from "../ProcessOutPutIDs/Interfaces/interface.ProcessOutPutIDs";
export interface ProcessOutPutIDs
{
    id: number;
	nome : string;
}

export function ProcessOutPutIDsEmpty(): IProcessOutPutIDs {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
